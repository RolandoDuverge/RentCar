using Newtonsoft.Json;
using RentCar_UI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar_UI
{
    public partial class FrmLogin : MaterialSkin.Controls.MaterialForm
    {
        public FrmLogin()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue900, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            {
                string username = UserBox.Text;
                string password = PasswordBox.Text;
                if (username != null && password != null)
                {
                    var client = new HttpClient();
                    var user = new Dictionary<string, string>()
                {
                    {"username", username },
                    {"password", password}
                };
                    string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = client.PostAsync("https://localhost:7163/Users/authenticate", content);
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var s = result.Content.ReadAsStringAsync().Result;
                        dynamic j = JObject.Parse(s);
                        string token = j.token;
                        TokenLogin.Token = token;
                        Program.FrmMenuModern.CurrentForm = Program.FrmMenuModern.FrmTipoCombustible;
                    }
                    else
                    {
                        MessageBox.Show("Wrong User");
                    }

                }
            }
        }
    }
}
