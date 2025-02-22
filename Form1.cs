using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Analisis de Resultados - Guia 5 - PED104 Grupo 8L
// Oscar Mateo Elias Lopez - EL232710
// Javier Enrique Mejia Flores - MF232724

namespace FarmaciaPilas
{
    public partial class Form1 : Form
    {
        private Caja cajaMedicamento;
        private Caja cajaRetiro;

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Preseleccionar combobox
            cmbTipoMedicina1.SelectedIndex = 0;
            cmbTipoMedicina2.SelectedIndex = 0;

            // Asociación de eventos de validación
            txtTotalUnidades.KeyPress += ValidarSoloNumeros;
            txtCantidadRetirar.KeyPress += ValidarSoloNumeros;
        }

        private void btnIngresarLote_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarInputsCompletos(txtTotalUnidades, cmbTipoMedicina1))
                    return;

                // Obtener valores del Form
                int cantidad = Int32.Parse(txtTotalUnidades.Text);
                string tipo = cmbTipoMedicina1.Text;

                // ID temporal, no sé que vas a implementar xd
                Random rnd = new Random();

                cajaMedicamento = new Caja(rnd.Next(), tipo, cantidad);

                MessageBox.Show($"Cantidad: {cantidad}\nTipo: {tipo}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ingresar lote: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarInputsCompletos(txtCantidadRetirar, cmbTipoMedicina2))
                    return;

                // Obtener valores del Form
                int cantidad = Int32.Parse(txtCantidadRetirar.Text);
                string tipo = cmbTipoMedicina2.Text;

                MessageBox.Show($"Cantidad: {cantidad}\nTipo: {tipo}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ingresar lote: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Aceptar solamente insercción de números ============================================== |
        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarInputsCompletos(TextBox txtCantidad, ComboBox cmbTipo)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese una Cantidad", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cmbTipo.Text))
            {
                MessageBox.Show("Seleccione un tipo de medicina", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
