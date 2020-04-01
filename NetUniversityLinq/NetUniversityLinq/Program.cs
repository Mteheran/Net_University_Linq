using System;
using System.Collections.Generic;
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
                                 where c.Activo && c.FechaInicio?.Month == 10
                                 select c;
            var estudiantesFiltrada = estudiantes.Where((p,i) => p.Activo && i > 3);

            var existeEstudianteSeleccionado = estudiantesFiltrada.Contains(estudiantes[5]);
            Console.WriteLine($"¿El Estudiante seleccionado esta en la lista? {existeEstudianteSeleccionado.ToString()}");

            Console.WriteLine(" --  CURSOS Filtrado -- ");
            foreach (var item in cursosFiltrada)
            {
                Console.WriteLine($"{item.Codigo} - {item.Nombre}");
            }
            Console.WriteLine();
            Console.WriteLine(" --  ESTUDIANTES Filtrada-- ");
            foreach (var item in estudiantesFiltrada)
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
}
