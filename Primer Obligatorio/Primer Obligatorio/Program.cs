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
                        CantidadClientes();
                        break;
                    case 2:
                        Apuesta();
                        break;
                    case 3:
                        ApuestaSorpresa();
                        break;
                    case 4:
                        EliminaApuesta();
                        break;
                    case 5:
                        Listado();
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
        {
        }

        public static void Apuesta()
        {
        }

        public static void ApuestaSorpresa()
        {
        }

        public static void EliminaApuesta()
        {
        }

        public static void Listado()
        {
        }






    }
}
