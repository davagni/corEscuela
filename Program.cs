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
            ImprimirCursos(arregloCursos);
        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                System.Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, ID: {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }
    }
}
