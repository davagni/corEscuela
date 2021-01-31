using System;
using System.Data;
using System.Xml;

namespace corEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }

        public string Nombre { get; set; }

        public Alumno() => UniqueId = Guid.NewGuid().ToString();

        public Alumno(string nombre) => (Nombre, UniqueId) = (nombre, Guid.NewGuid().ToString());
    }

}