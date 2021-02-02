using System.Collections.Generic;
using corEscuela.Util;

namespace corEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        public int AñoDeCreación { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Pais { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }

        //Constructor
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);

        //Constructor
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        }

        //Override de ToString
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\" \nTipo: {TipoEscuela} \nPais: {Pais} \nCiudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            System.Console.WriteLine("Limpiando Escuela...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            System.Console.WriteLine($"Escuela {Nombre} limpia");
        }
    }
}