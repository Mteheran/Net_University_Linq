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

            var takeCursos = cursos.TakeLast(3);

            Console.WriteLine("CURSOS TAKE y TAKEWHILE");

            foreach (var item in takeCursos)
            {
                Console.WriteLine($" {item.Codigo} - {item.Nombre}");
            }

            var skipCursos = cursos.SkipLast(2);

            Console.WriteLine("CURSOS SKIP y SKIPWHILE");

            foreach (var item in skipCursos)
            {
                Console.WriteLine($" {item.Codigo} - {item.Nombre}");
            }

            var cursosActivos = cursos.Where(p => p.Activo);
            var cursosInactivos= cursos.Where(p => !p.Activo);

            var todoslosCursos = cursos.Except(cursosInactivos);

            Console.WriteLine("CURSOS UNION, CONTACT, EXCEPT");
            
            foreach (var item in todoslosCursos)
            {
                Console.WriteLine($" {item.Codigo} - {item.Nombre}");
            }


            var cursosFiltrada = (from c in cursos 
                                  join e in estudiantes on c.CursoId equals e.CursoId
                                  into EstudiantesCurso
                                  from ec in EstudiantesCurso.DefaultIfEmpty()
                                  orderby c.Nombre, c.Codigo
                                  select new { c.Nombre, c.Codigo, CodigoEstudiante = ec?.Codigo });
            var estudiantesFiltrada = estudiantes.OrderByDescending(p=> p.CursoId).ThenBy(p=> p.Nombre);

            var estudiantesOrdenada = estudiantesFiltrada.ToList().GroupJoin(cursos, e => e.CursoId, c => c.CursoId, (e, c) => new { estudiante = e, curso = c.DefaultIfEmpty() }).Select(p => new { NombreCurso = p.curso.FirstOrDefault() != null ? p.curso.FirstOrDefault().Nombre : "Sin curso", p.estudiante.Codigo, p.estudiante.Nombre, p.estudiante.Apellido }).ToLookup(p => p.NombreCurso);

            Console.WriteLine($"La suma de las primeras letras del nombre es { estudiantes.Aggregate("",(total,p)=> total + p.Nombre[0] + "A" ) }");    
            Console.WriteLine($"la suma de todas las edades es: { estudiantes.Sum(p=> p.Edad) }");
            Console.WriteLine($"el estudiante de mayor edad tiene: { estudiantes.Max(p => p.Edad) }");
            Console.WriteLine($"el estudiante de menor edad tiene: { estudiantes.Min(p => p.Edad) }");
            Console.WriteLine($"El promedio de edad de los estudiantes es: {estudiantes.Average(p => p.Edad)}");
            Console.WriteLine($"La cantidad de cursos es: {cursos.LongCount(p=> p.Activo) }");


            var existeEstudianteSeleccionado = estudiantesFiltrada.Contains(estudiantes[5]);
            Console.WriteLine($"¿El Estudiante seleccionado esta en la lista? {existeEstudianteSeleccionado.ToString()}");

            Console.WriteLine(" --  CURSOS Filtrado -- ");
            foreach (var item in cursosFiltrada)
            {
                   Console.WriteLine($"     {item.Codigo} - {item.Nombre} - {item.CodigoEstudiante}");
            }
            Console.WriteLine();
            Console.WriteLine(" --  ESTUDIANTES Filtrada-- ");
            foreach (var item in estudiantesOrdenada)
            {
                Console.WriteLine($"Los estudiantes del curso: { item.Key }");

                foreach (var estudiante in item)
                {
                    Console.WriteLine($"        {estudiante.Codigo} - {estudiante.Nombre} {estudiante.Apellido}");
                }
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
