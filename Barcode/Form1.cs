using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using CsharpHttpHelper;
using Newtonsoft.Json;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Cache;

namespace Barcode
{
    public partial class Form1 : Form
    {
        string str_api = "http://czd.xinlvs.com/index.php/api/api";
        const string token = "chzpdx2014mn1989";        
        string str_Chooser = "/getChooser";
        string str_ChooserData = "/getChooseData";
        string str_SaveAndPrint = "/saveAndPrint";
        string session = "";

        public Form1()
        {
            InitializeComponent();
            LoadChooser();           
        }

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

        

        private void button1_Click(object sender, EventArgs e)
        {
            ApiTest();

            //PrintDocument print = new PrintDocument();
            //string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
            //textBox2.Text = sDefault;

            //foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            //{
            //    listBox1.Items.Add(sPrint);
            //    if (sPrint == sDefault)
            //        listBox1.SelectedIndex = listBox1.Items.IndexOf(sPrint);
            //}
        }

        private void ApiTest()
        {
            //1. 程序加载时请求province,city,district得到districtid
            //2. 登录请求login,得到sessionid
            //3. 登录成功后，请求chooser得到分拣员，请求chooserdata            //
            
            
            
            //&page=&chooser_id=&send_order_top=&send_order_down=&send_date=&is_assig=&is_wrong=&is_owegoods=
            //htmlstr = Post(str_api + str_ChooserData, string.Format("token=chzpdx2014mn1989&sessionId={0}", session.SessionID));
            //var chooserdata = JsonConvert.DeserializeObject<ChooserDataResult>(htmlstr);
            //string str = string.Format("token=chzpdx2014mn1989&sessionId={0}&num=&id=", session.SessionID);
            //htmlstr = Post(str_api + str_SaveAndPrint, str);
            //result = JsonConvert.DeserializeObject<Result>(htmlstr);
        }

        ProductWeight rpt = null;
        private void Print(DataTable dt)
        {
            //btnPrint.Enabled = false;
            Cursor = Cursors.WaitCursor;
                        
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请选择要打印的项");
                return;
            }
            if(rpt == null)
            {
                rpt = new ProductWeight();
                rpt.PrintOptions.PrinterName = textBox2.Text;//System.Configuration.ConfigurationManager.AppSettings.Get("PrintName_InStockLabel");
                var doc = new System.Drawing.Printing.PrintDocument
                {
                    PrinterSettings =
                    {
                        PrinterName = textBox2.Text
                            //System.Configuration.ConfigurationManager.AppSettings.Get("PrintName_InStockLabel")
                    }
                };
                var papername = "40 x 30";//System.Configuration.ConfigurationManager.AppSettings.Get("PaperName_4585");
                if (!string.IsNullOrEmpty(papername))
                {
                    for (var i = 0; i <= doc.PrinterSettings.PaperSizes.Count - 1; i++)
                    {
                        if (doc.PrinterSettings.PaperSizes[i].PaperName.ToLower() == papername)
                        {
                            rpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)doc.PrinterSettings.PaperSizes[i].RawKind;
                            break;
                        }
                    }
                }
            }
            
            try
            {
                rpt.SetDataSource(dt);                
                rpt.PrintToPrinter(1, true, 0, 0);
                //rpt.Close();
                //rpt.Dispose();
                MessageBox.Show("打印完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询出错，请将错误截图" + Environment.NewLine + ex.Message + ex.StackTrace);
            }
            finally
            {
                //btnPrint.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var printdata = new DataTable();
            printdata.Columns.AddRange(new[]{
                new DataColumn("PIndex", typeof(int)),
                new DataColumn("CustName", typeof(string)),
                new DataColumn("ProductName", typeof(string)),
                new DataColumn("Unit", typeof(string)),
                new DataColumn("Weight", typeof(string))
            });

            //KCCPort port = new KCCPort();
            //var weight = port.ProductWeight();
            //if(weight.IsError)
            //{
            //    if (weight.Value != "error")
            //        MessageBox.Show(weight.Value);
            //    else
            //        MessageBox.Show("读取重量失败");
            //}

            var newrow = printdata.NewRow();
            newrow["PIndex"] = 1;
            newrow["CustName"] = "白开水科技有限公司";
            newrow["ProductName"] = "小白菜";
            newrow["Unit"] = "斤";
            newrow["Weight"] = "4.56";
            printdata.Rows.Add(newrow);
            Print(printdata);
        }

        KCCPort port = new KCCPort();
        Thread thread;
        ManualResetEvent ma;
        bool on_off = false;
        bool stop = false;

        private void button3_Click(object sender, EventArgs e)
        {
            if (port.initComPort("strPortName"))
            {
                if(MessageBox.Show("秤连接成功，是否开始秤重", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.OK)
                {
                    GetWeightRun();
                }
            }
            else
            {
                MessageBox.Show("端口初始化失败，请确认！");
            }
        }

        #region 秤
        private void GetWeightRun()
        {
            thread = new Thread(GetWeight);
            thread.Start();
        }

        private void Off()
        {
            on_off = true;
        }

        private void On()
        {
            on_off = false;
        }

        private void Stop()
        {
            stop = true;
        }

        private void GetWeight()
        {
            if (stop)
                return;
            if (on_off)
            {
                ma = new ManualResetEvent(false);
                ma.WaitOne();
            }
            var weight = port.ProductWeight();
            this.Invoke(new Action(() =>
            {
                textBox2.Text = ExtractWeight(weight);
            }));

            Thread.Sleep(100);
        }

        private string ExtractWeight(string str)
        {
            var weights = str.Split('\r');
            string def = "";
            int count = 0;

            return weights[weights.Length - 1];

            //foreach (string weight in weights)
            //{
            //    if (weight != def)
            //    {
            //        count = 0;
            //    }
            //    else if (weight.EndsWith("R"))
            //    {
            //        count++;
            //    }
            //    def = weight;

            //    if (count == mateCount)
            //    {
            //        break;
            //    }
            //}

            //return count == mateCount ? def.TrimEnd('R') : "error";
        }

        #endregion
    }

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

    public class ChooserDataResult:Result
    {
        public List<ChooseData> Data { get; set; }
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
    }    

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
}
