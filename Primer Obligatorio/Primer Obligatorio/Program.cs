using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Defino las variables
            int apostadores = 0;
            string[] nombres = new string[0];
            int[,] apuestas = new int[0, 0];
            int ultimolibre = 0;
            
            // Creación de un loop para que se siga ejecutando el menú principal en caso de ingresar una opción no válida
            bool ejecutando = true;
            while (ejecutando)
            {
                // Llamada al método que muestra el menú principal
                int opcion = 0;
                MostrarMenu();

                //Se pide el número de opción del menú principal
                bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                //Verificación de que la opción ingresada es válida
                if (!esnumero || opcion <= 0 || opcion > 6)
                {
                    Console.Write("La opción ingresada no es válida.");
                    Console.ReadLine();
                }

                // Ejecución de métodos dependiendo de la opción ingresada
                switch (opcion)
                {
                    case 1:
                        CantidadApostadores(ref apostadores, ref nombres, ref apuestas, ref ultimolibre);
                        break;
                    case 2:
                        Apuesta(apostadores, ref nombres, ref apuestas, ref ultimolibre);
                        break;
                    case 3:
                        ApuestaSorpresa(apostadores, ref nombres, ref apuestas, ref ultimolibre);
                        break;
                    case 4:
                        EliminaApuesta(ref nombres, ref apuestas, ref ultimolibre);
                        break;
                    case 5:
                        Listado(ref nombres, ref apuestas, ref ultimolibre);
                        break;
                    case 6:
                        ejecutando = false;
                        break;
                    default:
                        MostrarMenu();
                        break;
                }
            }
        }

        // Método que muestra el menú principal
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("               5 de Oro");
            Console.WriteLine("\n            733555555533352535555347             \n            7455555557575757575757553             \n            6877777777777777777777775             \n            8377777723253294449422243             \n            277777778866688888886689              \n            27777777                              \n            87 77777                              \n           58  77 77                              \n           68     77  7777777777                  \n           95                   777               \n           57                      7              \n                    7206695         7             \n            7  77728695346865        7            \n           4888883          777       7           \n                             77       7           \n                              7       7           \n                               7 7 7  7           \n         777777777            377777777           \n         577777777           7777777777           \n         75777777777         777777777            \n          757777777777777777777777775             \n           5577777777777577777777725              \n            74427777777777777775407               \n              3888935777552468867                 \n                 7368888888827      ");
            Console.WriteLine("\n****************************************** \n");
            Console.WriteLine("   1 - Ingresar la cantidad de apostadores    ");
            Console.WriteLine("   2 - Ingresar apuesta");
            Console.WriteLine("   3 - Ingresar apuesta sorpresa");
            Console.WriteLine("   4 - Eliminar apuesta");
            Console.WriteLine("   5 - Listados");
            Console.WriteLine("   6 - Salir\n");
            Console.WriteLine("******************************************");
            Console.Write("Ingrese la opción deseada: ");
        }

        // Método para ingresar la cantidad de apostadores
        public static void CantidadApostadores(ref int apostadores, ref string[] nombres, ref int[,] apuestas, ref int ultimolibre)
        {
            Console.Clear();
            Console.WriteLine("\n******************************************");
            Console.WriteLine("  Ingreso de la cantidad de apostadores");
            Console.WriteLine("****************************************** \n");

            //Se verifica si la cantidad de apostadores ya fue ingresada previamente
            if (apostadores > 0)
            {
                Console.WriteLine("La cantidad de apostadores ya fue ingresada. \n");
                Console.WriteLine("Si desea borrar las apuestas ya ingresadas e ingresar un nuevo número de apostadores presione 'S'.");
                    Console.Write("De lo contrario, presione cualquier tecla para volver al menú principal: ");
                    string respuesta = Console.ReadLine();
                    if (respuesta == "S" || respuesta == "s")
                    {
                        // Ingreso del número de apostadores en caso de que ya haya sido ingresado nuevamente pero se quieran borrar los datos e
                        // ingresar un nuevo número de apostadores
                        Console.WriteLine();
                        NumeroApostadores(ref apostadores, ref nombres, ref apuestas, ref ultimolibre);
                        //ejecutando = false;
                    }
            }
            // Ingreso del número de apostadores en caso de que no haya sido ingresado previamente
            else
            {
                NumeroApostadores(ref apostadores, ref nombres, ref apuestas, ref ultimolibre);
            }
        }

        //Método para ingresar una cantidad válida de apostadores
        public static void NumeroApostadores(ref int apostadores, ref string[] nombres, ref int[,] apuestas, ref int ultimolibre)
        {
            //Creación de un loop para que se vuelva a pedir la cantidad de apostadores en caso de ingresar un valor no válido
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se pide la cantidad de apostadores
                Console.Write("Ingrese la cantidad de apostadores: ");
                bool esnumero = Int32.TryParse(Console.ReadLine(), out apostadores);

                //Se verifica que el valor ingresado sea válido
                if (!esnumero || apostadores <= 0)
                {
                    Console.Write("La opción ingresada no es válida.\n");
                    Console.ReadLine();
                }
                else
                {
                    nombres = new string[apostadores];
                    apuestas = new int[apostadores, 5];
                    ultimolibre = 0;
                    ejecutando = false;
                }
            }
        }

        // Método para ingresar una apuesta
        public static void Apuesta(int apostadores, ref string[] nombres, ref int[,] apuestas, ref int ultimolibre)
        {
            Console.Clear();
            Console.WriteLine("\n******************************************");
            Console.WriteLine("           Ingreso de apuesta");
            Console.WriteLine("****************************************** \n");

            //Se verifica que se haya ingresado la cantidad de apostadores
            if (apostadores <= 0 /*|| apostadores == null*/)
            {
                Console.WriteLine("No puede ingresar una apuesta porque no se ha ingresado la cantidad de apostadores");
                Console.ReadLine();
            }
            // Se verifica que no se haya alcanzado la cantidad máxima de apostadores
            else if (ultimolibre == nombres.Length)
            {
                Console.WriteLine("Ya se ha alcanzado el número máximo de apostadores");
                Console.ReadLine();
            }

            else
            {
                // Se pide el nombre del apostador
                Console.Write("Ingrese el nombre del apostador: ");
                string nombre = Console.ReadLine();

                // Se verifica si el nombre ingresado ya se encuentra en la lista de apostadores
                if (nombrerepetido(nombres, nombre) == true)
                {
                    Console.WriteLine("\nEl nombre ingresado ya existe en el listado de apostadores.");
                    Console.Write("\nPresione 'R' para volver al menú principal o cualquier tecla para ingresar un nuevo nombre de apostador: ");
                    string respuesta = Console.ReadLine();
                    if (respuesta != "R" && respuesta != "r")
                    {
                        Apuesta(apostadores, ref nombres, ref apuestas, ref ultimolibre);
                    }
                }
                else if (nombre == "")
                {
                    Console.WriteLine("\nNo ha ingresado el nombre del apostador.");
                    Console.Write("Presione 'R' para volver al menú principal o cualquier tecla para ingresar un nuevo nombre de apostador: ");
                    string respuesta = Console.ReadLine();
                    if (respuesta != "R" && respuesta != "r")
                    {
                        Apuesta(apostadores, ref nombres, ref apuestas, ref ultimolibre);
                    }
                }

                else
                {
                    // Se ingresa el nombre en caso de que el mismo no esté repetido en la lista de apostadores
                    nombres[ultimolibre] = nombre;

                    //Se ingresan las números apostados por el apostador
                    for (int i = 0; i < 5; i++)
                    {
                        // Creación de un loop para que se vuelva a pedir el valor apostado en caso de ingresar un valor no válido
                        bool preguntando = true;
                        while (preguntando)
                        {
                            // Se pide el ingreso de los números apostados
                            Console.Write("\nIngrese el {0}º valor de la apuesta: ", i + 1);
                            bool esnumero = Int32.TryParse(Console.ReadLine(), out apuestas[ultimolibre, i]);

                            //Se verifica que el valor ingresado es válido y que se encuentra dentro del rango permitido
                            if (!esnumero || apuestas[ultimolibre, i] < 1 || apuestas[ultimolibre, i] > 49)
                            {
                                Console.WriteLine("\nEl valor ingresado no es válido.");
                            }
                            else if (numerorepetido(apuestas, ultimolibre, apuestas[ultimolibre, i], i))
                            {
                                Console.WriteLine("\nNo puede ingresar dos veces el mismo número en la misma apuesta.");
                            }
                            else
                            {
                                preguntando = false;
                            }
                        }
                    }
                    ultimolibre++;
                }
            }
        }


        // Método para ingresar una apuesta sorpresa
        public static void ApuestaSorpresa(int apostadores, ref string[] nombres, ref int[,] apuestas, ref int ultimolibre)
        {
            Console.Clear();
            Console.WriteLine("\n******************************************");
            Console.WriteLine("        Ingreso de apuesta sorpresa");
            Console.WriteLine("****************************************** \n");

            //Se verifica que se haya ingresado la cantidad de apostadores
            if (apostadores <= 0 /*|| apostadores == null*/)
            {
                Console.WriteLine("No puede ingresar una apuesta porque no se ha ingresado la cantidad de apostadores");
                Console.ReadLine();
            }
            // Se verifica que no se haya alcanzado el número máximo de apostadores
            else if (ultimolibre == nombres.Length)
            {
                Console.WriteLine("Ya se ha alcanzado el número máximo de apostadores");
                Console.ReadLine();
            }

            else
            {

                // Se pide el nombre del apostador
                Console.Write("Ingrese el nombre del apostador: ");
                string nombre = Console.ReadLine();

                // Se verifica si el nombre ingresado ya se encuentra en la lista de apostadores
                if (nombrerepetido(nombres, nombre) == true)
                {
                    Console.WriteLine("\nEl nombre ingresado ya existe en el listado de apostadores.");
                    Console.Write("Presione 'R' para volver al menú principal o cualquier tecla para ingresar un nuevo nombre de apostador: ");
                    string respuesta = Console.ReadLine();
                    if (respuesta != "R" && respuesta != "r")
                    {
                        ApuestaSorpresa(apostadores, ref nombres, ref apuestas, ref ultimolibre);
                    }
                }

                else if (nombre == "")
                {
                    Console.WriteLine("\nNo ha ingresado el nombre del apostador.");
                    Console.Write("Presione 'R' para volver al menú principal o cualquier tecla para ingresar un nuevo nombre de apostador: ");
                    string respuesta = Console.ReadLine();
                    if (respuesta != "R" && respuesta != "r")
                    {
                        Apuesta(apostadores, ref nombres, ref apuestas, ref ultimolibre);
                    }
                }

                else
                {
                    // Se ingresa el nombre en caso de que el mismo no esté repetido en la lista de apostadores
                    nombres[ultimolibre] = nombre;

                    //Se ingresan las números generados aleatoriamente
                    for (int i = 0; i < 5; i++)
                    {
                        bool numrepetido = true;
                        while (numrepetido)
                        {
                            Random variable = new Random();
                            apuestas[ultimolibre, i] = variable.Next(1, 49);
                            // Se verifica que no se haya generado dos veces el mismo número
                            if (!numerorepetido(apuestas, ultimolibre, apuestas[ultimolibre, i], i))
                            {
                                numrepetido = false;
                            }
                        }
                    }
                    Console.WriteLine("\nApuesta ingresada con éxito.");


                    //Se pregunta si se quieren ver los números generados
                    Console.Write("Presione 'S' para ver los números apostados o cualquier tecla para volver al menú principal: ");
                    string respuesta = Console.ReadLine();

                    //Si se quieren ver los números generados se despliegan en pantalla
                    if (respuesta == "S" || respuesta == "s")
                    {
                        Console.WriteLine();
                        for (int j = 0; j < apuestas.GetLength(1); j++)
                        {
                            Console.Write("\t " + apuestas[ultimolibre, j]);
                        }
                        Console.ReadLine();
                    }
                    ultimolibre++;
                }
            }
        }

        //Método para eliminar una apuesta ingresada
        public static void EliminaApuesta(ref string[] nombres, ref int[,] apuestas,ref int ultimolibre)
        {
            Console.Clear();
            Console.WriteLine("\n******************************************");
            Console.WriteLine("            Eliminar apuesta");
            Console.WriteLine("****************************************** \n");

            //Se pide el nombre del apostador cuya apuesta se desea borrar
            Console.Write("Ingrese el nombre del apostador cuya apuesa desea borrar: ");

            string nombreborrar = Console.ReadLine();

            //Se busca el nombre en el listado de apostadores
            int posicion = -1;
            for (int i = 0; i < ultimolibre; i++)
            {
                if (nombreborrar == nombres[i])
                {
                    posicion = i;
                }
            }

            //Si no se encuentra el nombre en el listado de apostadores, se pregunta si se quiere buscar otro nombre.
            if (posicion == -1)
            {
                Console.WriteLine("El nombre ingresado no se encuentra en la lista de apostadores.\n");
                Console.Write("Presione 'R' para volver al menú principal o cualquier tecla para buscar un nuevo nombre de apostador: ");
                string respuesta = Console.ReadLine();

                if (respuesta != "R" && respuesta != "r")
                {
                    EliminaApuesta(ref nombres, ref apuestas,ref ultimolibre);
                }
            }
            // Si se encuentra el nombre en el listado de apostadores, se sobreescribe la apuesta con la última apuesta ingresada
            // y se borra la última apuesta ingresada para que la misma no quede duplicada
            else
            {
                nombres[posicion] = nombres[ultimolibre - 1];
                nombres[ultimolibre - 1]= string.Empty;
                for (int j = 0; j < apuestas.GetLength(1); j++)
                {
                    apuestas[posicion, j] = apuestas[ultimolibre - 1, j];
                }
                for (int j = 0; j < apuestas.GetLength(1); j++)
                {
                    apuestas[ultimolibre - 1, j] = 0;
                }
                ultimolibre--;
                Console.Write("\nLa apuesta del jugador {0} ha sido borrada con éxito.", nombreborrar);
                Console.ReadLine();
            }
        }


        public static void Listado(ref string[] nombres, ref int[,] apuestas, ref int ultimolibre)
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
                        Console.WriteLine("No se ha encontrado el apostador ingresado.");
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


        //Método para verificar si un nombre ya está ingresado en la lista de apostadores
        public static bool nombrerepetido(string[] nombres, string nombre)
        {
            bool resultado = false;
            int i = 0;
            // Se busca en toda la lista de apostadores si el nombre ya existe
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


        //Método para verificar si se está ingresando una apuesta con números repetidos
        public static bool numerorepetido(int[,] apuestas,int ultimolibre, int numeroapostado, int posicion)
        {
            bool resultado = false;
            int i = 0;
            // Se busca en los números ya ingresados para ese apostador
            while (!resultado && i < posicion)
            {
                if (numeroapostado == apuestas[ultimolibre,i])
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
