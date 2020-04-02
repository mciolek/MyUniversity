namespace MyUniversity.Migrations
{
    using MyUniversity.DAL;
    using MyUniversity.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyUniversity.DAL.SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstName = "Borys", LastName = "Maciejewski", EnrollmentDate = DateTime.Parse("2016-09-01")},
                new Student { FirstName = "Ariel", LastName = "Sawicki", EnrollmentDate = DateTime.Parse("2017-09-01")},
                new Student { FirstName = "Aureliusz", LastName = "Kaczmarczyk", EnrollmentDate = DateTime.Parse("2017-09-01")},
                new Student { FirstName = "Łukasz", LastName = "Czarnecki", EnrollmentDate = DateTime.Parse("2018-09-01")},
                new Student { FirstName = "Anastazy", LastName = "Sikora", EnrollmentDate = DateTime.Parse("2018-09-01")},
                new Student { FirstName = "Bogumił", LastName = "Błaszczyk", EnrollmentDate = DateTime.Parse("2018-09-01")},
                new Student { FirstName = "Kazimierz", LastName = "Kowalczyk", EnrollmentDate = DateTime.Parse("2019-09-01")},
                new Student { FirstName = "Konstanty", LastName = "Jaworski", EnrollmentDate = DateTime.Parse("2019-09-01")}
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstName = "Antoni", LastName = "Czerwiński", HireDate = DateTime.Parse("2016-07-01")},
                new Instructor { FirstName = "Czesław", LastName = "Piotrowski", HireDate = DateTime.Parse("2016-07-01")},
                new Instructor { FirstName = "Paweł", LastName = "Andrzejewski", HireDate = DateTime.Parse("2016-07-01")},
                new Instructor { FirstName = "Karol", LastName = "Sokołowski", HireDate = DateTime.Parse("2016-07-01")},
                new Instructor { FirstName = "Alojzy", LastName = "Woźniak", HireDate = DateTime.Parse("2016-07-01")}
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "Anglistyki", Budget = 350000, StartDate = DateTime.Parse("2016-06-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Czerwiński").ID },
                new Department { Name = "Matematyki", Budget = 350000, StartDate = DateTime.Parse("2016-06-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Piotrowski").ID },
                new Department { Name = "Inżynierii", Budget = 350000, StartDate = DateTime.Parse("2016-06-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Andrzejewski").ID },
                new Department { Name = "Ekonomiczny", Budget = 350000, StartDate = DateTime.Parse("2016-06-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Sokołowski").ID },
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { ID = 1050, Title = "Chemia", Credits =3,
                    DepartmentID = departments.Single(s => s.Name == "Inżynierii").ID, Instructors = new List<Instructor>() },
                new Course { ID = 4022, Title = "Mikroekonomia", Credits =3,
                    DepartmentID = departments.Single(s => s.Name == "Ekonomiczny").ID, Instructors = new List<Instructor>() },
                new Course { ID = 4041, Title = "Makroekonomia", Credits =3,
                    DepartmentID = departments.Single(s => s.Name == "Ekonomiczny").ID, Instructors = new List<Instructor>() },
                new Course { ID = 1045, Title = "Rachunek Różniczkowy", Credits =4,
                    DepartmentID = departments.Single(s => s.Name == "Matematyki").ID, Instructors = new List<Instructor>() },
                new Course { ID = 3141, Title = "Trygonometria", Credits =4,
                    DepartmentID = departments.Single(s => s.Name == "Matematyki").ID, Instructors = new List<Instructor>() },
                new Course { ID = 2021, Title = "Kompozycja", Credits =3,
                    DepartmentID = departments.Single(s => s.Name == "Anglistyki").ID, Instructors = new List<Instructor>() },
                new Course { ID = 2042, Title = "Literatura", Credits =4,
                    DepartmentID = departments.Single(s => s.Name == "Anglistyki").ID, Instructors = new List<Instructor>() }
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Piotrowski").ID, Location = "Adam 15"},
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Andrzejewski").ID, Location = "Jesień 200"},
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Sokołowski").ID, Location = "Domek 2"}
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InstructorID, s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Chemia", "Sokołowski");
            AddOrUpdateInstructor(context, "Chemia", "Andrzejewski");
            AddOrUpdateInstructor(context, "Mikroekonomia", "Woźniak");
            AddOrUpdateInstructor(context, "Makroekonomia", "Woźniak");

            AddOrUpdateInstructor(context, "Rachunek Różniczkowy", "Piotrowski");
            AddOrUpdateInstructor(context, "Trygonometria", "Andrzejewski");
            AddOrUpdateInstructor(context, "Kompozycja", "Czerwiński");
            AddOrUpdateInstructor(context, "Literatura", "Czerwiński");
            
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentID = students.Single(s => s.LastName == "Maciejewski").ID, 
                                    CourseID = courses.Single(c => c.Title == "Chemia").ID, 
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Maciejewski").ID,
                                    CourseID = courses.Single(c => c.Title == "Mikroekonomia").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Maciejewski").ID,
                                    CourseID = courses.Single(c => c.Title == "Makroekonomia").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Sawicki").ID,
                                    CourseID = courses.Single(c => c.Title == "Rachunek Różniczkowy").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Sawicki").ID,
                                    CourseID = courses.Single(c => c.Title == "Trygonometria").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Sawicki").ID,
                                    CourseID = courses.Single(c => c.Title == "Kompozycja").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Kaczmarczyk").ID,
                                    CourseID = courses.Single(c => c.Title == "Chemia").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Kaczmarczyk").ID,
                                    CourseID = courses.Single(c => c.Title == "Mikroekonomia").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Czarnecki").ID,
                                    CourseID = courses.Single(c => c.Title == "Chemia").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Sikora").ID,
                                    CourseID = courses.Single(c => c.Title == "Kompozycja").ID,
                                    Grade = Grade.A},
                new Enrollment { StudentID = students.Single(s => s.LastName == "Błaszczyk").ID,
                                    CourseID = courses.Single(c => c.Title == "Literatura").ID,
                                    Grade = Grade.A},
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                        s.Student.ID == e.StudentID &&
                        s.Course.ID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }

        private void AddOrUpdateInstructor(SchoolContext context, string courseTitle, string instructorName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var inst = context.Instructors.SingleOrDefault(i => i.LastName == instructorName);
            if (inst == null)
            {
                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
            }
        }
    }
}
