using CRMProxyService.Entity.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProxyService.test
{
    public class StudentData
    {
        private static List<Student> data;
        public StudentData()
        {
            if (data == null)
            {
                data = LoadDefault();
            }
        }

        public static void AddStudent(Student s)
        {
            data.Add(s);
        }

        public static Student GetOneStudent(Guid id)
        {
            return data.Where(c => c.StudentID == id).FirstOrDefault();
        }

        public static List<Student> GetAllStudent()
        {
            return data;
        }
        
        static List<Student> LoadDefault()
        {
            List<Student> sss = new List<Student>();
            sss.Add(
                    new Student() { 
                        StudentID = Guid.NewGuid(),
                        LastName = "Dudan",
                        FirstName = "Valiant",
                        MI = "A",
                    }
                );
            return sss;
        }
    }
}