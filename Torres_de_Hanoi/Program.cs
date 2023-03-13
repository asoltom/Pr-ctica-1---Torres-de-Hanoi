using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Program
    {
        /*static void Main(string[] args)
        {
            Console.WriteLine("El Gran Juego de las Torres de Hanoi");
            Console.WriteLine("");
            Console.WriteLine("3 torres");
            Console.WriteLine("");

            int valorError = -1;
            Console.WriteLine("Indica el número de discos...");
            String valor=Console.ReadLine();
            bool convert = int.TryParse(valor, out valorError);
            if (convert == true && valor != null)
            {
                Console.WriteLine("Has seleccionado " + valor + " discos");
                Console.WriteLine("");

                String respuestaMetodo = null;
                do
                {
                    Console.WriteLine("Indica I para Iterativo o R para Recursivo...");
                    respuestaMetodo = Console.ReadLine();
                } while (respuestaMetodo != @"I" || respuestaMetodo != @"R");

                Console.WriteLine("Has seleccionado el método " + respuestaMetodo);
                Console.WriteLine("");
                if (respuestaMetodo == "I")
                {

                }
                else
                {

                }
            }
            else {
                Console.WriteLine("");
                Console.WriteLine("Introduce un valor numérico");
            }
            //----------
            //Fin del Programa
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        */
        static void Main(string[] args)
        {
            bool run = false;
            Console.WriteLine("El Gran Juego de las Torres de Hanoi.");
            Console.WriteLine("3 torres");
            Console.WriteLine("Pulse 'I' si quiere usar el modo iterativo o 'R' si quiere usar el modo recursivo.");
            do
            {
                String modoString = Console.ReadLine();
                if (modoString == "I") { modoString = "1"; }
                else if (modoString == "R") { modoString = "2"; }

                if (Int32.TryParse(modoString, out int modo))
                {
                    switch (modo)
                    {
                        case 1:
                            Console.WriteLine("Se ha elejido el modo iterativo");
                            Console.WriteLine("Ahora elija con cuantos discos quiere hacer el puzle.");
                            Console.WriteLine("El programa le mostrara cuantos movimientos hacen falta para resolver el puzle.");
                            do
                            {
                                String stringDiscos = Console.ReadLine();
                                if (Int32.TryParse(stringDiscos, out int discos))
                                {
                                    if (discos <= 0)
                                    {
                                        Console.WriteLine("No se admiten numeros menores o igual a 0.");
                                    }
                                    else
                                    {
                                        Pila ini = new Pila(discos);
                                        Pila aux = new Pila();
                                        Pila fin = new Pila();
                                        Hanoi hanoi = new Hanoi();

                                        int movimientos = hanoi.iterativo(discos, ini, fin, aux);
                                        Console.WriteLine("Resuelto en " + movimientos + " movimientos");
                                        run = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No se admiten palabras, intruduzca de manera numerica el numero de discos que quiere.");
                                }
                            } while (!run);

                            break;
                        case 2:
                            Console.WriteLine("Se ha elejido el modo recursivo");
                            Console.WriteLine("Ahora elija con cuantas discos quiere hacer el puzle.");
                            Console.WriteLine("El programa el mostrara cuantos movimientos hacen falta para resolver el puzle.");
                            do
                            {
                                String stringDiscos = Console.ReadLine();
                                if (Int32.TryParse(stringDiscos, out int discos))
                                {
                                    if (discos <= 0)
                                    {
                                        Console.WriteLine("No se admiten numeros menores o igual a 0.");
                                    }
                                    else
                                    {
                                        Pila ini = new Pila(discos);
                                        Pila aux = new Pila();
                                        Pila fin = new Pila();
                                        Hanoi hanoi = new Hanoi();

                                        int movimientos = hanoi.recursivo(discos, ini, fin, aux);
                                        Console.WriteLine("Resuelto en " + movimientos + " movimientos");
                                        run = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Intruduzca únicamente el número de discos que quiere.");
                                }
                            } while (!run);
                            break;
                        default:
                            Console.WriteLine("Por favor, escriba 'I' para modo iterativo o 'R' para modo recursivo.");
                            break;
                    } // switch(modo)
                } // if() selección del modo
                else
                {
                    Console.WriteLine("Pulse 'I' si quiere usar el modo iterativo o 'R' si quiere usar el modo recursivo.");
                }
                if (run)
                {
                    Console.WriteLine("¿Quiere probar otra vez? Pulse 1. Por el contrario, pulse 0 para salir.");
                    int rerun = -1;
                    do
                    {
                        String rerunString = Console.ReadLine();
                        if (Int32.TryParse(rerunString, out int x))
                        {
                            rerun = x;
                            switch (rerun)
                            {
                                case 0:
                                    Console.WriteLine("Gracias por jugar");
                                    Console.ReadLine();
                                    break;
                                case 1:
                                    Console.WriteLine("Perfecto, pulse 'I' si quiere usar el modo iterativo o 'R' si quiere usar el modo recursivo");
                                    run = false;
                                    break;
                                default:
                                    Console.WriteLine("No se admiten mas opciones, 1 para seguir, 0 para salir");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se admiten palabras, intruduzca de manera numerica lo que quiere hacer a continuación.");
                        }
                    } while (rerun != 1 && rerun != 0);
                }
            } while (!run);
        }
    }
}
