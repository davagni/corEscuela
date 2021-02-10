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

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var listaEval = reporteador.GetListaEvaluaciones();
            var listaAsig = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDiccEvaluaXAsig();
            var listaPromXAsig = reporteador.GetPromAlumPorAsignatura();
            var listaMejoresPromXAsig = reporteador.GetMejoresPromAlumPorAsignatura(5);


            Printer.WriteTitle("Captura de una Evaluacion por Consola");
            var newEval = new Evaluacion();
            string nombre, notaString;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre se ingresó correctamente.");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notaString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(notaString))
            {
                Printer.WriteTitle("El valor de la nota no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if (newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota se ingresó correctamente.");
                }
                catch (ArgumentOutOfRangeException arge)
                {
                    Printer.WriteTitle(arge.Message);
                    WriteLine("Saliendo del programa");
                }
                catch (Exception e)
                {
                    Printer.WriteTitle("El valor de la nota no es un número válido.");
                    WriteLine("Saliendo del programa");
                }
            }
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
