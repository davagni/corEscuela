using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace corEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase
    {
        public int AñoDeCreación { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
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

    }
}