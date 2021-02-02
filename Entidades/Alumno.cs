using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace corEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();

    }

}