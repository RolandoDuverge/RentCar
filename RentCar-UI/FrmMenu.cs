    using RentCar.Models;
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
    public partial class FrmMenu : Form
    {
        public FrmBase<TipoCombustible> FrmTipoCombustible;
        private FrmBase<TipoVehiculo> FrmTipoVehiculo;
        private FrmBase<MarcaVehiculo> FrmMarcaVehiculo;
        private FrmBase<Vehiculo> FrmVehiculo;
        private FrmBase<Cliente> FrmCliente;
        private FrmLogin FrmLogin;

        private Form _currentform;
        public Form CurrentForm
        {
            get => _currentform;
            set
            {
                if (_currentform is not null)
                {
                    _currentform.Hide();
                }
                _currentform = value;
                _currentform.Show();
            }
        }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public FrmMenu()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            InitializeComponent();
            FrmTipoCombustible = new FrmBase<TipoCombustible>(apiUrl: "https://localhost:7163/api/TipoCombustibles", title: "Tipos de Combustible");
            FrmTipoVehiculo = new FrmBase<TipoVehiculo>(apiUrl: "https://localhost:7163/api/TipoVehiculos", title: "Tipos de Vehiculos");
            FrmMarcaVehiculo = new FrmBase<MarcaVehiculo>(apiUrl: "https://localhost:7163/api/MarcaVehiculos", title: "Marcas de Vehiculos");
            FrmVehiculo = new FrmBase<Vehiculo>(apiUrl: "https://localhost:7163/api/Vehiculos", title: "Vehiculos");
            FrmCliente = new FrmBase<Cliente>(apiUrl: "https://localhost:7163/api/Clientes", title: "Clientes");
            FrmLogin = new FrmLogin();

            MakeInlineForm(FrmLogin);
            MakeInlineForm(FrmTipoCombustible);
            MakeInlineForm(FrmTipoVehiculo);
            MakeInlineForm(FrmMarcaVehiculo);
            MakeInlineForm(FrmVehiculo);
            MakeInlineForm(FrmCliente);
        }

        private void MakeInlineForm(Form f)
        {
            f.TopLevel = false;
            Controls.Add(f);
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
        }

        private void tiposDeCombustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = FrmTipoCombustible;
        }

        private void tiposDeAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = FrmTipoVehiculo;
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = FrmMarcaVehiculo;
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = FrmVehiculo;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = FrmCliente;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = FrmLogin;
        }
    }
}
