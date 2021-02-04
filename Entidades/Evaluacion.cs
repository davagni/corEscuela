using System;
using System.Diagnostics;
using System.Reflection;

namespace corEscuela.Entidades
{
    [DebuggerDisplay("{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}")]

    public class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }

        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }

}