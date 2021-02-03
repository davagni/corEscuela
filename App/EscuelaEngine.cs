using System;
using System.Collections.Generic;
using System.Linq;
using corEscuela.Entidades;

namespace corEscuela.App
{
    ///Sealed permite crear instanciar pero no heredar
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            Inicializar();
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2021, TiposEscuela.Secundaria, ciudad: "Santa Fe", pais: "Argentina");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas()
        {
            var listaObj = new List<ObjetoEscuelaBase>();

            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }

            return listaObj;
        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuelas(out int dummy, out dummy, out dummy, out dummy,
                traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuelas(out conteoEvaluaciones, out int dummy, out dummy, out dummy,
                traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuelas(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy,
                traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuelas(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy,
                traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();

            listaObj.Add(Escuela);

            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);

            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignaturas);
                }

                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumnos);
                }

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj;
        }

        #region --Metodos de Carga--
        private void CargarEvaluaciones()
        {
            //Evaluaciones
            //Por cada Curso / Asignatura / Alumno / Agregar 5 evaluaciones
            //Con notas entre 0.0 y 5.0
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 1; i < 6; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };

                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }

            }
        }

        private void generarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemática"},
                    new Asignatura{Nombre="Computación"},
                    new Asignatura{Nombre="Educación Fisica"},
                    new Asignatura{Nombre="Inglés"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidadAlumnos)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy(a => a.UniqueId)
                               .Take(cantidadAlumnos)
                               .ToList();

        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "202", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "303", Jornada = TiposJornada.Noche },
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "502", Jornada = TiposJornada.Tarde }
            };

            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int alumnosPorCurso = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(alumnosPorCurso);
            }
        }

        #endregion

    }
}