using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Primer_Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            int apostadores = 0;
            string[] nombres = new string[0];
            int[,] apuestas = new int[0, 0];
            MostrarMenu(apostadores, nombres, apuestas);
        }

        public static void MostrarMenu(int apostadores, string[] nombres, int[,] apuestas)
        {
            int opcion = 0;
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("****************************************** \n");
                Console.WriteLine("   1 - Ingresar la cantidad de clientes    " + apostadores);
                Console.WriteLine("   2 - Ingresar apuesta");
                Console.WriteLine("   3 - Ingresar apuesta sorpresa");
                Console.WriteLine("   4 - Eliminar apuesta");
                Console.WriteLine("   5 - Listados");
                Console.WriteLine("   6 - Salir\n");
                Console.WriteLine("******************************************");
                Console.Write("Ingrese la opción deseada: ");

                bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                if (!esnumero)
                {
                    Console.Write("La opción ingresada no es válida.");
                    Console.ReadLine();
                }

                switch (opcion)
                {
                    case 1:
                        apostadores = CantidadClientes(apostadores, nombres, apuestas);
                        break;
                    case 2:
                        //Apuesta();
                        break;
                    case 3:
                        // ApuestaSorpresa();
                        break;
                    case 4:
                        //EliminaApuesta();
                        break;
                    case 5:
                        // Listado();
                        break;
                    case 6:
                        ejecutando = false;
                        break;
                    default:
                        MostrarMenu(apostadores, nombres, apuestas);
                        break;
                }
            }
        }


        public static int CantidadClientes(int apostadores, string[] nombres, int[,] apuestas)
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



        public static void Apuesta()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del apostador");

        }

        /*

        public static void ApuestaSorpresa()
        {
        }

        public static void EliminaApuesta()
        {
        }

        public static void Listado()
        {
        }
        */

        
    }
}