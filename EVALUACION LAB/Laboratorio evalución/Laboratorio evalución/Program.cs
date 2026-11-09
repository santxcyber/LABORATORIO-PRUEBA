using System;
using System.Globalization;

namespace Laboratorio_evalución
{
    internal class Program
    {
        public const int TOTAL_ORDENES = 6;

        public static string[] codigos =
        {
            "OC-101", "OC-102", "OC-103",
            "OC-104", "OC-105", "OC-106"
        };

        public static string[] proveedores =
        {
            "TechCorp1",
            "LogiExpress",
            "InsumosGlobal",
            "TechCorp2",
            "AlfaSuministros",
            "ServiRedes"
        };


        public static double[,] datos =
        {
            { 150.0, 10.0 },
            { 450.0, 2.0 },
            { 80.0, 50.0 },
            { 1200.0, 1.0 },
            { 25.0, 100.0 },
            { 600.0, 3.0 }
        };

        public static double granTotal;
        public static int comprasMayoritaras;

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                MostrarTitulo();

                Console.WriteLine("1. Mostrar reporte ordenado");
                Console.WriteLine("2. Mostrar métricas");
                Console.WriteLine("3. Buscar orden");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion;

                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        ordenamiento_directo();
                        MostrarReporte();
                        Console.ReadKey();
                        break;

                    case 2:
                        CalcularMetricas();
                        MostrarMetricas();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("\nIngrese el código a buscar: ");
                        string codigo = Console.ReadLine();
                        Busqueda(codigo);
                        Console.ReadKey();
                        break;

                    case 4:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Error: opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void MostrarTitulo()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("       CONTROL DE ÓRDENES DE COMPRA (EVALUACIÓN 45 MIN)");
            Console.WriteLine("============================================================");
        }

        public static bool validar_datos(double precio, double cantidad)
        {
            if (precio <= 0 || cantidad <= 0)
            {
                Console.WriteLine("Alerta: el precio y la cantidad deben ser mayores que cero.");
                return false;
            }

            return true;
        }

        public static double CalcularMonto(double precio, double cantidad)
        {
            if (!validar_datos(precio, cantidad))
            {
                return 0;
            }

            return precio * cantidad;
        }

        public static void CalcularMetricas()
        {
            granTotal = 0;
            comprasMayoritaras = 0;

            for (int i = 0; i < TOTAL_ORDENES; i++)
            {
                double precio = datos[i, 0];
                double cantidad = datos[i, 1];
                double montoNeto = CalcularMonto(precio, cantidad);

                granTotal += montoNeto;

                if (montoNeto > 1000)
                {
                    comprasMayoritaras++;
                }
            }
        }
    }
}

