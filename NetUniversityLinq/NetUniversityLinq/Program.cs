using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NetUniversityLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var cursos = Data.GetCursos();
            var estudiantes = Data.GetEstudiantes();

            var cursosFiltrada = from c in cursos 
                                 where c.Activo
                                 orderby c.Nombre, c.Codigo
                                 select new { c.Nombre, c.Codigo };
            var estudiantesFiltrada = estudiantes.Where((p,i) => p.Activo && i > 3).OrderByDescending(p=> p.CursoId).ThenBy(p=> p.Nombre);

            var estudiantesOrdenada = estudiantesFiltrada.ToList().Select(p=> new { p.Codigo, p.Nombre, p.Apellido });


            Console.WriteLine($"La cantidad de cursos es: {cursos.LongCount(p=> p.Activo) }");


            var existeEstudianteSeleccionado = estudiantesFiltrada.Contains(estudiantes[5]);
            Console.WriteLine($"¿El Estudiante seleccionado esta en la lista? {existeEstudianteSeleccionado.ToString()}");

            Console.WriteLine(" --  CURSOS Filtrado -- ");
            foreach (var item in cursosFiltrada)
            {
                Console.WriteLine($"{item.Codigo} - {item.Nombre}");
            }
            Console.WriteLine();
            Console.WriteLine(" --  ESTUDIANTES Filtrada-- ");
            foreach (var item in estudiantesOrdenada)
            {
                Console.WriteLine($"{item.Codigo} - {item.Nombre} {item.Apellido}");
            }

            Console.WriteLine();

            Console.WriteLine(" --  CURSOS -- ");
            foreach (var item in cursos)
            {
                Console.WriteLine($"{item.Codigo} - {item.Nombre}");
            }
            Console.WriteLine();
            Console.WriteLine(" --  ESTUDIANTES-- ");
            foreach (var item in estudiantes)
            {
                Console.WriteLine($"{item.Codigo} - {item.Nombre} {item.Apellido}");
            }

            Console.ReadLine();
        }
    }

    public class OrdenadorPorEdad : IComparer<Estudiante>
    {
        public int Compare([AllowNull] Estudiante x, [AllowNull] Estudiante y)
        {
            if (x.Edad.CompareTo(y.Edad) > 0)
            {
                return x.Edad.CompareTo(y.Edad);
            }
            else
            {
                return 0;
            }
        }
    }
}
