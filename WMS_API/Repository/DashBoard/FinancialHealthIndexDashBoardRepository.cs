using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Librarys;
using Librarys.Extenders;
using POMS.Entity;
using POM.Repository;

namespace POMS.Repository
{
    public class FinancialHealthIndexRepository : RepositoryBaseNew
    {
        const string sp_dashboard = "FHIDshAll";

        public List<DshFHITot> DshAll(int UserSno, string FromDate, string ToDate, string FlowFlag)
        {
            List<DshFHITot> objDshTotalDatas = new List<DshFHITot>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@FromDate", FromDate));
            parameters.Add(new SqlParameter("@ToDate", ToDate));
            parameters.Add(new SqlParameter("@FlowFlag", FlowFlag));
            DataSet dataSet = ExecuteCommand(sp_dashboard, parameters);

            objDshTotalDatas = dataSet.Tables[0].ToCollection<DshFHITot>();              

            return objDshTotalDatas;
        }
    }
}
