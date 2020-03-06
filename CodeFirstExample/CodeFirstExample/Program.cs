using CodeFirstExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFContext context = new EFContext())
            {
                context.Persons.Add(new Person()

                {
                    Name = "Bober",
                    DatoOfBirth = DateTime.Now,
                    Descripton = "Жирний бобер",
                    Gender = true
                });
                context.SaveChanges();
                foreach(var item in context.Persons.Include(t=>t.PersonCourseOf).ToList())
                {
                    Console.WriteLine(item.Name);
                    foreach(var course in item.PersonCourseOf)
                    {
                        Console.WriteLine($"Курс: {course.CourseOf.Name}");
                    }
                }
            }
        }
    }
}
