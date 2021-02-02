using System.Collections.Generic;

namespace corEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public string Direccion { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, ID: {UniqueId}";
        }

        public void LimpiarLugar()
        {
            System.Console.WriteLine($"Curso {Nombre} limpio");
        }
    }
}