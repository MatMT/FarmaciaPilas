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

        // Constructor principal para nuestro formulario
        public Form1()
        {
            // Inicializamos los componentes y controles
            InitializeComponent();
            InitializeControls();

            // Inicializamos las pilas
            pilaBodega = new PilaCajas();
            pilaCajasVacias = new PilaCajas();

            // Inicializamos nuestro método para indicar que las pilas están vacías
            ActualizarVisualizacion();
        }

        // Método para inicializar los controles
        private void InitializeControls()
        {
            // Preseleccionar combobox
            cmbTipoMedicina1.SelectedIndex = 0;
            cmbTipoMedicina2.SelectedIndex = 0;

            // Asociación de eventos de validación
            txtTotalUnidades.KeyPress += ValidarSoloNumeros;
            txtCantidadRetirar.KeyPress += ValidarSoloNumeros;
        }

        // Evento para capturar el clic en el botón para ingresar medicamentos
        private void btnIngresarLote_Click(object sender, EventArgs e)
        {
            // Encerramos toda nuestra lógica dentro de un try/catch para manejar posibles excepciones
            try
            {
                // Primero nos aseguramos que todos los inputs estén completos
                if (!ValidarInputsCompletos(txtTotalUnidades, cmbTipoMedicina1))
                    return;

                // Obtener valores del Form
                int cantidad = int.Parse(txtTotalUnidades.Text); // convertimos directamente el valor de la cantidad a un número entero
                string tipo = cmbTipoMedicina1.Text; // capturamos el tipo de medicina a ingresar

                // Crear nueva caja con número de serie secuencial
                Caja nuevaCaja = new Caja(contadorSerie++, tipo, cantidad);
                pilaBodega.Push(nuevaCaja); // inmediatamente agregamos la caja a nuestra pila en bodega

                // Actualizar visualización y reestablecer los campos del formulario
                ActualizarVisualizacion();
                LimpiarCamposIngreso();
            }
            catch (Exception ex) // Ante cualquier excepción inesperada
            {
                // Mostrar mensaje de error al usuario
                MessageBox.Show($"Error al ingresar lote: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para capturar el clic del botón para solicitudes de retiro de medicamento
        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            // Nuevamente, encerramos nuestra lógica dentro de un try/catch para manejar posibles excepciones
            try
            {
                // Nos encargamos de validar que los campos NO estén vacíos
                if (!ValidarInputsCompletos(txtCantidadRetirar, cmbTipoMedicina2))
                    return;

                // Obtener valores del Form
                int cantidadSolicitada = int.Parse(txtCantidadRetirar.Text); // convertimos el número capturado a entero
                string tipoSolicitado = cmbTipoMedicina2.Text; // capturamos el tipo de medicina a retirar
                int cantidadFaltante = cantidadSolicitada; // inicializamos la cantidad de medicamento pendiente de retirar como contador auxiliar

                PilaCajas pilaAuxiliar = new PilaCajas(); // creamos una instancia de PilaCajas como nuestro auxiliar

                // En una estructura repetitiva, iteramos mientras que la pila no esté vacía y tengamos unidades pendientes de retirar
                while (!pilaBodega.EstaVacia() && cantidadFaltante > 0)
                {
                    // Temporalmente eliminamos la caja al tope de la fila para capturar su valor
                    // y así poder utilizarlo para la lógica de extracción
                    Caja cajaActual = pilaBodega.Pop();

                    // Verificamos que la caja seleccionada coincida con el tipo de medicina solicitada
                    if (cajaActual.tipomedicina == tipoSolicitado)
                    {
                        // En caso de que sí, validamos si existen unidades suficientes en la caja con respecto a la cantidad pendiente de retirar
                        if (cajaActual.unidades <= cantidadFaltante)
                        {
                            // Si eso se cumple
                            cantidadFaltante -= cajaActual.unidades; // tomamos todas las unidades de la caja
                            cajaActual.unidades = 0; // y explícitamente establecemos las unidades de la caja en cero
                            pilaCajasVacias.Push(cajaActual); // y como la caja quedó vacía, la movemos directamente a la pila de cajas vacías
                        }
                        else
                        {
                            // En caso de que hayan unidades suficientes con respecto a la cantidad pendiente de retirar
                            cajaActual.unidades -= cantidadFaltante; // tomamos solo las unidades necesarias
                            cantidadFaltante = 0; // definimos que ya no hay más unidades del medicamento pendientes de retirar
                            pilaAuxiliar.Push(cajaActual); // al no quedar vacía la caja, la agregamos a la pila de cajas auxiliar
                        }
                    }
                    else // si no coincide el tipo de medicamento
                    {
                        pilaAuxiliar.Push(cajaActual); // enviamos directamente el medicamento a la pila de cajas auxiliar
                    }
                }

                // Devolver cajas de la pila auxiliar a la bodega
                while (!pilaAuxiliar.EstaVacia())
                {
                    pilaBodega.Push(pilaAuxiliar.Pop()); // el valor que vamos eliminando de la pila de cajas auxiliar lo agregamos a la pila de cajas original
                }

                // Actualizar visualización de las pilas
                ActualizarVisualizacion();

                // Mostrar mensaje si no se completó la solicitud
                if (cantidadFaltante > 0)
                {
                    MessageBox.Show($"¡Alerta! El medicamento de Tipo {tipoSolicitado} se agotó en Bodega.\n" +
                                  $"Faltaron {cantidadFaltante} unidades para completar el pedido.",
                                  "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
                else // si no, mostrar mensaje de que la solicitud fue exitosa
                {
                    MessageBox.Show($"Solicitud de medicamentos extraida correctamente.\n" +
                        $"Se han retirado {cantidadSolicitada} unidades del medicamento de Tipo {tipoSolicitado} en Bodega.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // reestablecemos nuestros campos de retiro de medicamento
                LimpiarCamposSolicitud();
            }
            catch (Exception ex) // en caso de que haya ocurrido algún error, lo capturamos
            {
                // y mostramos una alerta de error al usuario
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
            // valores por defecto
            txtTotalUnidades.Clear();
            cmbTipoMedicina1.SelectedIndex = 0;
        }

        // Reestablecer los campos de solicitud de medicamentos
        private void LimpiarCamposSolicitud()
        {
            // valores por defecto
            txtCantidadRetirar.Clear();
            cmbTipoMedicina2.SelectedIndex = 0;
        }

        // Actualizar los datos de la las pilas
        private void ActualizarVisualizacion()
        {
            // simplemente imprimimos nuevamente el contenido de las pilas
            pilaBodega.VerContenido(lstPilaBodega);
            pilaCajasVacias.VerContenido(lstPilaCajasVacias);
        }

        // Aceptar solamente inserción de números por medio de su evento
        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Verificar que los datos de los inputs estén completos
        private bool ValidarInputsCompletos(TextBox txtCantidad, ComboBox cmbTipo)
        {
            // Si los campos no están vacíos, mostramos una alerta

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
