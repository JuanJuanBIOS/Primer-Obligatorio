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
            int opcion = 0;
            bool esnumero = false;
            int cantidadclientes = 0;
            while (!esnumero)
            {
                MostrarPantalla();

                esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                if (!esnumero)
                {
                    Console.Write("La opción ingresada no es válida.");
                    Console.ReadLine();
                }

                switch (opcion)
                {
                    case 1:
                        CantidadClientes(ref cantidadclientes);
                        String[] apostadores = new String[cantidadclientes];
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
                }
            }
        }

        public static void MostrarPantalla()
        {
            Console.Clear();
            Console.WriteLine("****************************************** \n");
            Console.WriteLine("   1 - Ingresar la cantidad de clientes");
            Console.WriteLine("   2 - Ingresar apuesta");
            Console.WriteLine("   3 - Ingresar apuesta sorpresa");
            Console.WriteLine("   4 - Eliminar apuesta");
            Console.WriteLine("   5 - Listados");
            Console.WriteLine("   6 - Salir\n");
            Console.WriteLine("******************************************");
            Console.Write("Ingrese la opción deseada: ");
        }


        public static void CantidadClientes()

        public static void CantidadClientes(ref int cantidadclientes)
        {
            //Pasa el entero de cantidad de clientes por referencia. Si fue cargado previamente, advierte al ususario que se ha eliminado. Tal vez agregar una pregunta para esto?

            Console.Clear();

            if (cantidadclientes != 0)
            {
                Console.WriteLine("Los valores de apuestas han sido eliminados");
            }

            Console.WriteLine("Ingrese la cantidad de apuestas");
            bool esnumero = Int32.TryParse(Console.ReadLine(), out cantidadclientes);
            Console.WriteLine("Se ingresaran {0} apuestas. \nPresione una tecla para continuar", cantidadclientes);
            Console.ReadLine();

            if (!esnumero)
            {
                Console.Write("La opción ingresada no es válida.");
                Console.ReadLine();

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