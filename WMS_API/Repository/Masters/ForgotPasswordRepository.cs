using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using POM.Repository;
using System.Data;
using System.Data.SqlClient;
using Librarys;
using Librarys.Extenders;
using System.Configuration;

namespace POMS.Repository
{
     public class ForgotPasswordRepository:RepositoryBaseNew
    {
        string RegardsBy = System.Configuration.ConfigurationManager.ConnectionStrings["RegardsBy"].ToString();

        const string _ForGotPwd = "USP_FORGOT_PASSWORD";
        public string ForgotPassword(ForgotPassword objForgotPassword)
        {
            List<SqlParameter> Params = new List<SqlParameter>();
            SqlParameter UserName = new SqlParameter("@UserName", objForgotPassword.UserName);
            UserName.SqlDbType = SqlDbType.NVarChar;
            Params.Add(UserName);

            SqlParameter REGARDS_BY = new SqlParameter("@REGARDS_BY", objForgotPassword.REGARDS_BY);
            REGARDS_BY.SqlDbType = SqlDbType.NVarChar;
            Params.Add(REGARDS_BY);

            DataSet ds = MasterExecuteCommand(_ForGotPwd, Params);
            string Result = ds.Tables[0].Rows[0][0].ToString();
            return Result;

        }
    }
}
