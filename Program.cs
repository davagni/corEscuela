using System;
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

            Console.WriteLine(escuela);

            var escuela2 = new Escuela("Platzi Academy", 2021, TiposEscuela.Secundaria, ciudad: "Santa Fe", pais: "Argentina");
            Console.Write(escuela2);
        }
    }
}
