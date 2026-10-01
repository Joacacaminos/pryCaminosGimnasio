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

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
