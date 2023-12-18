using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
   public  interface IEmpInfoRepository
    {
        EmpInfo GetEmpInfoByEmialId(string EmailId);
        IEnumerable<EmpInfo> GetAllEmpInfos();
        void AddEmpInfo(EmpInfo empInfo);
        void UpdateEmpInfo(EmpInfo empInfo);
        void DeleteEmpInfo(int empInfoId);
        void SaveChanges();
        bool DeleteEmpInfoTest(int empId);
        EmpInfo GetEmpInfoById(int EmpInfoId);
    }
}
