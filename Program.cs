using System;
using System.Collections.Generic;
using System.Linq;
using corEscuela.App;
using corEscuela.Entidades;
using corEscuela.Util;
using static System.Console;

namespace corEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(100, 1000, 1);
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;

            var engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.WriteTitle("Bienvenidos a la Escuela");
            // Printer.Beep(10000, veces: 2);

            //ImprimirCursosEscuela(engine.Escuela);

            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "JuanK");
            diccionario.Add(23, "Lorem Ipsum");

            foreach (var keyValuePair in diccionario)
            {
                WriteLine($"Key: {keyValuePair.Key}, Valor: {keyValuePair.Value}");
            }

            var dictmp = engine.GetDiccionarioObjetos();

            engine.imprimirDiccionario(dictmp, true);

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo...");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("Salió");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la escuela");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    System.Console.WriteLine(curso.ToString());
                }
            }

        }

    }
}
