using Newtonsoft.Json;
using RentCar.Models;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar_UI

{
    public partial class FrmCreateCombustible : Form
{
    public FrmCreateCombustible()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var fuelType = new TipoCombustible();
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenLogin.Token);

        fuelType.Descripcion = textBox1.Text;
        string json = JsonConvert.SerializeObject(fuelType, Formatting.Indented);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = client.PostAsync("https://localhost:7163/api/TipoCombustibles", content);
        var result = response.Result;
        MessageBox.Show(result.StatusCode.ToString());
        Close();
    }
}
}