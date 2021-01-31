using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace corEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }

        public string Nombre { get; set; }

        public List<Evaluacion> listaEvaluaciones { get; set; }

        public Alumno() => UniqueId = Guid.NewGuid().ToString();

        public Alumno(string nombre) => (Nombre, UniqueId) = (nombre, Guid.NewGuid().ToString());
    }

}