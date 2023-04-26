using System;
using LINQ_Lab2_AvanceradASP.NET.Models;
using LINQ_Lab2_AvanceradASP.NET.Data;
using LINQ_Lab2_AvanceradASP.NET.Migrations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;

namespace LINQ_Lab2_AvanceradASP.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runmenu=true;

            do
            {

                Console.WriteLine("************************************************");
                Console.WriteLine("*                    Menu                      *");
                Console.WriteLine("*                                              *");
                Console.WriteLine("*        1.Get all teachers in math            *");
                Console.WriteLine("*        2.Get all students and their teachers *");
                Console.WriteLine("*        3.See if subject exists               *");
                Console.WriteLine("*        4.Change name of subject              *");
                Console.WriteLine("*        5.Change course of student            *");
                Console.WriteLine("*        6.Exit                                *");
                Console.WriteLine("*                                              *");              
                Console.WriteLine("************************************************");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckTeacher();                        
                        break;
                    case 2:
                        ListofStudents();                       
                        break;
                    case 3:
                        CheckSubject();                        
                        break;
                    case 4:
                        ChangeSubject();                        
                        break;
                    case 5:
                        ChangeStudentsCourse();                        
                        break;
                    case 6:
                        Console.WriteLine("Goodbye :) ");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (runmenu);

            Console.ReadKey();


        }
        public static void CheckTeacher()
        {
            DbLINQ context = new DbLINQ();

            var mteach = from s in context.Subject
                         where s.NameofSubject == "Matte"
                         join t in context.Teacher on s.TeacherId equals t.TeacherId
                         select new
                         {
                             fName = t.FirstName,
                             lName = t.LastName
                         };

            foreach (var item in mteach)
            {
                Console.WriteLine("Teacher in 'Matte' is : {0} {1}", item.fName, item.lName);
            }
        }
        public static void CheckSubject()
        {
            DbLINQ context = new DbLINQ();
            
            bool checkS = context.Subject.Any(x => x.NameofSubject == "Programmering");

            if (checkS)
            {
                Console.WriteLine("Subject 'Programmering' exists.");
            }
            else
            {
                Console.WriteLine("Subject 'Programmering' does not exist.");
            }

        }
        public static void ChangeSubject()
        {
            DbLINQ context = new DbLINQ();

            var changeSubj = context.Subject.Where(x => x.NameofSubject == "Programmering");

            foreach (var subj in changeSubj)
            {
                Console.WriteLine("Subject '{0}' will change name to 'OOP'.", subj.NameofSubject);
                subj.NameofSubject = "OOP";
                Console.WriteLine("Subject is now '{0}'.", subj.NameofSubject);
            }
            //context.SaveChanges();
        }
        public static void ListofStudents()
        {
            DbLINQ context = new DbLINQ();

            var studsWteacher = from course in context.Course
                                join stud in context.Student
                                on course.CourseId equals stud.CourseId
                                join sub in context.Subject
                                on course.CourseId equals sub.CourseId
                                join teach in context.Teacher
                                on sub.SubjectId equals teach.TeacherId
                                where course.CourseId == stud.CourseId && course.CourseId == sub.CourseId
                                select new
                                {
                                    StudentName = stud.FirstName + " " + stud.LastName,
                                    TeacherName = teach.FirstName + " " + teach.LastName,
                                    Class = course.NameofCourse
                                };
            foreach (var st in studsWteacher)
            {
                Console.WriteLine("Course: {0} \t Student: {1} \t  Teacher: {2}",st.Class, st.StudentName, st.TeacherName);

            }
        }
        public static void ChangeStudentsCourse()
        {
            DbLINQ context = new DbLINQ();

            var updateCourse = context.Student.FirstOrDefault(s => s.StudentId == 5);
            updateCourse.CourseId = 3;

            //context.SaveChanges();

            var newCourseForStudent = from s in context.Student
                                      join c in context.Course
                                      on s.CourseId equals c.CourseId
                                      where s.StudentId == 5
                                      select new
                                      {
                                          NameofStudent = s.FirstName + " " + s.LastName,
                                          Id = c.CourseId,
                                          Class = c.NameofCourse
                                      };

            foreach (var cou in newCourseForStudent)
            {
                Console.WriteLine("Student: {0} now goes in Course: {1}", cou.NameofStudent, cou.Class);

            }
        }
    }
}
