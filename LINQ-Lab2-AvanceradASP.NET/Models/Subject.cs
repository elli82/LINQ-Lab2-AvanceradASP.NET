using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LINQ_Lab2_AvanceradASP.NET.Models
{
    public class Subject
    {
        [Key][Required]
        public int SubjectId { get; set; }
        public string NameofSubject { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        //ämnen tillhör en klass      
        public Course Course { get; set; }
        //1 ämnen har 1 lärare
        public Teacher Teacher { get; set; }
    }
}
