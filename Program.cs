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

            var engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.WriteTitle("Bienvenidos a la Escuela");
            // Printer.Beep(10000, veces: 2);

            ImprimirCursosEscuela(engine.Escuela);

            var listaObjetos = engine.GetObjetoEscuelas();

            var listaILugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar)obj;

            var listaAlumnos = from obj in listaObjetos
                               where obj is Alumno
                               select (Alumno)obj;

            // engine.Escuela.LimpiarLugar();

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
