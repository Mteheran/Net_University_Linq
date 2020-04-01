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
