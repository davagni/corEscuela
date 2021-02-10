using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using corEscuela.Entidades;

namespace corEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (dicObsEsc == null)
                throw new ArgumentNullException(nameof(dicObsEsc));

            _diccionario = dicObsEsc;

        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDiccEvaluaXAsig()
        {

            var diccRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;

                diccRta.Add(asig, evalsAsig);
            }

            return diccRta;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetPromAlumPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();

            var diccEvalXAsig = GetDiccEvaluaXAsig();

            foreach (var asigConEval in diccEvalXAsig)
            {
                var promsAlumn = from eval in asigConEval.Value
                                 group eval by new
                                 {
                                     eval.Alumno.UniqueId,
                                     eval.Alumno.Nombre
                                 }
                                into grupoEvalsAlumno
                                 select new AlumnoPromedio
                                 {
                                     alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                     alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                     promedio = grupoEvalsAlumno.Average(ev => ev.Nota)
                                 };

                rta.Add(asigConEval.Key, promsAlumn);
            }

            return rta;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetMejoresPromAlumPorAsignatura(int cantidad = 10)
        {
            var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();

            var diccPromAlumPorAsig = GetPromAlumPorAsignatura();

            foreach (var asignatura in diccPromAlumPorAsig)
            {
                var mejoresPromedios = asignatura.Value
                                    .OrderByDescending(a => a.promedio)
                                    .Take(cantidad);

                rta.Add(asignatura.Key, mejoresPromedios);
            }

            return rta;
        }
    }
}