using System;
using System.Diagnostics;
using System.Linq;

namespace ProyectoOrdenacionConsola
{
    class Programa
    {
        static void Main()
        {
            Console.WriteLine("Bienvenido al programa de ordenación.");
            Console.WriteLine("Ingrese los números separados por coma:");
            string entrada = Console.ReadLine();

            int[] numeros = ParsearEntradaNumeros(entrada);
            if (numeros == null) return;

            while (true)
            {
                Console.WriteLine("\nSeleccione un método de ordenación:");
                Console.WriteLine("1. Ordenamiento Burbuja");
                Console.WriteLine("2. Ordenamiento Sacudida");
                Console.WriteLine("3. Ordenamiento por Inserción");
                Console.WriteLine("4. Ordenamiento por Selección");
                Console.WriteLine("5. Shell Sort");
                Console.WriteLine("6. Quicksort");
                Console.WriteLine("7. Heapsort");
                Console.WriteLine("0. Salir");

                Console.Write("Ingrese una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "0")
                    break;

                int[] copiaNumeros = (int[])numeros.Clone();
                Stopwatch cronometro = new Stopwatch();
                cronometro.Start();

                switch (opcion)
                {
                    case "1":
                        OrdenamientoBurbuja.Ordenar(copiaNumeros);
                        break;
                    case "2":
                        OrdenamientoSacudida.Ordenar(copiaNumeros);
                        break;
                    case "3":
                        OrdenamientoInsercion.Ordenar(copiaNumeros);
                        break;
                    case "4":
                        OrdenamientoSeleccion.Ordenar(copiaNumeros);
                        break;
                    case "5":
                        OrdenamientoShell.Ordenar(copiaNumeros);
                        break;
                    case "6":
                        OrdenamientoQuicksort.Ordenar(copiaNumeros, 0, copiaNumeros.Length - 1);
                        break;
                    case "7":
                        OrdenamientoHeapsort.Ordenar(copiaNumeros);
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        continue;
                }

                cronometro.Stop();
                Console.WriteLine("\nResultado ordenado: " + string.Join(", ", copiaNumeros));
                Console.WriteLine("Tiempo de ejecución: " + cronometro.Elapsed.TotalMilliseconds.ToString("F3") + " ms\n");
            }

            Console.WriteLine("Programa finalizado.");
        }

        static int[] ParsearEntradaNumeros(string entrada)
        {
            try
            {
                return entrada.Split(',')
                              .Select(x => int.Parse(x.Trim()))
                              .ToArray();
            }
            catch
            {
                Console.WriteLine("Error: Ingrese solo números separados por coma.");
                return null;
            }
        }
    }
}
