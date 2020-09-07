using CollegeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Repository
{
    public interface IStudentRep
    {
        public List<Student> GetDetails();
        public Student GetDetail(string id);
        public int AddDetail(Student emp);
        public int UpdateDetail(string id, Student emp);
        public int Delete(string id);
    }
}
