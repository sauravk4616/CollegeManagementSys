using CollegeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Repository
{
    public class SemesterFeeRep : ISemesterFeeRep
    {
        ClgManagementContext db;
        public SemesterFeeRep(ClgManagementContext _db)
        {
            db = _db;
        }

        public List<SemesterFee> GetDetails()
        {
            return db.SemesterFee.ToList();
        }

        public SemesterFee GetDetail(int id)
        {
            if (db != null)
            {
                return (db.SemesterFee.Where(x => x.Semester == id)).FirstOrDefault();
            }
            return null;
        }

        public int AddDetail(SemesterFee emp)
        {
            db.SemesterFee.Add(emp);
            db.SaveChanges();

            return emp.Semester;
        }



        public int UpdateDetail(int id, SemesterFee emp)
        {
            if (db != null)
            {
                var obj = (db.SemesterFee.Where(x => x.Semester == id)).FirstOrDefault();
                if (obj != null)
                {
                    obj.Fee = emp.Fee;
                   
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.SemesterFee.FirstOrDefault(x => x.Semester == id);

                if (post != null)
                {

                    db.SemesterFee.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;

        }

    }
}
