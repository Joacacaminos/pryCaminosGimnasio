using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCaminosGimnasio
{
    public partial class frmInscripcion : Form
    {
        //Constante


        const decimal PRECIO_MUSCULACION = 15000m;
        const decimal PRECIO_FUNCIONAL = 18000m;
        const decimal PRECIO_NATACION = 22000m;

        const decimal PRECIO_CASILLERO = 3000m;

        const int EDAD_MINIMA = 14;

        const decimal DESCUENTO_MENOR = 0.25m;
        const decimal DESCUENTO_MAYOR = 0.30m;
        const decimal DESCUENTO_ESTUDIANTE = 0.15m;

        const decimal DESCUENTO_EFECTIVO = 0.10m;

        const decimal RECARGO_3_CUOTAS = 0.10m;
        const decimal RECARGO_6_CUOTAS = 0.20m;

        //Socio 
        public struct SOCIO
        {
            public string nombre;
            public int edad;
            public string categoria;
            public string plan;
            public string horario;
            public int meses;
            public string formaPago;
            public decimal total;
            public decimal valorCuota;
        }
        //Constructor

        public frmInscripcion()
        {
            InitializeComponent();
        }

        private void EstadoInicial()
        {
            txtNombre.Text = "";
            txtEdad.Text = "";

            chkEstudiante.Checked = false;
            chkCasillero.Checked = false;


            cboPlan.SelectedIndex = 0;
            cboTurno.SelectedIndex = 0;
            cboCuotas.SelectedIndex = -1;

            rbtEfectivo.Checked = true;
            rbtTarjeta.Checked = false;

            btnCalcular.Enabled = true;

            txtNombre.Focus();
        }

        private void FrmInscripcion_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }
    }
}
