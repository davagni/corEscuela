using System;
using System.Collections;
using System.Xml;
using corEscuela.Entidades;

namespace corEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            var escuela = new Escuela("Platzi Academy", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";
            escuela.TipoEscuela = TiposEscuela.Primaria;

            var escuela2 = new Escuela("Platzi Academy", 2021, TiposEscuela.Secundaria, ciudad: "Santa Fe", pais: "Argentina");

            var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };
            arregloCursos[1] = curso2;

            arregloCursos[2] = new Curso
            {
                Nombre = "301"
            };

            System.Console.WriteLine(escuela);
            System.Console.WriteLine("========================");
            System.Console.WriteLine(escuela2);
            System.Console.WriteLine("========================");
            ImprimirCursosForEach(arregloCursos);
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                System.Console.WriteLine(arregloCursos[contador].ToString());
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                System.Console.WriteLine(arregloCursos[contador].ToString());
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                System.Console.WriteLine(arregloCursos[i].ToString());
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                System.Console.WriteLine(curso.ToString());
            }
        }
    }
}
