using Librarys.Extenders;
using POM.Repository;
using POMS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Repository
{
    public class PODDashboardRepository : RepositoryBaseNew
    {
        const string POD_dashboard = "USP_POD_DASHBORD";
        public List<PODInvoiceDet> LoadData(int UserSno,string RoleFlag)
        {
            List<PODInvoiceDet> ObjResponse = new List<PODInvoiceDet>();

            List<SqlParameter> Parameters = new List<SqlParameter>();

            SqlParameter ParamUserSno = new SqlParameter("@UserSno", UserSno);
            ParamUserSno.SqlDbType = SqlDbType.Int;
            Parameters.Add(ParamUserSno);

            SqlParameter ParamRoleFlag = new SqlParameter("@RoleFlag", RoleFlag);
            ParamRoleFlag.SqlDbType = SqlDbType.VarChar;
            Parameters.Add(ParamRoleFlag);

            try
            {
                DataSet ds = ExecuteCommand(POD_dashboard, Parameters);
                ObjResponse = ds.Tables[0].ToCollection<PODInvoiceDet>();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return ObjResponse;
        }


        public string LogStatus(int UserSno, string Ipaddress)
        {
            string result = "";
            List<SqlParameter> Parameters = new List<SqlParameter>();

            SqlParameter ParamUserSno = new SqlParameter("@UserSno", UserSno);
            ParamUserSno.SqlDbType = SqlDbType.Int;
            Parameters.Add(ParamUserSno);

            SqlParameter ParamIpaddress = new SqlParameter("@Ipaddress", Ipaddress);
            ParamIpaddress.SqlDbType = SqlDbType.VarChar;
            Parameters.Add(ParamIpaddress);

            DataSet ds = ExecuteCommand("Logoutsts", Parameters);
            result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }
    }
}
