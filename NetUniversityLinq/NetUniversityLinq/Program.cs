﻿using System;
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

            var cursosFiltrada = (from c in cursos 
                                 orderby c.Nombre, c.Codigo
                                 group c by new { c.Activo, c.FechaInicio} into todosLosCursos
                                 select todosLosCursos);
            var estudiantesFiltrada = estudiantes.Where((p,i) => p.Activo && i > 3).OrderByDescending(p=> p.CursoId).ThenBy(p=> p.Nombre);

            var estudiantesOrdenada = estudiantesFiltrada.ToList().Select(p=> new { p.CursoId, p.Codigo, p.Nombre, p.Apellido }).ToLookup(p=> p.CursoId);

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
                Console.WriteLine($"Los cursos que estan en estado:  {item.Key.Activo} e inician en {item.Key.FechaInicio?.Date} ");

                foreach (var curso in item)
                {
                   Console.WriteLine($"     {curso.Codigo} - {curso.Nombre}");
                }
            }
            Console.WriteLine();
            Console.WriteLine(" --  ESTUDIANTES Filtrada-- ");
            foreach (var item in estudiantesOrdenada)
            {
                Console.WriteLine($"Los estudiantes del curso: { cursos.First(p => p.CursoId == item.Key).Nombre}");

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
