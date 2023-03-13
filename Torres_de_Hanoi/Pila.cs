using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Pila
    {
        //Campos y Propiedades
        public int Size { get; set; }
        public int Top { get; set; }
        public List<Disco> Elementos { get; set; }
        //----------------------------------------------------------------------------------------------
        //Constructores
        public Pila()
        {
            Size = 0;
            Elementos = new List<Disco>();
            Top = 0;
        }
        public Pila(int Size)
        {
            this.Size = Size;
            Elementos = new List<Disco>();
            Top = -1;

            for (int i = this.Size; i > 0; i--)
            {
                Elementos.Add(new Disco(i));
                Top = Elementos.Last().Valor;
            }
        }
        //----------------------------------------------------------------------------------------------
        //Metodo push()
        public void push(Disco d)
        {
            try {
                Elementos.Add(d);
                Top = Elementos.Last().Valor;
            }
            catch(System.IO.IOException e) {
                Console.WriteLine("Error: "+e);
            }
        }
        //----------------------------------------------------------------------------------------------
        //Metodo pop()
        public Disco pop()
        {
            Disco d = Elementos.Last();
            Elementos.Remove(d);
            try
            {
                Top = Elementos.Last().Valor;
            }
            catch (Exception)
            {
                Top = 0;
            }
            return d;
        }
        //----------------------------------------------------------------------------------------------
        //Metodo isEmpty()
        public bool isEmpty()
        {
            if (this.Elementos.Count.Equals(0)) {
                return true;
            }
            return false;
        }

    }
}
