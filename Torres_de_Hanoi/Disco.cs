using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Disco
    {
        //Decidir tipo de Valor
        public int Valor { get; set; }
        //Constructor Vacio
        public Disco() { }

        //Constructor Disco
        public Disco(int Valor)
        {
            this.Valor = Valor;
        }
    }
}
