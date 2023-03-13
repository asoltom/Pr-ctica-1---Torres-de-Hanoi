using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        public int movimientos { get; set; }
        public Hanoi()
        {
            movimientos = 0;
        }
        /*TODO: Implementar métodos*/
        public void mover_disco(Pila a, Pila b)
        {
            //Si no hay nada en la Pila a
            if (a.Top == 0)
            {
                if (b.Top > 0)
                {
                    a.push(b.pop());
                }
            }
            //Si no hay nada en la Pila b
            else if (b.Top == 0)
            {
                if (a.Top > 0)
                {
                    b.push(a.pop());
                }
            }
            //Si el disco más alto de la pila a es menor que el de b
            else if (a.Top < b.Top)
            {
                b.push(a.pop());
            }
            //Si es el de b menor que el de a
            else
            {
                a.push(b.pop());
            }
        }
        //--------------------------------------------------------------------------------------------
        //Entradas: N: n,ini,fin,aux
        //Salida:   N: movimientos
        //--------------------------------------------------------------------------------------------
        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            /*
            si n es impar:
                mientras no haya solución:
                    incrementar movimientos(m) ← mover disco(INI, FIN)
                    incrementar movimientos(m) ← mover disco(INI, AUX)
                    incrementar movimientos(m) ← mover disco(AUX, FIN)
                fin mientras
            fin si
            si n es par:
                mientras no haya solución:
                    incrementar movimientos(m) ← mover disco(INI, AUX)
                    incrementar movimientos(m) ← mover disco(INI, FIN)
                    incrementar movimientos(m) ← mover disco(AUX, FIN)
                fin mientras
            fin si
            devuelve m
             */
            mostrarEstado(movimientos, ini, aux, fin);
            if (n == 1)
            {
                mover_disco(ini, fin);
                movimientos++;
                mostrarEstado(movimientos, ini, aux, fin);
            }
            else if (n % 2 != 0)
            {
                do
                {
                    mover_disco(ini, fin);
                    movimientos++;
                    mostrarEstado(movimientos, ini, aux, fin);

                    if (fin.Elementos.Count.Equals(n) && ini.isEmpty() == true)
                    {
                        break;
                    }

                    mover_disco(ini, aux);
                    movimientos++;
                    mostrarEstado(movimientos, ini, aux, fin);


                    if (fin.Elementos.Count < n)
                    {
                        mover_disco(aux, fin);
                        movimientos++;
                        mostrarEstado(movimientos, ini, aux, fin);
                    }
                } while (fin.Elementos.Count < n);
            }
            else
            {
                do
                {
                    mover_disco(ini, aux);
                    movimientos++;
                    mostrarEstado(movimientos, ini, aux, fin);
                    if (fin.Elementos.Count < n)
                    {
                        mover_disco(ini, fin);
                        movimientos++;
                        mostrarEstado(movimientos, ini, aux, fin);
                        mover_disco(aux, fin);
                        movimientos++;
                        mostrarEstado(movimientos, ini, aux, fin);
                    }
                } while (fin.Elementos.Count < n);
            }
            return movimientos;
        }
        //--------------------------------------------------------------------------------------------
        //Entradas: N: movimientos, ini, fin, aux
        //Salida:   Void
        //--------------------------------------------------------------------------------------------
        public void mostrarEstado(int movimientos, Pila ini, Pila aux, Pila fin)
        {
            if (movimientos == 0) { Console.WriteLine("Situación inicial"); }
            else { Console.WriteLine("Situación tras el movimiento " + movimientos); }
            Console.WriteLine("Torre INI: " + recorrerPila(ini)); ;
            Console.WriteLine("Torre AUX: " + recorrerPila(aux)); ;
            Console.WriteLine("Torre FIN: " + recorrerPila(fin)); ;
            Console.WriteLine("");
        }
        //--------------------------------------------------------------------------------------------
        //Entradas: Pila: pila
        //Salida:   String: res
        //--------------------------------------------------------------------------------------------
        public string recorrerPila(Pila pila)
        {
            string res = "";
            for (int i = 0; i < pila.Elementos.Count; i++)
            {
                res += (pila.Elementos[i].Valor);
                if (!(i + 1 == pila.Elementos.Count)) { res += ", "; } //Si la 'i' siguiente ya es la final, no hace falta poner una coma para separar
            }

            return res;
        }
        //--------------------------------------------------------------------------------------------
        //Entradas: N: n, ini, fin, aux
        //Salida:   N: movimientos
        //--------------------------------------------------------------------------------------------
        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {
            /*
            3: si n = 1:
                4: incrementar movimientos(m) ← mover disco(INI, F IN)
            5: sino:
                6: algoritmo recursivo(n − 1, INI, AUX, F IN)
                7: incrementar movimientos(m) ← mover disco(INI, F IN)
                8: algoritmo recursivo(n − 1, AUX, F IN, INI)
            9: fin si
            10: devuelve m
             */
            if (n == 1)
            {
                mostrarEstado(movimientos, ini, aux, fin);
                mover_disco(ini, fin);
                movimientos++;
                mostrarEstado(movimientos, ini, aux, fin);
            }
            else
            {
                mostrarEstado(movimientos, ini, aux, fin);
                recursivo(n - 1, ini, aux, fin);
                mover_disco(ini, fin);
                movimientos++;
                recursivo(n - 1, aux, fin, ini);
            }
            return movimientos;
        }
    }
}