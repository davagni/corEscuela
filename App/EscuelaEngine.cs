using System.Collections.Generic;
using corEscuela.Entidades;

namespace corEscuela.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            Inicializar();
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2021, TiposEscuela.Secundaria, ciudad: "Santa Fe", pais: "Argentina");

            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "202", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "303", Jornada = TiposJornada.Noche },
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "502", Jornada = TiposJornada.Tarde}
            };
        }

    }
}