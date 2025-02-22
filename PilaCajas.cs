using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void VerContenido()
        {
            Caja aux; // permite hacer recorrido de nodos almacenados
            if (EstaVacia())
                Console.WriteLine("\nPila no tiene nodos almacenados");
            else
            {
                // puntero auxiliar se fija en nodo al inicio de pila
                aux = tope;
                Console.Write("\nPila tiene {0} nodos: \n(tope) ", totnodos);

                do
                {
                    Console.Write("-> {0} ", aux.Tipomedicina);
                    aux = aux.Sgte;
                } while (aux != null);
            }
        }

        // Metodos que implementan algoritmo LIFO
        // para almacenamiento de nodos en una Pila
        public void Push(Caja nuevo)
        {
            // Realiza copia de información del nodo recibido a un nuevo objeto local
            Caja temp = new Caja(nuevo.Noserie, nuevo.Tipomedicina, nuevo.Unidades);

            // Se inserta este nuevo objeto en contenido de pila
            if (EstaVacia())
                temp.Sgte = null;
            else
                temp.Sgte = tope;

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
                tope = tope.Sgte;
                aux.Sgte = null;
                totnodos--;
                return aux; // retorna referencia a nodo extraido de pila
            }
        }
    }
}
