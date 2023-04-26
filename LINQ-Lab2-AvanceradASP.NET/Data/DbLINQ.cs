using LINQ_Lab2_AvanceradASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQ_Lab2_AvanceradASP.NET.Data
{
    class DbLINQ : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Subject> Subject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-5M0EIGI; Initial Catalog=LINQLab; Integrated Security= True;");
        }
    }
}
