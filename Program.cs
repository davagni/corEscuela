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

            // var arregloCursos = new Curso[3]{
            //     new Curso() { Nombre = "101" },
            //     new Curso() { Nombre = "201"},
            //     new Curso() { Nombre = "301" }
            // };

            Curso[] arregloCursos =
            {
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso() { Nombre = "301" }
            };
            escuela.Cursos = arregloCursos;

            escuela2.Cursos = new Curso[]{
                new Curso() { Nombre = "102" },
                new Curso() { Nombre = "202" },
                new Curso() { Nombre = "302" }
            };

            //System.Console.WriteLine(escuela);
            //System.Console.WriteLine("========================");
            WriteLine(escuela2);
            // ImprimirCursosForEach(arregloCursos);

            //escuela2 = null;
            //escuela2.Cursos = null;
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

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("Cursos de la escuela");
            WriteLine("====================");

            //if (escuela != null && escuela.Cursos != null)
            if (escuela?.Cursos != null)
            {
                ImprimirCursosForEach(escuela.Cursos);
            }

        }
    }
}
