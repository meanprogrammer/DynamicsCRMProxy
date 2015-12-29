using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {

        public List<Entity.test.Student> GetAllStudent()
        {
            return StudentData.GetAllStudent();
        }

        public Entity.test.Student GetOneStudent(Guid id)
        {
            return StudentData.GetOneStudent(id);
        }
    }
}
