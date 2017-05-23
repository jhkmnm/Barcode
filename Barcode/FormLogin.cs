using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using IWshRuntimeLibrary;

namespace Barcode
{
    public partial class FormLogin : Form
    {
        string str_api = "http://abc.xxczd.com/index.php/api/api";
        const string token = "chzpdx2014mn1989";
        string str_province = "/getProvince";
        string str_city = "/getCity";
        string str_district = "/getDistrict";
        string str_login = "/login";
        string city, district;

        public FormLogin()
        {
            CreateShortCut();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            if (LoadProvince())
                LoadPw();
            else
                MessageBox.Show("连接服务器失败");
        }

        private bool LoadProvince()
        {
            var htmlstr = Html.Post(str_api + str_province, "token=" + token);
            if (string.IsNullOrWhiteSpace(htmlstr))
                return false;
            List<Region> province = JsonConvert.DeserializeObject<List<Region>>(htmlstr);
            province.Insert(0, new Barcode.Region { region_id = 0, region_name = "选择省" });
            ddlProvince.DataSource = province;
            ddlProvince.DisplayMember = "region_name";
            ddlProvince.ValueMember = "region_id";
            ddlProvince.SelectedIndex = 0;
            ddlProvince.SelectedIndexChanged += ddlProvince_SelectedIndexChanged;
            return true;
        }

        private void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCity();
        }

        private void LoadCity()
        {
            var htmlstr = Html.Post(str_api + str_city, string.Format("token={0}&provinceId={1}", token, ddlProvince.SelectedValue));
            var regionresult = JsonConvert.DeserializeObject<RegionResult>(htmlstr);

            if (regionresult.Status != "40000")
            {
                ddlCity.DataSource = regionresult.Data;
                ddlCity.DisplayMember = "region_name";
                ddlCity.ValueMember = "region_id";
                if (string.IsNullOrWhiteSpace(city))
                    ddlCity.SelectedIndex = 0;
                else
                    ddlCity.SelectedItem = ((List<Region>)ddlCity.DataSource).Find(f => f.region_id.ToString() == city);
            }
            else
            {
                ddlCity.DataSource = null;
            }
        }

        private void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDistrict();
        }

        private void LoadDistrict()
        {
            var cityid = "";
            if (ddlCity.SelectedValue is int)
                cityid = ddlCity.SelectedValue.ToString();
            else
                cityid = ((Region)ddlCity.SelectedValue).region_id.ToString();

            var htmlstr = Html.Post(str_api + str_district, string.Format("token={0}&cityId={1}", token, cityid));
            var regionresult = JsonConvert.DeserializeObject<RegionResult>(htmlstr);
            if (regionresult.Status != "40000")
            {
                ddlDistrict.DataSource = regionresult.Data;
                ddlDistrict.DisplayMember = "region_name";
                ddlDistrict.ValueMember = "region_id";
                if (string.IsNullOrWhiteSpace(district))
                    ddlDistrict.SelectedIndex = 0;
                else
                    ddlDistrict.SelectedItem = ((List<Region>)ddlDistrict.DataSource).Find(f => f.region_id.ToString() == district);
            }
            else
            {
                ddlDistrict.DataSource = null;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var htmlstr = Html.Post(str_api + str_login, string.Format("token={0}&adminName={1}&adminPwd={2}&districtId={3}", token, txtUserName.Text, txtPassword.Text, ddlDistrict.SelectedValue));
            var userresult = JsonConvert.DeserializeObject<UserResult>(htmlstr);
            if(userresult.Status == "40000")
            {
                MessageBox.Show(userresult.Message);
                return;
            }

            if (chkR.Checked)
                SavePw();

            User.SessionID = userresult.Data.SessionID;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        /// <summary>
        /// 本地保存登录的账号和密码
        /// </summary>
        public void SavePw()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["UserName"].Value = txtUserName.Text;
            configuration.AppSettings.Settings["PassWord"].Value = txtPassword.Text;
            configuration.AppSettings.Settings["Province"].Value = ddlProvince.SelectedValue.ToString();
            configuration.AppSettings.Settings["City"].Value = ddlCity.SelectedValue.ToString();
            configuration.AppSettings.Settings["District"].Value = ddlDistrict.SelectedValue.ToString();
            configuration.AppSettings.Settings["chkSavePass"].Value = "True";
            configuration.Save();
        }

        /// <summary>
        /// 读取本地的账号和密码
        /// </summary>
        public void LoadPw()
        {
            if (ConfigurationManager.AppSettings["chkSavePass"] == "True")
            {
                txtUserName.Text = ConfigurationManager.AppSettings["UserName"];
                txtPassword.Text = ConfigurationManager.AppSettings["PassWord"];
                district = ConfigurationManager.AppSettings["District"];
                city = ConfigurationManager.AppSettings["City"];
                var v = ConfigurationManager.AppSettings["Province"];
                if (!string.IsNullOrWhiteSpace(v))
                    ddlProvince.SelectedItem = ((List<Region>)ddlProvince.DataSource).Find(f => f.region_id.ToString() == v);
                chkR.Checked = true;
            }
        }

        public void CreateShortCut()
        {
            string strFullPath = Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileNameWithoutExtension(strFullPath);
            string DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);//得到桌面文件夹  
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(DesktopPath + "\\" + strFileName + ".lnk");
            shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            shortcut.Arguments = "";// 参数            
            shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
            shortcut.WindowStyle = 1;
            shortcut.Save();
        }

        private void comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var com = (ComboBox)sender;
            if (com.Items.Count == 0) return;
            e.DrawBackground();            
            Font ft = new Font("宋体", 14f);
            string str = ((Region)com.Items[e.Index]).region_name;
            e.Graphics.DrawString(str, ft, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
            e.DrawFocusRectangle();
        }
    }
}
