using CollegeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Repository
{
    interface ISemesterFeeRep
    {
        public List<SemesterFee> GetDetails();
        public SemesterFee GetDetail(int id);
        public int AddDetail(SemesterFee emp);
        public int UpdateDetail(int id, SemesterFee emp);
        public int Delete(int id);
    }
}
