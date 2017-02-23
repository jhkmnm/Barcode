using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Barcode
{
    public partial class FormLogin : Form
    {
        string str_api = "http://czd.xinlvs.com/index.php/api/api";
        const string token = "chzpdx2014mn1989";
        string str_province = "/getProvince";
        string str_city = "/getCity";
        string str_district = "/getDistrict";
        string str_login = "/login";

        public FormLogin()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            LoadProvince();
        }

        private void LoadProvince()
        {
            var htmlstr = Html.Post(str_api + str_province, "token=" + token);
            List<Region> province = JsonConvert.DeserializeObject<List<Region>>(htmlstr);
            province.Insert(0, new Barcode.Region { region_id = 0, region_name = "选择省" });
            ddlProvince.DataSource = province;
            ddlProvince.DisplayMember = "region_name";
            ddlProvince.ValueMember = "region_id";
            ddlProvince.SelectedIndex = 0;
            ddlProvince.SelectedIndexChanged += ddlProvince_SelectedIndexChanged;
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
                ddlCity.SelectedIndex = 0;
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
                ddlDistrict.SelectedIndex = 0;
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
            User.SessionID = userresult.Data.SessionID;
            this.DialogResult = DialogResult.OK;
        }
    }
}
