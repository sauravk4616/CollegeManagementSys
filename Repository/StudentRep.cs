using CollegeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Repository
{
    public class StudentRep : IStudentRep
    {
        ClgManagementContext db;
        public StudentRep(ClgManagementContext _db)
        {
            db = _db;
        }

        public List<Student> GetDetails()
        {
            return db.Student.ToList();
        }

        public Student GetDetail(string id)
        {
            if (db != null)
            {
                return (db.Student.Where(x => x.EnrollmentNo == id)).FirstOrDefault();
            }
            return null;
        }

        public int AddDetail(Student emp)
        {
            db.Student.Add(emp);
            db.SaveChanges();

            return 1;
        }



        public int UpdateDetail(string id, Student emp)
        {
            if (db != null)
            {
                var obj = (db.Student.Where(x => x.EnrollmentNo == id)).FirstOrDefault();
                if (obj != null)
                {
                    obj.StudentName = emp.StudentName;
                    obj.Age = emp.Age;
                    obj.Branch = emp.Branch;
                    obj.Semester = emp.Semester;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public int Delete(string id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.Student.FirstOrDefault(x => x.EnrollmentNo == id);

                if (post != null)
                {

                    db.Student.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;

        }

        
    }
}
