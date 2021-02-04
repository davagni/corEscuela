using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Escuela> GetListaEscuela()
        {
            IEnumerable<Escuela> rta;
            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }
            else
            {
                rta = null;
                // Escribir en el log de Auditoria
            }

            return rta;
        }

    }
}