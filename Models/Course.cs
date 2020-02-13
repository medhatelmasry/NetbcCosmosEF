using System;
using System.Collections.Generic;

namespace NetbcCosmos.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public Room Room { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
    }

    public class Room
    {
        public string Building { get; set; }
        public int RoomNumber { get; set; }
    }

}