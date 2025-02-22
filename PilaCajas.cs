using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

// Analisis de Resultados - Guia 5 - PED104 Grupo 8L
// Oscar Mateo Elias Lopez - EL232710
// Javier Enrique Mejia Flores - MF232724

namespace FarmaciaPilas
{
    internal class PilaCajas
    {
        // Campos
        Caja tope;
        int totnodos = 0;

        // métodos
        private void InicializarCampos()
        {
            tope = null;
            totnodos = 0;
        }

        public PilaCajas()
        {
            InicializarCampos();
        }

        // método de propiedad de solo lectura
        public int TotNodos()
        {
            return this.totnodos;
        }

        // indica si pila tiene o no nodos almacenados
        public bool EstaVacia()
        {
            if (tope == null) return true;
            else return false;
        }

        // imprime contenido de nodos almacenados en pila
        public void VerContenido(ListBox lstContenido)
        {
            lstContenido.Items.Clear(); // limpiamos los ítems existentes del list box
            Caja aux; // permite hacer recorrido de nodos almacenados
            if (EstaVacia())
                lstContenido.Items.Add("NO HAY CAJAS EN LA PILA");
            else
            {
                // puntero auxiliar se fija en nodo al inicio de pila
                aux = tope;

                do
                {
                    lstContenido.Items.Add($"[{aux.noserie}]. ( Tipo {aux.tipomedicina} ) {aux.unidades} unidades");
                    aux = aux.sgte;
                } while (aux != null);
            }
        }

        // Metodos que implementan algoritmo LIFO
        // para almacenamiento de nodos en una Pila
        public void Push(Caja nuevo)
        {
            // Realiza copia de información del nodo recibido a un nuevo objeto local
            Caja temp = new Caja(nuevo.noserie, nuevo.tipomedicina, nuevo.unidades);

            // Se inserta este nuevo objeto en contenido de pila
            if (EstaVacia())
                temp.sgte = null;
            else
                temp.sgte = tope;

            // nuevo nodo es ultimo ingresado en pila
            tope = temp;
            this.totnodos++; // incrementa conteo nodos almacenados
        }

        public Caja Pop()
        {
            // almacena referencia a nodo a extraer de pila
            Caja aux;

            if (EstaVacia())
                return null; // indica que no hay ningun nodo en pila
            else
            {
                aux = tope;
                //tope se mueve al prox. nodo (si existe) en pila
                tope = tope.sgte;
                aux.sgte = null;
                totnodos--;
                return aux; // retorna referencia a nodo extraido de pila
            }
        }
    }
}
