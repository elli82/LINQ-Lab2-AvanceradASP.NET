using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LINQ_Lab2_AvanceradASP.NET.Models
{
    public class Course
    {
        [Key][Required]
        public int CourseId { get; set; }
        public string NameofCourse { get; set; }
        //public int StudentId { get; set; }
        //public string TeacherId { get; set; }  //creata a teacherid here

        
        //public ICollection<Teacher> Teachers { get; set; }
        //1 klass har många studenter
        public ICollection<Student> Students { get; set; }
        //1 klass har flera ämnen
        public ICollection<Subject> Subjects { get; set; }

    }
}
