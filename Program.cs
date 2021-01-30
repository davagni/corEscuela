using System;
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

            var curso1 = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            var curso3 = new Curso()
            {
                Nombre = "301"
            };

            System.Console.WriteLine(escuela);
            System.Console.WriteLine("========================");
            System.Console.WriteLine(escuela2);
            System.Console.WriteLine("========================");
            System.Console.WriteLine(curso1.Nombre + ", " + curso1.UniqueId);
            System.Console.WriteLine("========================");
            System.Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}");
            System.Console.WriteLine("========================");
            System.Console.WriteLine(curso3);


        }
    }
}
