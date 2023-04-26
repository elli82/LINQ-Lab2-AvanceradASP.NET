using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LINQ_Lab2_AvanceradASP.NET.Models
{
    public class Student
    {
        [Key][Required]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
        //1 student går i 1 klass
        public Course Course { get; set; }
    }
}
