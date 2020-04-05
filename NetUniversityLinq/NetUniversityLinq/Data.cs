using System;
using System.Collections.Generic;

namespace NetUniversityLinq
{
    public static class Data
    {
        public static List<Curso> GetCursos()
        {
            List<Curso> cursos = new List<Curso>();
            cursos.Add(new Curso() { CursoId = 101, Codigo = "C001", Nombre = "CSharp de 0 a 100", FechaInicio = new DateTime(2021, 10, 1), Activo = true });
            cursos.Add(new Curso() { CursoId = 102, Codigo = "C002", Nombre = "Azure functions", FechaInicio = new DateTime(2021, 5, 15), Activo = true });
            cursos.Add(new Curso() { CursoId = 103, Codigo = "C003", Nombre = "Maquinas virtuales", FechaInicio = new DateTime(2021, 1, 30), Activo = true });
            cursos.Add(new Curso() { CursoId = 104, Codigo = "C004", Nombre = "Javascript", Activo = false });
            cursos.Add(new Curso() { CursoId = 105, Codigo = "C005", Nombre = "Introdución a cloud computing", Activo = true });

            return cursos;
        }

        public static List<Estudiante> GetEstudiantes()
        {
            List<Estudiante> cursos = new List<Estudiante>();

            cursos.Add(new Estudiante()
            {
                EstudianteId = 1,
                CursoId = 101,
                Codigo = "E001",
                Nombre = "Miguel",
                Apellido = "Teheran",
                Edad = 32,
                Activo = true
            });

            cursos.Add(new Estudiante()
            {
                EstudianteId = 2,
                CursoId = 101,
                Codigo = "E002",
                Nombre = "Eduardo",
                Apellido = "Alonso",
                Edad = 25,
                Activo = true
            });

            cursos.Add(new Estudiante()
            {
                EstudianteId = 3,
                CursoId = 101,
                Codigo = "E003",
                Nombre = "Hamilton",
                Apellido = "Renteria",
                Edad = 22,
                Activo = true
            });


            cursos.Add(new Estudiante()
            {
                EstudianteId = 4,
                CursoId = 102,
                Codigo = "E004",
                Nombre = "Lina",
                Apellido = "Ocampo",
                Edad = 19,
                Activo = true
            });


            cursos.Add(new Estudiante()
            {
                EstudianteId = 5,
                CursoId = 102,
                Codigo = "E005",
                Nombre = "Diego",
                Apellido = "Bustamante",
                Edad = 28,
                Activo = true
            });

            cursos.Add(new Estudiante()
            {
                EstudianteId = 6,
                CursoId = 102,
                Codigo = "E006",
                Nombre = "Alejandro",
                Apellido = "Sierra",
                Edad = 35,
                Activo = true
            });

            cursos.Add(new Estudiante()
            {
                EstudianteId = 7,
                CursoId = 103,
                Codigo = "E007",
                Nombre = "Victor",
                Apellido = "Andrade",
                Edad = 24,
                Activo = false
            });

            cursos.Add(new Estudiante()
            {
                EstudianteId = 8,
                CursoId = 0,
                Codigo = "E008",
                Nombre = "Eliana",
                Apellido = "Gonzalez",
                Edad = 26,
                Activo = true
            });


            cursos.Add(new Estudiante()
            {
                EstudianteId = 9,
                CursoId = 103,
                Codigo = "E009",
                Nombre = "Paola",
                Apellido = "Miranda",
                Edad = 23,
                Activo = false
            });

            return cursos;
        }
    }

    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
    }

    public class Curso
    {
        public int CursoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public bool Activo { get; set; }
    }
}