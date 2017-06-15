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
            String[] apostadores = null;
            MostrarMenu();
        }



        public static void MostrarMenu()
        {

            int opcion = 0;
            bool esnumero = false;
            while (!esnumero)
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
                
                esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                if (!esnumero)
                {
                    Console.Write("La opción ingresada no es válida.");
                    Console.ReadLine();
                }

                switch (opcion)
                {
                    case 1:
                        CantidadClientes(apostadores);
                        
                        MostrarMenu();
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
                        //
                        break;
                    default:
                        MostrarMenu();
                        break;
                }
            }
        }
        
        public static void CantidadClientes(ref String[] apostadores)
        {
            //Lee y modifica la referencia del vector de strings. Si fue cargado previamente, advierte al ususario que se ha eliminado. Tal vez agregar una pregunta para esto?
            int cantidadclientes = 0;
            Console.Clear();

            if (apostadores.Length != 0)
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

            Array.Resize<String>(ref apostadores, cantidadclientes);

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