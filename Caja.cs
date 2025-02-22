using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Analisis de Resultados - Guia 5 - PED104 Grupo 8L
// Oscar Mateo Elias Lopez - EL232710
// Javier Enrique Mejia Flores - MF232724

namespace FarmaciaPilas
{
    internal class Caja
    {
        // Atributos públicos
        public int noserie;
        public string tipomedicina;
        public int unidades;
        public Caja sgte; // puntero a otro objeto de esta misma clase

        // Metodos:
        private void InicializarCampos()
        {
            // inicializa campos con valores indicados
            // en diagrama UML de clases
            noserie = 0;
            tipomedicina = "A";
            unidades = 0;
            sgte = null;
        }

        public Caja() // constructor
        {
            InicializarCampos();
        }

        // sobrecarga de constructor
        public Caja(int noserie, string tipomedicina, int unid)
        {
            InicializarCampos();
            this.noserie = noserie;
            this.tipomedicina = tipomedicina;
            this.unidades = unid;
        }
    }
}
