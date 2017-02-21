using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using CsharpHttpHelper;
using Newtonsoft.Json;
using System.Data;

namespace Barcode
{
    public partial class Form1 : Form
    {
        string str_api = "http://czd.xinlvs.com/index.php/api/api";
        const string token = "chzpdx2014mn1989";
        string str_province = "/getProvince";
        string str_city = "/getCity";
        string str_district = "/getDistrict";
        string str_login = "/login";
        string str_Chooser = "/getChooser";
        string str_ChooserData = "/getChooseData";
        string str_SaveAndPrint = "/saveAndPrint";
        string session = "";

        public Form1()
        {
            InitializeComponent();
        }

        private string Post(string url, string postdata)
        {
            HttpItem item = new HttpItem
            {
                URL = url,
                Postdata = postdata,
                Method = "POST"
            };
            return GetHtml(item);
        }

        private string GetHtml(HttpItem item)
        {
            HttpHelper http = new HttpHelper();
            HttpResult htmlr = http.GetHtml(item);
            return htmlr.Html;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApiTest();

            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
            textBox2.Text = sDefault;

            foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                listBox1.Items.Add(sPrint);
                if (sPrint == sDefault)
                    listBox1.SelectedIndex = listBox1.Items.IndexOf(sPrint);
            }
        }

        private void ApiTest()
        {
            //1. 程序加载时请求province,city,district得到districtid
            //2. 登录请求login,得到sessionid
            //3. 登录成功后，请求chooser得到分拣员，请求chooserdata

            var province = Post(str_api + str_province, "token=chzpdx2014mn1989");
            var city = Post(str_api + str_city, "token=chzpdx2014mn1989&provinceId=");
            var district = Post(str_api + str_district, "token=chzpdx2014mn1989&cityId=");
            var user = Post(str_api + str_login, "token=chzpdx2014mn1989&adminName=&adminPwd=&districtId=");
            var chooser = Post(str_api + str_Chooser, "token=chzpdx2014mn1989&sessionId=");
            var chooserdata = Post(str_api + str_ChooserData, "token=chzpdx2014mn1989&sessionId=&page=&chooser_id=&send_order_top=&send_order_down=&send_date=&is_assig=&is_wrong=&is_owegoods=");
            var saveandprint = Post(str_api + str_SaveAndPrint, "token=chzpdx2014mn1989&sessionId=&num=&id=");

        }

        private void Print(DataTable dt)
        {
            //btnPrint.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var rpt = new ProductWeight();            
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请选择要打印的项");
                return;
            }
            
            try
            {
                rpt.SetDataSource(dt);
                rpt.PrintOptions.PrinterName = textBox2.Text;//System.Configuration.ConfigurationManager.AppSettings.Get("PrintName_InStockLabel");
                var doc = new System.Drawing.Printing.PrintDocument
                {
                    PrinterSettings =
                    {
                        PrinterName = textBox2.Text
                            //System.Configuration.ConfigurationManager.AppSettings.Get("PrintName_InStockLabel")
                    }
                };
                var papername = "40*30";//System.Configuration.ConfigurationManager.AppSettings.Get("PaperName_4585");
                if (!string.IsNullOrEmpty(papername))
                {
                    var rawKind = 1;
                    for (var i = 0; i <= doc.PrinterSettings.PaperSizes.Count - 1; i++)
                    {
                        if (doc.PrinterSettings.PaperSizes[i].PaperName.ToLower() == papername)
                        {
                            rawKind = doc.PrinterSettings.PaperSizes[i].RawKind;
                        }
                    }
                    rpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                }
                rpt.PrintToPrinter(1, true, 0, 0);
                rpt.Close();
                rpt.Dispose();
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

            KCCPort port = new KCCPort();
            var weight = port.ProductWeight();
            if(weight.IsError)
            {
                if (weight.Value != "error")
                    MessageBox.Show(weight.Value);
                else
                    MessageBox.Show("读取重量失败");
            }

            var newrow = printdata.NewRow();
            newrow["PIndex"] = 1;
            newrow["CustName"] = "公司名称abc";
            newrow["ProductName"] = "小白菜";
            newrow["Unit"] = "斤";
            newrow["Weight"] = "4.56";
            printdata.Rows.Add(newrow);
            Print(printdata);
        }
    }
}
