// Nota: Lo que tienes escrito aquí es orientativo. Puedes quitar o poner lo que te interese.

using System;
using System.Collections;

namespace CostesPersonalTienda
{
    public class Util
    {
        //----DEVUELVE LA OPCION SELECCIONADA
        public static int Menu()
        {
            int opcion=0;

                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\tAlumno: Nombre Apellido1");
                Console.WriteLine("\t\t\t╔════════════════════════════════╗");
                Console.WriteLine("\t\t\t║             MENU               ║");
                Console.WriteLine("\t\t\t╠════════════════════════════════╣");
                Console.WriteLine("\t\t\t║                                ║");
                Console.WriteLine("\t\t\t║    1) Puestos de trabajo       ║");
                Console.WriteLine("\t\t\t║    2) Costes Mensuales         ║");
                Console.WriteLine("\t\t\t║                                ║");
                Console.WriteLine("\t\t\t║    3) Alta de Empleada         ║");
                Console.WriteLine("\t\t\t║    4) Baja de Empleada         ║");
                Console.WriteLine("\t\t\t║                                ║");
                Console.WriteLine("\t\t\t║           0) Salir             ║");
                Console.WriteLine("\t\t\t║                                ║");
                Console.WriteLine("\t\t\t╚════════════════════════════════╝");
            opcion = Console.ReadKey().KeyChar - '0';
                //-- Capturo la pulsación

            return opcion;
        }

        public static int CapturaEntero(string frase, int min, int max)
        {
            int num=0;
            bool esOK;
            do
            {
                Console.WriteLine("{0}; [{1}...{2}]",frase,min,max);
                esOK = Int32.TryParse(Console.ReadLine(), out num);
                if (!esOK)
                    Util.Error("El Valor Introducido No es un Valor Númerico");
                else if (num > max || num < min)
                {
                    Util.Error("El Número debe estár dentro de los limites");
                    esOK=false;
                }
            } while (!esOK);
            return num;
        }


        // Devuelve true si pulsas s ó S. Devuelve false si pulsas n ó N
        public static bool PreguntaSioNo(string frase)
        {
           
            char respuesta;
            bool repetir = false;
            bool error = true;
            do
            {
                Console.Write("\n\n\t{0}; Reponde con s=si || n=no:", frase);
                respuesta = Console.ReadKey(true).KeyChar;
                if (respuesta == 's' || respuesta == 'S')
                {
                    repetir = true;
                    error = false;
                }
                else if (respuesta == 'n' || respuesta == 'N')
                {
                    repetir = false;
                    error = false;
                }
                else
                {
                    error = true;
                    Util.Error("***Error Introduce s || n***");
                }
            } while (error);
            return repetir;
        }

        /// <summary>
        /// Cuadra el texto que recibe a la izquierda de una cadena de longitud «numCaracteres»
        /// rellenando a la derecha con el caracter de relleno
        /// </summary>
        /// <param name="texto">Cadena a cuadrar</param>
        /// <param name="numCaracteres">Número de caracteres de la cadena de salida</param>
        /// <param name="relleno">Carácter con que se rellenará a la derecha</param>
        /// <returns>Cadena resultante</returns>
        public static string CuadraTexto(string texto, int numCaracteres, char relleno)
        {
            while (texto.Length < numCaracteres)
                texto += relleno;
            return texto.Substring(0,numCaracteres); //<-- Aquí falta algo
        }

        /// <summary>
        /// Devuelve el número como una cadena cuadrada a la derecha de longitud «numCaracteres»
        /// </summary>
        /// <param name="numero">Número a cuadrar</param>
        /// <param name="numCaracteres">Longitud total de la cadena que devuelve</param>
        /// <returns>Devuelve la cadena de longitud «numCaracteres» con el número ajustado a la derecha</returns>
        public static string CuadraTexto(double numero, int numCaracteres)
        {
            string cadena = "                      " + numero;

            return cadena.Substring(cadena.Length - numCaracteres);  //<-- Aquí falta algo
        }

        /// <summary>
        /// Muestra el texto que recibe con el color de fondo en DarkRed
        /// </summary>
        /// <param name="texto"></param>
        public static void Error(string texto)
        {
            Console.Write("\n\n\t");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" ** {0} ** ", texto);
            Console.ResetColor();

        }
        public static string CapturaId(String texto)
        {
            string id = string.Empty;
            bool ok;
            do
            {
                ok = true;
                Console.WriteLine("Introduzca un id");
                id = Console.ReadLine().ToUpper();
                if (id.Length != 4)
                {
                    Util.Error("Error id debe ser 4 caracteres");
                    ok = false;
                }
                if (ok) //Comprobamos las Tres Primeras Posiciones (Letras/Caracteres)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (id[i] < 'A' || id[i] > 'Z')
                        {
                            Util.Error("Error: Los tres primeros caracteres deben ser letras");
                            ok = false;
                            break;
                        }
                    }
                    if (ok) //Ahora Comprobamos el ultimo Caracter si es numerico 
                    {
                        if (id[3] < '0' || id[3] > '9')
                        {
                            Util.Error("Error: El Ultimo Caracter Debe Ser numerico");
                            ok = false;
                        }
                    }
                }
            } while (!ok);
            return id;
        }

    }
}
