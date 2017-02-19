using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace Barcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
