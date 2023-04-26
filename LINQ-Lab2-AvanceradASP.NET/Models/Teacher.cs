using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LINQ_Lab2_AvanceradASP.NET.Models
{
    public class Teacher
    {
        [Key][Required]
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        //1 lärare har 1 ämne
        public Subject Subject { get; set; }
        //public ICollection<Course> Courses { get; set; }
    }
}
