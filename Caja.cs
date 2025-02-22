using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaPilas
{
    internal class Caja
    {
        // Atributos
        int noserie;
        string tipomedicina;
        int unidades;
        // puntero a otro objeto de esta misma clase
        Caja sgte;

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

        // métodos de propiedad (get, set)
        public int Noserie
        {
            get
            {
                return this.noserie;
            }

            set
            {
                this.noserie = value;
            }
        }

        public string Tipomedicina
        {
            get
            {
                return this.tipomedicina;
            }

            set
            {
                this.tipomedicina = value;
            }
        }

        public int Unidades
        {
            get
            {
                return this.unidades;
            }

            set
            {
                this.unidades= value;
            }
        }

        public Caja Sgte
        {
            get
            {
                return this.sgte;
            }

            set 
            { 
                this.sgte = value; 
            }
        }
    }
}
