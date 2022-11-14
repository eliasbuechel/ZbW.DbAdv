using EFCoreDemo.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCoreDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // Updating...
            // using (var context = new Context)
            // context.Data

            // DoSave();
            DoQuery();
        }


        public static void DoQuery()
        {
            using (var context = new CourseContext())
            {
                //var c1 = context.Courses.Find(3);
                //var c2 = context.Courses.Find(3);


                // mit .Include("Courses").ToList() wird mit eager loading gearbeitet
                var author = context.Authors.Include("Courses").ToList().Single(x => x.Id == 4);
                foreach (var course in author.Courses)
                {
                    Console.WriteLine(course.Title);
                }

                
                var query = from c in context.Courses.Include("Author").ToList()
                            where c.Title.Contains("c#")
                            orderby c.Title
                            select c;
                foreach (var course in query)
                {
                    // Autor wird mit lazy loding geladen
                    Console.WriteLine($"Kurstitel: {course.Title}, Autor: {course.Author.Name}");
                }
            }
        }

        public static void DoSave()
        {
            using (var context = new CourseContext())
            {
                var author = new Author { Name = "Mark Büchel" };
                var course = new Course
                {
                    Title = "The great C# course",
                    Author = author,
                    Description = "blabla",
                    Level = CourseLevel.Advanced,
                    FullPrice = 2500.23m,
                };

                var category = new Category { Name = "Hans" };
                course.Category = category;

                context.Courses.Add(course);
                context.SaveChanges();
            }
            
        }
    }
}
