using System;
using System.Collections.Generic;
using corEscuela.App;
using corEscuela.Entidades;
using static System.Console;

namespace corEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            var engine = new EscuelaEngine();
            engine.Inicializar();

            ImprimirCursosEscuela(engine.Escuela);

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("Cursos de la escuela");
            WriteLine("====================");

            //if (escuela != null && escuela.Cursos != null)
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
