using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using Newtonsoft.Json;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Cache;
using System.ComponentModel;
using Microsoft.Win32;
using CrystalDecisions.CrystalReports.Engine;

namespace Barcode
{
    public partial class Form1 : Form
    {
        string str_api = "http://abc.xxczd.com/index.php/api/api";
        const string token = "chzpdx2014mn1989";        
        string str_Chooser = "/getChooser";
        string str_ChooserData = "/getChooseData";
        string str_SaveAndPrint = "/saveAndPrint";

        ReportClass rpt = null;
        DataTable printdata = null;

        KCCPort port = new KCCPort();
        Thread thread;
        ManualResetEvent ma;
        bool on_off = false;
        bool stop = false;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            LoadChooser();
            InitDDL();
            LoadDevice();

            ucPagerEx1.InitPageInfo(0, 20);
            ucPagerEx1.PageChanged += ucPagerEx1_PageChanged;
        }

        #region 初始化窗口
        private void LoadChooser()
        {
            var htmlstr = Html.Post(str_api + str_Chooser, string.Format("token={0}&sessionId={1}", token, User.SessionID));
            var choosers = JsonConvert.DeserializeObject<List<Chooser>>(htmlstr);
            choosers.Insert(0, new Chooser { Chooser_ID = "0", Name = "请选择" });
            ddlChooser.DataSource = choosers;
            ddlChooser.DisplayMember = "Name";
            ddlChooser.ValueMember = "Chooser_ID";
            ddlChooser.SelectedIndex = 0;
        }

        private void InitDDL()
        {
            Utilities.InitComboBox.InitDorpDownByEnum(ddlIsAssign, typeof(Assign));
            Utilities.InitComboBox.InitDorpDownByEnum(ddlIsowegoods, typeof(Owegoods));
            Utilities.InitComboBox.InitDorpDownByEnum(ddlIswrong, typeof(Wrong));
        }

        private void LoadDevice()
        {
            #region 打印机
            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;//默认打印机名            

            foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                var i = ddlPrinter.Items.Add(sPrint);
                if (sPrint == sDefault)
                    ddlPrinter.SelectedIndex = i;
            }
            #endregion

            #region 串口
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    ddlProt.Items.Add(sValue);
                }
                ddlProt.SelectedIndex = 0;
            }
            #endregion

            Utilities.InitComboBox.InitDorpDownByEnum(ddlPageSize, typeof(PageSize));
        }

        #endregion        

        #region 打印
        private bool Print(DataTable dt)
        {
            Cursor = Cursors.WaitCursor;
                        
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请选择要打印的项");
                return false;
            }
            if(rpt == null)
            {
                if (ddlPageSize.Text == "40 x 30")
                    rpt = new ProductWeight();
                else if (ddlPageSize.Text == "40 x 60")
                    rpt = new ProductWeight60();
                else
                    rpt = new ProductWeight50();
                rpt.PrintOptions.PrinterName = ddlPrinter.Text;//System.Configuration.ConfigurationManager.AppSettings.Get("PrintName_InStockLabel");
                var doc = new System.Drawing.Printing.PrintDocument
                {
                    PrinterSettings =
                    {
                        PrinterName = ddlPrinter.Text //System.Configuration.ConfigurationManager.AppSettings.Get("PrintName_InStockLabel")
                    }
                };
                var papername = ddlPageSize.Text;//System.Configuration.ConfigurationManager.AppSettings.Get("PaperName_4585");
                bool hassize = false;
                if (!string.IsNullOrEmpty(papername))
                {
                    for (var i = 0; i <= doc.PrinterSettings.PaperSizes.Count - 1; i++)
                    {
                        if (doc.PrinterSettings.PaperSizes[i].PaperName.ToLower() == papername)
                        {
                            hassize = true;
                            rpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)doc.PrinterSettings.PaperSizes[i].RawKind;
                            break;
                        }
                    }
                }
                if (!hassize)
                {
                    MessageBox.Show("系统内未找到" + ddlPageSize.Text +"的纸张，请先配置纸张");
                    return false;
                }                    
            }            
            
            try
            {
                rpt.SetDataSource(dt);
                rpt.PrintToPrinter(1, true, 0, 0);                
                //MessageBox.Show("打印完成");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错:" + Environment.NewLine + ex.Message + ex.StackTrace);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool Print(string weight)
        {
            if(printdata == null)
            {
                printdata = new DataTable();
                printdata.Columns.AddRange(new[]{
                    new DataColumn("PIndex", typeof(int)),
                    new DataColumn("CustName", typeof(string)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("Unit", typeof(string)),
                    new DataColumn("Weight", typeof(string))
                });
            }
            else
                printdata.Rows.Clear();

            var newrow = printdata.NewRow();
            newrow["PIndex"] = CurrentData.Send_Order;
            newrow["CustName"] = CurrentData.CName;
            newrow["ProductName"] = CurrentData.Name;
            newrow["Unit"] = CurrentData.Unit;
            newrow["Weight"] = CurrentData.Unit == "斤" ? weight : (Convert.ToDecimal(weight) / 2).ToString();
            printdata.Rows.Add(newrow);
            return Print(printdata);
        }
        #endregion              

        #region 秤
        private void GetWeightRun()
        {
            thread = new Thread(GetWeight);
            thread.Start();
        }

        /// <summary>
        /// 暂停读秤
        /// </summary>
        private void Off()
        {
            on_off = true;
        }

        /// <summary>
        /// 继续读秤
        /// </summary>
        private void On()
        {
            on_off = false;
            if(ma != null)
            ma.Set();
        }
        /// <summary>
        /// 停止读秤
        /// </summary>
        private void Stop()
        {
            stop = true;
        }

        private void GetWeight()
        {
            while (true)
            {
                if (stop)
                    return;
                if (on_off)
                {
                    ma = new ManualResetEvent(false);
                    ma.WaitOne();
                }
                var weight = port.ProductWeight();
                if (!string.IsNullOrWhiteSpace(weight))
                {
                    try
                    {
                        Invoke(new Action(() =>
                        {
                            txtWeight_1.Text = ExtractWeight(weight);
                            //textBox1.Text += ExtractWeight(weight) + Environment.NewLine;
                        }));
                    }
                    catch { }
                }

                Thread.Sleep(500);
            }            
        }

        private string ExtractWeight(string str)
        {
            var weights = str.Split('\r');
            string weight = "";
            Regex reg = new Regex(@"\d+\.?\d*");
            
            for(int i= weights.Length-1;i>=0;i--)
            {
                if (!string.IsNullOrWhiteSpace(weights[i]))
                {
                    var match = reg.Match(weights[i]);
                    weight = match.Value;
                }
            }

            return (Convert.ToDecimal(weight) * 2).ToString();            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (btnTest.Text == "停止")
            {
                stop = true;
                btnTest.Text = "测试商品";
                port.ClosePort();
            }
            else
            {
                if (port.initComPort(ddlProt.Text))
                {
                    if (MessageBox.Show("秤连接成功，是否开始秤重", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        stop = false;
                        on_off = false;
                        GetWeightRun();
                        btnTest.Text = "停止";
                    }
                }
                else
                {
                    MessageBox.Show("端口初始化失败，请确认！");
                }
            }
        }
        #endregion

        #region 分拣数据
        private List<ChooseData> ChooseDataList
        {
            get { return chooseDataBindingSource.DataSource as List<ChooseData>; }
            set
            {
                if (value == null)
                {
                    chooseDataBindingSource.Clear();
                }
                else
                {
                    chooseDataBindingSource.DataSource = value;
                    dgvData.Refresh();
                    foreach(DataGridViewRow row in dgvData.SelectedRows)
                    {
                        row.Selected = false;
                    }
                    if(dgvData.Rows.Count > 0)                    
                        dgvData.Rows[0].Selected = true;
                }
            }
        }

        private ChooseData CurrentData
        {
            get { return chooseDataBindingSource.Current as ChooseData; }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var chooserdata = Search(1);
            ChooseDataList = chooserdata.Data;
            ucPagerEx1.InitPageInfo(chooserdata.Page.Total, chooserdata.Page.PageSize);
        }

        private ChooseDataResult Search(int page)
        {
            var postdata = string.Format("token={0}&sessionId={1}&page={9}&chooser_id={2}&send_order_top={3}&send_order_down={4}&send_date={5}&is_assig={6}&is_wrong={7}&is_owegoods={8}", token, User.SessionID, ddlChooser.SelectedValue, txtTop.Text, txtDown.Text, dtpSendDate.Checked ? dtpSendDate.Value.ToString("yyyy-MM-dd") : "", ddlIsAssign.SelectedIndex, ddlIswrong.SelectedIndex, ddlIsowegoods.SelectedIndex, page);
            var htmlstr = Html.Post(str_api + str_ChooserData, postdata);
            return JsonConvert.DeserializeObject<ChooseDataResult>(htmlstr);
        }

        void ucPagerEx1_PageChanged(object sender, EventArgs e)
        {
            var chooserdata = Search(ucPagerEx1.PageIndex);
            ChooseDataList = chooserdata.Data;
        }

        private bool SaveWeight()
        {
            var weight = "";
            if (!string.IsNullOrWhiteSpace(txtWeight_2.Text))
                weight = txtWeight_2.Text;
            else
                weight = txtWeight_1.Text;
            Utilities.DataVerifier dv = new Utilities.DataVerifier();
            dv.Check(string.IsNullOrWhiteSpace(weight), "请连接电子秤称重或手动输入重量");
            if(dv.Pass)
            {
                if (Print(weight))
                {
                    CurrentData.Weight = weight;
                    var postdata = string.Format("token={0}&sessionId={1}&num={2}&id={3}", token, User.SessionID, weight, CurrentData.ID);
                    var htmlstr = Html.Post(str_api + str_SaveAndPrint, postdata);
                    var result = JsonConvert.DeserializeObject<Result>(htmlstr);
                    dgvData.Refresh();
                    dv.Check(result.Status == "40000", result.Message);
                }
                else
                {
                    return false;
                }
            }

            dv.ShowMsgIfFailed();
            return dv.Pass;
        }

        void dgvData_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if(e.ColumnIndex == colAction.Index)
            {
                Off();
                if(SaveWeight())
                {
                    dgvData.Rows[e.RowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex + 1].Selected = true;
                    txtWeight_2.Text = "";
                }
                On();
            }
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop = true;
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
        }

        private void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rpt = null;
        }
    }

    #region 实体
    public class Result
    {
        public string Status{ get; set; }
        public string Message{ get; set; }
    }

    public class RegionResult : Result
    {        
        public List<Region> Data{ get; set; }
    }

    public class UserResult : Result
    {
        public Session Data { get; set; }
    }

    public class ChooseDataResult : Result
    {
        public List<ChooseData> Data { get; set; }
        public Page Page { get; set; }
    }

    public class Session
    {
        public string SessionID { get; set; }
    }

    public class User
    {
        public static string SessionID;
    }

    public class Region
    {
        public int region_id { get; set; }
        public string region_name { get; set; }
    }    

    public class Chooser
    {
        public string Chooser_ID { get; set; }
        public string Name { get; set; }
        public string Phone{ get; set; }
        public int Status{ get; set; }
        public int Rid{ get; set; }
    }

    public class ChooseData
    {
        public string ID { get; set; }
        public string O_ID { get; set; }
        public string P_ID { get; set; }
        public string Is_Assign { get; set; }
        public string Is_Owegoods { get; set; }
        public string Is_Wrong { get; set; }
        public string Num { get; set; }
        public string Price { get; set; }
        public string Real_Num { get; set; }
        public string Order_Date { get; set; }
        public string U_ID { get; set; }
        public string Send_Date { get; set; }
        public string Uid { get; set; }
        public string Send_Order { get; set; }
        public string CName { get; set; }
        public string Choose_Order { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Unit { get; set; }
        public string K_Num { get; set; }
        public string Chooser_ID { get; set; }
        public string Weight { get; set; }
        public string Action { get { return "保存打印"; } }
    }

    public class Page
    {
        public int Total {get;set;}
        public int PageSize{get;set;}
    }
    #endregion

    public class Html
    {
        public static string Post(string url, string postdata)
        {
            Encoding myEncoding = Encoding.UTF8;
            string sContentType = "application/x-www-form-urlencoded";
            HttpWebRequest req;

            try
            {
                req = WebRequest.Create(url) as HttpWebRequest;
                req.Method = "POST";
                req.Accept = "*/*";
                req.KeepAlive = false;
                req.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

                byte[] bufPost = myEncoding.GetBytes(postdata);
                req.ContentType = sContentType;
                req.ContentLength = bufPost.Length;
                Stream newStream = req.GetRequestStream();
                newStream.Write(bufPost, 0, bufPost.Length);
                newStream.Close();

                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                try
                {
                    Encoding encoding = Encoding.UTF8;
                    System.Diagnostics.Debug.WriteLine(encoding);

                    using (Stream resStream = res.GetResponseStream())
                    {
                        using (StreamReader resStreamReader = new StreamReader(resStream, encoding))
                        {
                            return resStreamReader.ReadToEnd();
                        }
                    }
                }
                finally
                {
                    res.Close();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }

    #region 枚举
    public enum Assign
    {
        [Description("未分")]
        A,
        [Description("已分")]
        B,
    }

    public enum Wrong
    {
        [Description("没报错")]
        A,
        [Description("报错")]
        B,
    }

    public enum Owegoods
    {
        [Description("没欠货")]
        A,
        [Description("欠货")]
        B,
    }

    public enum PageSize
    {
        [Description("40 x 30")]
        A,
        [Description("50 x 40")]
        B,
        //[Description("40 x 60")]
        //C
    }
    #endregion
}
