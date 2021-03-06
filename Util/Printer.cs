using System;
using static System.Console;

namespace corEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int longitud = 10)
        {
            var linea = "".PadLeft(longitud, '=');
            WriteLine(linea);
        }

        public static void PresioneENTER()
        {
            WriteLine("Presione ENTER para continuar...");
        }

        public static void WriteTitle(string titulo)
        {
            var longitud = titulo.Length + 4;

            DrawLine(longitud);
            WriteLine($"| {titulo} |");
            DrawLine(longitud);
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int veces = 1)
        {
            while (veces-- > 0)
            {
                Console.Beep(hz, tiempo);
            }
        }

    }
}