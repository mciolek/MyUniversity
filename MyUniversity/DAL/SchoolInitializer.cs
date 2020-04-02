using MyUniversity.Models;
using System;
using System.Collections.Generic;

namespace MyUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstName = "Borys", LastName = "Maciejewski", EnrollmentDate = DateTime.Parse("2017-09-01")},
                new Student { FirstName = "Ariel", LastName = "Sawicki", EnrollmentDate = DateTime.Parse("2017-09-01")},
                new Student { FirstName = "Aureliusz", LastName = "Kaczmarczyk", EnrollmentDate = DateTime.Parse("2017-09-01")},
                new Student { FirstName = "Łukasz", LastName = "Czarnecki", EnrollmentDate = DateTime.Parse("2018-09-01")},
                new Student { FirstName = "Anastazy", LastName = "Sikora", EnrollmentDate = DateTime.Parse("2018-09-01")},
                new Student { FirstName = "Bogumił", LastName = "Błaszczyk", EnrollmentDate = DateTime.Parse("2018-09-01")},
                new Student { FirstName = "Kazimierz", LastName = "Kowalczyk", EnrollmentDate = DateTime.Parse("2019-09-01")},
                new Student { FirstName = "Konstanty", LastName = "Jaworski", EnrollmentDate = DateTime.Parse("2019-09-01")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { ID = 1050, Title = "Chemia", Credits =3},
                new Course { ID = 4022, Title = "Mikroekonomia", Credits =3},
                new Course { ID = 4041, Title = "Makroekonomia", Credits =3},
                new Course { ID = 1045, Title = "Rachunek Różniczkowy", Credits =4},
                new Course { ID = 3141, Title = "Trygonometria", Credits =4},
                new Course { ID = 2021, Title = "Kompozycja", Credits =3},
                new Course { ID = 2042, Title = "Literatura", Credits =4},
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentID = 1, CourseID = 1050, Grade=Grade.A},
                new Enrollment { StudentID = 1, CourseID = 4022, Grade=Grade.C},
                new Enrollment { StudentID = 1, CourseID = 4041, Grade=Grade.B},
                new Enrollment { StudentID = 2, CourseID = 1045, Grade=Grade.B},
                new Enrollment { StudentID = 2, CourseID = 3141, Grade=Grade.F},
                new Enrollment { StudentID = 2, CourseID = 2021, Grade=Grade.F},
                new Enrollment { StudentID = 3, CourseID = 1050},
                new Enrollment { StudentID = 4, CourseID = 1050},
                new Enrollment { StudentID = 4, CourseID = 4022, Grade=Grade.F},
                new Enrollment { StudentID = 5, CourseID = 4041, Grade=Grade.C},
                new Enrollment { StudentID = 6, CourseID = 1045},
                new Enrollment { StudentID = 7, CourseID = 3141, Grade=Grade.A},
            };
            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
        }
    }
}