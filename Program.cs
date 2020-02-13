using System;
using System.Collections.Generic;
using System.Linq;
using NetbcCosmos.Data;
using NetbcCosmos.Models;

namespace NetbcCosmos
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertSimpleCourse();
            //updateOneCourse("0afd2f69-8e2c-48d7-bb41-22df6234bffa");
            //deleteOneCourse("0afd2f69-8e2c-48d7-bb41-22df6234bffa");
            InsertCourseWithStudents();
            dispCourses();
        }

        static void deleteOneCourse(string id)
        {
            Guid g = new Guid(id);
            using (var context = new SchoolContext())
            {
                var course = context.Courses.Find(g);
                if (course != null)
                {
                    context.Courses.Remove(course);
                    context.SaveChanges();
                    Console.WriteLine($"Course with ID={id} has been DELETED");
                }
            }
        }


        static void InsertSimpleCourse()
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Number = "COMP1234",
                Description = "ASP.NET Essentials",
                Room = new Room
                {
                    Building = "SE6",
                    RoomNumber = 127
                }
            };
            using (var context = new SchoolContext())
            {
                context.Database.EnsureCreated();
                context.Add(course);
                context.SaveChanges();
            }
        }

        static void dispCourses()
        {
            using (var context = new SchoolContext())
            {
                var courses = context.Courses.ToList();
                foreach (var course in courses)
                {
                    displayCourseInfo(course);
                    Console.WriteLine("===========================================");
                }
            }
        }

        static void displayCourseInfo(Course course)
        {
            Console.WriteLine($"{course.Description}");
            Console.WriteLine($"   ID: {course.Id}");
            Console.WriteLine($"   NUMBER: {course.Number}");
            Console.WriteLine($"   ROOM: {course.Room.Building}, {course.Room.RoomNumber}");
            if (course.Students == null || course.Students.Count == 0)
            {
                Console.WriteLine("   NO STUDENTS");
            }
            else
            {
                Console.WriteLine($"   Students: {course.Students.Count()}");
                course.Students.ForEach(x =>
                {
                    Console.WriteLine($"       ID: {x.StudentId} Name: {x.FirstName} {x.LastName}, {x.Gender}");
                });
            }
        }

        static void updateOneCourse(string id)
        {
            Guid g = new Guid(id);
            using (var context = new SchoolContext())
            {
                var course = context.Courses.Find(g);
                if (course != null)
                {
                    course.Room.Building = "NE1";
                    course.Room.RoomNumber = 123;
                    context.SaveChanges();
                    Console.WriteLine($"Course with ID={id} has been UPDATED");
                }
            }
        }

        static Guid InsertCourseWithStudents()
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Number = "COMP3717",
                Description = "Android Development",
                Room = new Room
                {
                    Building = "SE12",
                    RoomNumber = 322
                },
                Students = new List<Student>() {
                    new Student {
                        StudentId = "A00111111",
                        FirstName = "Bob",
                        LastName = "Fox",
                        Gender = "Male"
                    },
                    new Student {
                        StudentId = "A00222222",
                        FirstName = "Ann",
                        LastName = "Fay",
                        Gender = "Female"
                    }
                }
            };

            using (var context = new SchoolContext())
            {
                context.Database.EnsureCreated();
                context.Add(course);
                context.SaveChanges();
            }

            return course.Id;
        }


    }
}
