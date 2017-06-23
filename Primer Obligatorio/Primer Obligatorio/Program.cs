﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int apostadores = 0;
            string[] nombres = new string[0];
            int[,] apuestas = new int[0, 0];
            //int ultimoapostado = 0;
            int posicionlibre = 0;
            int opcion = 0;
            bool ejecutando = true;
            while (ejecutando)
            {
                MostrarMenu(apostadores);
                bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                if (!esnumero)
                {
                    Console.Write("La opción ingresada no es válida.");
                    Console.ReadLine();
                }

                switch (opcion)
                {
                    case 1:
                        apostadores = CantidadClientes(ref apostadores, ref nombres, ref apuestas);
                        break;
                    case 2:
                        Apuesta(ref posicionlibre, ref nombres, ref apuestas);
                        break;
                    case 3:
                        ApuestaSorpresa(ref posicionlibre, ref nombres, ref apuestas);
                        break;
                    case 4:
                        EliminaApuesta(ref nombres, ref apuestas);
                        break;
                    case 5:
                        Listado(ref nombres, ref apuestas, ref posicionlibre);
                        break;
                    case 6:
                        ejecutando = false;
                        break;
                    default:
                        MostrarMenu(apostadores);
                        break;
                }
            }
        }

        public static void MostrarMenu(int apostadores)
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("               5 de Oro");
            //Console.WriteLine("\n            733555555533352535555347             \n            7455555557575757575757553             \n            6877777777777777777777775             \n            8377777723253294449422243             \n            277777778866688888886689              \n            27777777                              \n            87 77777                              \n           58  77 77                              \n           68     77  7777777777                  \n           95                   777               \n           57                      7              \n                    7206695         7             \n            7  77728695346865        7            \n           4888883          777       7           \n                             77       7           \n                              7       7           \n                               7 7 7  7           \n         777777777            377777777           \n         577777777           7777777777           \n         75777777777         777777777            \n          757777777777777777777777775             \n           5577777777777577777777725              \n            74427777777777777775407               \n              3888935777552468867                 \n                 7368888888827      ");
            Console.WriteLine("\n****************************************** \n");
            Console.WriteLine("   1 - Ingresar la cantidad de clientes    " + apostadores);
            Console.WriteLine("   2 - Ingresar apuesta");
            Console.WriteLine("   3 - Ingresar apuesta sorpresa");
            Console.WriteLine("   4 - Eliminar apuesta");
            Console.WriteLine("   5 - Listados");
            Console.WriteLine("   6 - Salir\n");
            Console.WriteLine("******************************************");
            Console.Write("Ingrese la opción deseada: ");
        }

        public static int CantidadClientes(ref int apostadores, ref string[] nombres, ref int[,] apuestas)
        {
            Console.Clear();

            if (apostadores != 0)
            {
                Console.Write("La cantidad de apostadores ya fue ingresada. \n¿Desea borrar las apuestas ya ingresadas e ingresar un nuevo número de apostadores? (S/N): ");
                string respuesta = Console.ReadLine();
                if (respuesta == "S")
                {
                    Console.Write("Ingrese la cantidad de apostadores: ");
                    apostadores = Convert.ToInt32(Console.ReadLine());
                    nombres = new string[apostadores];
                    apuestas = new int[apostadores, 5];
                    //ultimoapostado = 0;
                    return apostadores;
                }
                else
                {
                    return apostadores;
                }
            }
            else
            {
                Console.Write("Ingrese la cantidad de apostadores: ");
                apostadores = Convert.ToInt32(Console.ReadLine());
                nombres = new string[apostadores];
                apuestas = new int[apostadores, 5];
                return apostadores;
            }
        }



        public static void Apuesta(ref int posicionlibre, ref string[] nombres, ref int[,] apuestas)
        {
            Console.Clear();

            posicionlibre = PosicionLibre(nombres);

            if (posicionlibre == nombres.Length)
            {
                Console.WriteLine("Ya se ha alcanzado el número máximo de apostadores");
                Console.ReadLine();
            }

            else
            {
                bool ejecutando = true;
                while (ejecutando)
                {
                    //bool nombrerepetido = false;
                    Console.Write("Ingrese el nombre del apostador: ");
                    string nombre = Console.ReadLine();

                    if (nombrerepetido(nombres, nombre) == true)
                    {
                        Console.WriteLine("El nombre ingresado ya existe en el listado de apostadores.\n");
                    }

                    else
                    {
                        nombres[posicionlibre] = nombre;
                        for (int i = 0; i < 5; i++)
                        {
                            bool esnumero = false;
                            while (!esnumero)
                            {
                                Console.Write("\nIngrese el {0}º valor de la apuesta: ", i + 1);
                                esnumero = Int32.TryParse(Console.ReadLine(), out apuestas[posicionlibre, i]);
                                if (!esnumero)
                                {
                                    Console.WriteLine("\nLa opción ingresada no es válida.");
                                }
                                else if (apuestas[posicionlibre, i] < 1 || apuestas[posicionlibre, i] > 49)
                                {
                                    Console.WriteLine("\nLa opción ingresada no es válida.");
                                    i--;
                                }
                            }
                        }
                        //ultimoapostado++;
                        ejecutando = false;
                    }
                }
            }
        }


        public static void ApuestaSorpresa(ref int posicionlibre, ref string[] nombres, ref int[,] apuestas)
        {
            Console.Clear();

            posicionlibre = PosicionLibre(nombres);

            Console.Write("Ingrese el nombre del apostador: ");

            //falta validar si el nombre no esta escrito en otro campo y que sea tengo tope por cantidad de apuestas

            nombres[posicionlibre] = Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {
                Random variable = new Random();
                apuestas[posicionlibre, i] = variable.Next(1, 49);
                System.Threading.Thread.Sleep(10);
            }

            //ultimoapostado++;

            Console.WriteLine("Apuesta ingresada con éxito");
            Console.ReadKey();
        }

        public static void EliminaApuesta(ref string[] nombres, ref int[,] apuestas)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del apostador cuya apuesa desea borrar: ");

            string nombreborrar = Console.ReadLine();

            int posicion = 0;
            int i = 0;
            bool encontrado = false;
            while (!encontrado && i < nombres.Length)
            {
                if (nombreborrar == nombres[i])
                {
                    posicion = i;
                    encontrado = true;

                }
                else
                {
                    i++;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("El nombre ingresado no se encuentra en el listado");
                Console.ReadLine();
            }
            else
            {





        }





        public static void Listado(ref string[] nombres, ref int[,] apuestas, ref int posicionlibre)
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("            Listados");
            Console.WriteLine("****************************************** \n");
            Console.WriteLine("   1 - Numeros de un apostador");
            Console.WriteLine("   2 - Listado completo de apuestas");
            Console.WriteLine("   3 - Numeros que no han tenido apuestas");
            Console.WriteLine("   4 - Salir\n");
            Console.WriteLine("******************************************");
            Console.Write("Ingrese la opción deseada: ");

            int opcion = 0;
            bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

            if (!esnumero)
            {
                Console.Write("La opción ingresada no es válida.");
                Console.ReadLine();
            }

            switch (opcion)
            {
                case 1:
                    NumerosDeApostador(ref nombres, ref apuestas);
                    break;
                case 2:
                    ListadoCompletoApuestas(ref nombres, ref apuestas);
                    break;
                case 3:
                    // NumerosSinApuestas();
                    break;
                case 4:
                    //;
                    break;
                default:
                    //;
                    break;
            }
        }

        public static void NumerosDeApostador(ref string[] nombres, ref int[,] apuestas)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del apostador");
            string nombrebuscado = Console.ReadLine();
            //falta validar si el nombre no está

            bool buscando = true;
            int i = 0;
            while (buscando)
            {
                if (nombres[i] == nombrebuscado)
                {
                    buscando = false;
                    Console.WriteLine("Las apuestas de {0} son:", nombres[i]);
                    for (int j = 0; j < apuestas.GetLength(1); j++)
                    {
                        Console.Write("{0},", apuestas[i, j]);
                    }
                }
                else
                {
                    if (i == nombres.Length)
                    {
                        buscando = false;
                        Console.WriteLine("El se ha encontrado el apostado ingresado");
                    }
                    else
                    {
                        i++;
                    }
                }

            }
            Console.ReadKey();
        }


        public static void ListadoCompletoApuestas(ref string[] nombres, ref int[,] apuestas)
        {
            Console.Clear();
            for (int k = 0; k < nombres.Length; k++)
            {
                if ((nombres[k] != null) && (nombres[k] != ""))
                {   
                        Console.WriteLine(nombres[k], ":\t");

                        for (int j = 0; j < apuestas.GetLength(1); j++)
                        {
                            Console.Write("\t " + apuestas[k, j]);
                        }
                        Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        public static int PosicionLibre(string[] nombres)
        {
            int posicionlibre = 0;
            bool encontrado = false;
            int i = 0;
            while (!encontrado && i < nombres.Length)
            {
                if (nombres[i] == "" || nombres[i] == null)
                {
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }
            posicionlibre = i;
            return posicionlibre;
        }

        public static bool nombrerepetido(string[] nombres, string nombre)
        {
            bool resultado = false;
            int i = 0;

            while (!resultado && i<nombres.Length)
            {
                if (nombre == nombres[i])
                {
                    resultado = true;
                }
                else
                {
                    i++;
                }
            }
            return resultado;
        }
    }
}
