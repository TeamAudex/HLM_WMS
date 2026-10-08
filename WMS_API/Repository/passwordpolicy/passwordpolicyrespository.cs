using POMS.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POM.Repository;
using System.Data;
using Librarys;
using Librarys.Extenders;


namespace POMS.Repository
{
    public class passwordpolicyrespository : RepositoryBaseNew
    {
        const string _password_Insert = "PasswordCreation";
        const string UserDetails_fetch = "GetUserName";
        const string UserDetails_Already_Exists= "PasswordAlreadyExists";
        public UserMas GetUser(string UserCode)
        {
            UserMas objUserMasDetails = new UserMas();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserCode", UserCode));
            DataSet dataSet = ExecuteCommand(UserDetails_fetch, parameters);
            try
            {
                objUserMasDetails = dataSet.Tables[0].ToCustomList<UserMas>().FirstOrDefault();
            }
            catch (Exception ex) { }
            return objUserMasDetails;
        }
        public string CheckalreadyExists(string UserCode, string password)
        {
            string CheckFlag = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserCode", UserCode));
            parameters.Add(new SqlParameter("@password", password));
            DataSet dataSet = ExecuteCommand(UserDetails_Already_Exists, parameters);
            try
            {
                CheckFlag = dataSet.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex) { }
            return CheckFlag;
        }
        public Tuple<string, bool> InsertPassword(UserMas objUser)
        {
            string strMessage = "";
            bool errSts = false;
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter paramUserSno = new SqlParameter("@UserSno", objUser.UserSno);
                paramUserSno.SqlDbType = SqlDbType.Int;
                sqlParameters.Add(paramUserSno);

                SqlParameter paramUserCode = new SqlParameter("@UserCode", objUser.UserCode);
                paramUserCode.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(paramUserCode);

                SqlParameter paramUserName = new SqlParameter("@UserName", objUser.UserName);
                paramUserName.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(paramUserName);

                SqlParameter paramType = new SqlParameter("@Type", objUser.Type);
                paramType.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(paramType);

                SqlParameter parampassword = new SqlParameter("@password", objUser.password);
                parampassword.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(parampassword);

                SqlParameter paramOpassword = new SqlParameter("@Opassword", objUser.Opassword);
                paramOpassword.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(paramOpassword);

                SqlParameter paramconfirmPassword = new SqlParameter("@confirmPassword", objUser.confirmPassword);
                paramconfirmPassword.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(paramconfirmPassword);

                SqlParameter paramIPNumber = new SqlParameter("@IPNumber", objUser.IPNumber);
                paramIPNumber.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(paramIPNumber);

                SqlParameter paramCreOpr = new SqlParameter("@CreOpr", objUser.UserSno);
                paramCreOpr.SqlDbType = SqlDbType.Int;
                sqlParameters.Add(paramCreOpr);

                SqlParameter paramURLpath = new SqlParameter("@URLpath", objUser.URLpath);
                paramURLpath.SqlDbType = SqlDbType.VarChar;
                sqlParameters.Add(paramURLpath);

                SqlParameter paramSts = new SqlParameter("@sts", objUser.sts);
                paramSts.SqlDbType = SqlDbType.Bit;
                sqlParameters.Add(paramSts);

                DataSet ds = ExecuteCommand(_password_Insert, sqlParameters);
                strMessage = ds.Tables[0].Rows[0][0].ToString();
                errSts = Convert.ToBoolean(ds.Tables[0].Rows[0][1].ToString());
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
                errSts = true;
            }
            return new Tuple<string, bool>(strMessage, errSts);
        }
    }
}
