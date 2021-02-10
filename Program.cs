﻿using System;
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
