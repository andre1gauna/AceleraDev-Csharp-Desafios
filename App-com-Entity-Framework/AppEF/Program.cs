using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppEF
{   
    class Program
    {

        static void Main(string[] args)
        {
            List<Student> Students = new List<Student>
            {
                new Student { Name = "Andre", PhoneNumber = "77947586", BirthDate = DateTime.Parse("12/03/1999") },
                new Student { Name = "Paulo", PhoneNumber = "93947586", BirthDate = DateTime.Parse("12/09/1998") },
                new Student { Name = "Joao", PhoneNumber = "83947586", BirthDate = DateTime.Parse("12/07/1997") },
                new Student { Name = "Marcos", PhoneNumber = "23957586", BirthDate = DateTime.Parse("12/04/1995") }
            };
            Course Course = new Course { CourseName = "C#", Students = Students };

            
            //AddCourse(Course);
            //RemoveCourse(Course);
            ShowCourseAndStudents();


            Console.ReadKey();           

        }

        static void AddCourse(Course course)
        {
            using (var contexto = new SchoolContext())
            {
                contexto.Courses.Add(course);
                contexto.SaveChanges();
            }
        }
        static void RemoveCourse(Course Course)
        {
            using var contexto = new SchoolContext();
            contexto.Courses.Remove(Course);
            contexto.SaveChanges();
        }
        static void UpdateCourse(Course Course)
        {
            using (var contexto = new SchoolContext())
            {
                contexto.Courses.Update(Course);
                contexto.SaveChanges();
            }
        }
        static void ShowCourseAndStudents()
        {
            using (var contexto = new SchoolContext())
            {
                IList<Course> CourseList = new List<Course>();
                CourseList = contexto.Courses.Include(x=>x.Students).ToList();
                foreach (Course q in CourseList)
                {
                    Console.WriteLine(q);
                    //foreach (Student s in contexto.Students.Where(x=>x.CourseId == q.CourseId))
                    foreach (Student s in q.Students)
                    {
                        Console.WriteLine(s.Name);
                    }
                }

            }
        }
    }
}
