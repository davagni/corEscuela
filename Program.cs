using System;
using corEscuela.Entidades;

namespace corEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            var escuela = new Escuela("Platzi Academy", 2021);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";

            Console.WriteLine(escuela.Nombre);
            Console.WriteLine(escuela.AñoDeCreación);
            Console.WriteLine(escuela.Pais);
            Console.WriteLine(escuela.Ciudad);
        }
    }
}
