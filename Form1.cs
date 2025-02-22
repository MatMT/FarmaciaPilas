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
        private PilaCajas pilaBodega; // definimos la pila que utilizamos para las cajas de medicamento
        private PilaCajas pilaCajasVacias; // alternativamennte, también tenemos la pila de cajas vacías
        private int contadorSerie = 1; // usaremos un contador para generar los números de serie

        public Form1()
        {
            // Inicializamos los componentes y controles
            InitializeComponent();
            InitializeControls();

            // Inicializamos las pilas
            pilaBodega = new PilaCajas();
            pilaCajasVacias = new PilaCajas();

            ActualizarVisualizacion();
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
                int cantidad = int.Parse(txtTotalUnidades.Text);
                string tipo = cmbTipoMedicina1.Text;

                // Crear nueva caja con número de serie secuencial
                Caja nuevaCaja = new Caja(contadorSerie++, tipo, cantidad);
                pilaBodega.Push(nuevaCaja);

                // Actualizar visualización
                ActualizarVisualizacion();
                LimpiarCamposIngreso();
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
                int cantidadSolicitada = int.Parse(txtCantidadRetirar.Text);
                string tipoSolicitado = cmbTipoMedicina2.Text;
                int cantidadFaltante = cantidadSolicitada;

                PilaCajas pilaAuxiliar = new PilaCajas();

                while (!pilaBodega.EstaVacia() && cantidadFaltante > 0)
                {
                    Caja cajaActual = pilaBodega.Pop();

                    if (cajaActual.Tipomedicina == tipoSolicitado)
                    {
                        if (cajaActual.Unidades <= cantidadFaltante)
                        {
                            // Tomar todas las unidades de la caja
                            cantidadFaltante -= cajaActual.Unidades;
                            cajaActual.Unidades = 0;
                            pilaCajasVacias.Push(cajaActual);
                        }
                        else
                        {
                            // Tomar solo las unidades necesarias
                            cajaActual.Unidades -= cantidadFaltante;
                            cantidadFaltante = 0;
                            pilaAuxiliar.Push(cajaActual);
                        }
                    }
                    else
                    {
                        pilaAuxiliar.Push(cajaActual);
                    }
                }

                // Devolver cajas de la pila auxiliar a la bodega
                while (!pilaAuxiliar.EstaVacia())
                {
                    pilaBodega.Push(pilaAuxiliar.Pop());
                }

                // Actualizar visualización
                ActualizarVisualizacion();

                // Mostrar mensaje si no se completó la solicitud
                if (cantidadFaltante > 0)
                {
                    MessageBox.Show($"¡Alerta! El medicamento de Tipo {tipoSolicitado} se agotó en Bodega.\n" +
                                  $"Faltaron {cantidadFaltante} unidades para completar el pedido.",
                                  "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    MessageBox.Show($"Solicitud de medicamentos extraida correctamente.\n" +
                        $"Se han retirado {cantidadSolicitada} unidades del medicamento de Tipo {tipoSolicitado} en Bodega.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCamposSolicitud();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ingresar lote: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * MÉTODOS AUXILIARES
         */

        // Reestablecer los campos de ingreso de datos
        private void LimpiarCamposIngreso()
        {
            txtTotalUnidades.Clear();
            cmbTipoMedicina1.SelectedIndex = 0;
        }

        // Reestablecer los campos de solicitud de medicamentos
        private void LimpiarCamposSolicitud()
        {
            txtCantidadRetirar.Clear();
            cmbTipoMedicina2.SelectedIndex = 0;
        }

        // Actualizar los datos de la las pilas
        private void ActualizarVisualizacion()
        {
            pilaBodega.VerContenido(lstPilaBodega);
            pilaCajasVacias.VerContenido(lstPilaCajasVacias);
        }

        // Aceptar solamente inserción de números ============================================== |
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
