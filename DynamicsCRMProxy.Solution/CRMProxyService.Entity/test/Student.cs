using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity.test
{
    public class Student
    {
        public Student()
        {
            Months = new Dictionary<int, string>();
            Months.Add(1, "Jan");
            Months.Add(2, "Feb");
            Months.Add(3, "March");
            Months.Add(4, "April");
            Months.Add(5, "May");
            Months.Add(6, "June");
        }

        public Guid StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }
        public int BirthMonth { get; set; }
        public Dictionary<int, string> Months { get; set; }
    }
}
