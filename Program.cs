using System;
using System.Collections.Generic;
using corEscuela.Entidades;
using static System.Console;

namespace corEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            var escuela = new Escuela("Platzi Academy", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";
            escuela.TipoEscuela = TiposEscuela.Primaria;

            var escuela2 = new Escuela("Platzi Academy", 2021, TiposEscuela.Secundaria, ciudad: "Santa Fe", pais: "Argentina");

            /*
            * Arreglos
            */

            // var arregloCursos = new Curso[3]{
            //     new Curso() { Nombre = "101" },
            //     new Curso() { Nombre = "201"},
            //     new Curso() { Nombre = "301" }
            // };

            // Curso[] arregloCursos =
            // {
            //     new Curso() { Nombre = "101" },
            //     new Curso() { Nombre = "201" },
            //     new Curso() { Nombre = "301" }
            // };
            // escuela.Cursos = arregloCursos;

            // escuela2.Cursos = new Curso[]{
            //     new Curso() { Nombre = "102" },
            //     new Curso() { Nombre = "202" },
            //     new Curso() { Nombre = "302" }
            // };

            //System.Console.WriteLine(escuela);
            //System.Console.WriteLine("========================");
            //WriteLine(escuela2);
            // ImprimirCursosForEach(arregloCursos);

            //escuela2 = null;
            //escuela2.Cursos = null;
            //ImprimirCursosEscuela(escuela2);

            /*
            * Condiciones
            */
            // System.Console.WriteLine("Condiciones=============");
            // bool rta = 10 == 10;
            // int cantidad = 10;
            // if (rta == false)
            // {
            //     WriteLine("Se cumple la condición");
            // }
            // else if (cantidad > 5)
            // {
            //     WriteLine("Cantidad es > 5");
            // }
            // else
            // {
            //     WriteLine("No se cumple la condición");
            // }

            // if (cantidad > 5 && rta == false)
            // {
            //     WriteLine("Se cumple condicion #3");
            // }

            // if (cantidad > 5 && rta)
            // {
            //     WriteLine("Se cumple condicion #4");
            // }

            // cantidad = 10;
            // if ((cantidad > 5 || !rta) && (cantidad % 5 == 0))
            // {
            //     WriteLine("Se cumple condicion #5");
            // }


            /*
            * Colecciones
            */

            var listaCursos = new List<Curso>(){
                new Curso() { Nombre = "102", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "202", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "302", Jornada = TiposJornada.Mañana }
            };

            var otraListaCursos = new List<Curso>(){
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "502", Jornada = TiposJornada.Tarde }
            };

            escuela2.Cursos = listaCursos;
            escuela2.Cursos.Add(new Curso { Nombre = "103", Jornada = TiposJornada.Tarde });
            escuela2.Cursos.Add(new Curso { Nombre = "203", Jornada = TiposJornada.Tarde });

            //otraListaCursos.Clear();
            Curso cursoTmp = new Curso { Nombre = "101-Vacacional", Jornada = TiposJornada.Noche };
            escuela2.Cursos.AddRange(otraListaCursos);
            escuela2.Cursos.Add(cursoTmp);

            ImprimirCursosEscuela(escuela2);

            //Remover uno en particular por referencia
            // WriteLine("Curso.Hash: " + cursoTmp.GetHashCode());
            // escuela2.Cursos.Remove(cursoTmp);
            // WriteLine("Removiendo Curso...");
            // ImprimirCursosEscuela(escuela2);

            //Predicate<Curso> miAlgoritmo = Predicado;
            //escuela2.Cursos.RemoveAll(miAlgoritmo);

            //Inferencia de predicado
            //escuela2.Cursos.RemoveAll(Predicado);

            //Delegados
            escuela2.Cursos.RemoveAll(delegate (Curso c)
            {
                return c.Nombre == "502";
            });

            escuela2.Cursos.RemoveAll(c => c.Nombre == "501"
                                        && c.Jornada == TiposJornada.Mañana);


            ImprimirCursosEscuela(escuela2);


        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                System.Console.WriteLine(arregloCursos[contador].ToString());
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                System.Console.WriteLine(arregloCursos[contador].ToString());
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                System.Console.WriteLine(arregloCursos[i].ToString());
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                System.Console.WriteLine(curso.ToString());
            }
        }

        ///
        /// Comentarios relacionados a la funcion
        ///
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("Cursos de la escuela");
            WriteLine("====================");

            //if (escuela != null && escuela.Cursos != null)
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    System.Console.WriteLine(curso.ToString());
                }
            }

        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "102";
        }
    }
}
