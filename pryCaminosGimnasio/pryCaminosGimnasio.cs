using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCaminosGimnasio
{
    public partial class frmInscripcion : Form
    {
        // Precio por mes
        const decimal Precio_Musculacion = 15000m;
        const decimal Precio_Funcional = 18000m;
        const decimal Precio_Natacion = 22000m;
        const decimal Precio_Casillero = 3000m;

        // edad y cant de meses
        const int Edad_Minima = 14;
        const int Edad_Menor = 18;
        const int Edad_Jubilado = 65;
        const int Meses_Min = 1;
        const int Meses_Max = 12;

        // Porcentajes (o.25m = 25%)
        const decimal Desc_Menor = 0.25m;
        const decimal Desc_Jubilado = 0.30m;
        const decimal Desc_Estudiante = 0.15m;
        const decimal Desc_Efectivo = 0.10m;
        const decimal Recargo_3_Cuotas = 0.10m;
        const decimal Recargo_6_Cuotas = 0.20m;

        public frmInscripcion()
        {
            InitializeComponent();
        }

        private void EstadoInicial()
        {
            txtNombre.Clear();
            txtEdad.Clear();
            txtMeses.Text = "1";
            chkEstudiante.Checked = false;
            chkCasillero.Checked = false;
            cboPlan.SelectedIndex = 0;
            cboTurno.SelectedIndex = 0;
            rbtEfectivo.Checked = true;
            cboCuotas.SelectedIndex = -1;
            cboCuotas.Enabled = false;
            txtNombre.Focus();
        }

        private void FrmInscripcion_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int Edad = int.Parse(txtEdad.Text);
            int Meses = int.Parse(txtMeses.Text);
            decimal precioMensual = 0m;
            decimal subtotal = 0m;
            decimal porcdescuento = 0m;
            decimal porcAjustePago = 0m;
            decimal total = 0m;
            decimal valorCuota = 0m;

            if (Edad < Edad_Minima)
            {
                MessageBox.Show("Para Inscribirse hay que tener al menos" + Edad_Minima + "años");
                return;
            }
            if (Meses < Meses_Min || Meses > Meses_Max)
            {
                MessageBox.Show("Los Meses deben estar entre" + Meses_Min + " y " + Meses_Max + ".");
                return;
            }

            String PLAN = cboPlan.Text;
            switch (PLAN)
            {
                case "Musculación":
                    precioMensual = Precio_Musculacion;
                    break;
                case "Funcional":
                    precioMensual = Precio_Funcional;
                    break;
                case "Natación":
                    precioMensual = Precio_Natacion;
                    break;
                default:
                    MessageBox.Show("Plan Invalido.");
                    return;
            }
            int turno = cboTurno.SelectedIndex;
            string horario = "";
            switch (turno)
            {
                case 0:
                    horario = "Mañana (7 a 12 h)";
                    break;
                case 1:
                    horario = "Tarde (14 a 18 h)";
                    break;
                case 2:
                    horario = "Noche (18 a 23 h)";
                    break;
                default:
                    horario = "Sin Turno";
                    break;

            }
            //MessageBox.Show(PLAN + "-" + precioMensual + "-" + horario);

            if (chkCasillero.Checked)
            {
                precioMensual += Precio_Casillero;
            }
            subtotal = precioMensual * Meses;


            if (Edad < Edad_Menor)
            {
                porcdescuento = Desc_Menor;
            }
            else
            {
                if (Edad >= Edad_Jubilado)
                {
                    porcdescuento = Desc_Jubilado;
                }
                else
                {
                    if (chkEstudiante.Checked)
                    {
                        porcdescuento = Desc_Estudiante;
                    }
                    else
                    {
                        porcdescuento = 0m;
                    }
                }
            }
            total = subtotal - (subtotal * porcdescuento);
           // MessageBox.Show(subtotal + "-" + porcdescuento + "-" + total);
        }   


        private void SoloDígitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtEdad.Text != "" && txtMeses.Text != "")
            {
                btnCalcular.Enabled = true;
            }
            else
            {
                btnCalcular.Enabled = false;
            }
        }
    }
}
            
    

