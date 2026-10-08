using POMS.Entity.Masters;
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
using Entity.Masters;
using POMS.Entity;

namespace Repository.Masters
{
  public class UserwarehousemapRepository : RepositoryBaseNew
    {
        const string Load_Organisation_All = "Usp_UserBranchMap_LoadScreen";
        const string Get_Employee_AutoComplete = "USP_UserBranchMap_AutoComplete";
        const string UserBranchMap_Insert = "USP_UserBranchMap_Insert";
        const string UserBranchMap_Search = "USP_UserBranchMap_Search";
        const string UserBranchMap_Edit = "USP_UserBranchMap_Edit";
        public List<UserBranchMapGrid> LoadUserBranchMap(int EmployeeSno)
        {
            List<UserBranchMapGrid> ObjUserBranchMap = new List<UserBranchMapGrid>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmployeeSno", EmployeeSno));
            DataSet dataSet = MasterExecuteCommand(Load_Organisation_All, parameters);
            DataTable dt = new DataTable();
            ObjUserBranchMap = dataSet.Tables[0].ToCollection<UserBranchMapGrid>();
            return ObjUserBranchMap;
        }
        public List<UserBranchMap> GetUserBranchAutoComplete(string Condition, int Condition1)
        {
            List<UserBranchMap> objautoComplete = new List<UserBranchMap>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", Condition));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            DataSet dataSet = MasterExecuteCommand(Get_Employee_AutoComplete, parameters);
            DataTable dtRefNo = new DataTable();
            objautoComplete = dataSet.Tables[0].ToCollection<UserBranchMap>();
            return objautoComplete;
        }


        const string _get_autocomplete_ = "USP_UserBranch_Autocomplete";
        public List<UserBranchMapGrid> GetUserBranchMapComplete(string Typedtxt, int Condition1, int Condition2)
        {
            List<UserBranchMapGrid> objautoComplete = new List<UserBranchMapGrid>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TypeText", Typedtxt));
            parameters.Add(new SqlParameter("@Condition", Condition1));
            parameters.Add(new SqlParameter("@Condition1", Condition2));
            DataSet dataSet = MasterExecuteCommand(_get_autocomplete_, parameters);
            objautoComplete = dataSet.Tables[0].ToCollection<UserBranchMapGrid>();
            return objautoComplete;
        }

        public string InsertUserBranchMap(UserBranchMapSearch UserBranchMap)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter UserBranchMapSno = new SqlParameter("@UserBranchMapSno", UserBranchMap.UserBranchMap.UserBranchMapSno);
            UserBranchMapSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(UserBranchMapSno);

            SqlParameter EmployeeSno = new SqlParameter("@EmployeeSno", UserBranchMap.UserBranchMap.EmployeeSno);
            EmployeeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(EmployeeSno);

            SqlParameter ParamsCreopr = new SqlParameter("@Creop", UserBranchMap.UserBranchMap.Creopr);
            ParamsCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(ParamsCreopr);

            SqlParameter ParamsActionName = new SqlParameter("@ActionName", UserBranchMap.UserBranchMap.ActionName);
            ParamsActionName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(ParamsActionName);

            SqlParameter Paramsurl = new SqlParameter("@url", UserBranchMap.UserBranchMap.url);
            Paramsurl.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(Paramsurl);

            SqlParameter ParamsIpNumber = new SqlParameter("@IpNumber", UserBranchMap.UserBranchMap.IPNumber);
            ParamsIpNumber.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(ParamsIpNumber);


            SqlParameter paramUserCustomerMapDetails = new SqlParameter();
            paramUserCustomerMapDetails.ParameterName = "@UserBranchMapWiseDetails";
            paramUserCustomerMapDetails.SqlDbType = SqlDbType.Structured;
            paramUserCustomerMapDetails.Value = UserBranchMap.UserBranchMapWiseDetails.ToDataTable<UserBranchMapGrid>();
            paramUserCustomerMapDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(paramUserCustomerMapDetails);
            DataSet ds = MasterExecuteCommand(UserBranchMap_Insert, sqlParameters);
            string Result = ds.Tables[0].Rows[0][0].ToString();
            return Result;
        }


        public Tuple<List<UserBranchMap>, int> UserBranchMapSearch(PageRequest pageRequest)
        {
            List<UserBranchMap> objUserBranch = new List<UserBranchMap>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                    parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                    parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                    parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                    parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                    parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(UserBranchMap_Search, parameters, ref recordCount);

                    objUserBranch = dataSet.Tables[0].ToCollection<UserBranchMap>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<UserBranchMap>, int>(objUserBranch, recordCount);
        }
        public UserBranchMapSearch UserBranchMapEdit(int Sno)
        {
            SqlParameter paramActionID = new SqlParameter("@EmployeeSno", Sno);
            SqlCommand sqlCmd = new SqlCommand(UserBranchMap_Edit);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            UserBranchMapSearch objUserBranchMapDetail = new UserBranchMapSearch();
            objUserBranchMapDetail.UserBranchMap = new UserBranchMap();
            objUserBranchMapDetail.UserBranchMapWiseDetails = new List<UserBranchMapGrid>();
            DataSet dsGSTCreation = new DataSet();
            DataTable dtGSTCreation = new DataTable();
            DataTable dtGSTCreationDet = new DataTable();
            dsGSTCreation.Tables.Add(dtGSTCreation);
            dsGSTCreation.Tables.Add(dtGSTCreationDet);
            dsGSTCreation.Load(dataReader, LoadOption.OverwriteChanges, dtGSTCreation, dtGSTCreationDet);
            objUserBranchMapDetail.UserBranchMap = dsGSTCreation.Tables[0].ToCustomList<UserBranchMap>().FirstOrDefault();
            objUserBranchMapDetail.UserBranchMapWiseDetails = dsGSTCreation.Tables[1].ToCollection<UserBranchMapGrid>();
            return objUserBranchMapDetail;
        }

        const string _get_Employee_ = "USP_UserCatMap_GetEmployee";
        public List<UserBranchMap> GetEmployeeName(string Typedtxt)
        {
            List<UserBranchMap> objEmployee = new List<UserBranchMap>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TypeText", Typedtxt));
            DataSet dataSet = MasterExecuteCommand(_get_Employee_, parameters);
            objEmployee = dataSet.Tables[0].ToCollection<UserBranchMap>();
            return objEmployee;
        }

        const string _get_UserBranchMap_Detail_ = "USP_get_UserBranchMap_Detail_";
        public List<UserBranchMapGrid> GetUserBranchMapDetail(int EmployeeSno)
        {
            List<UserBranchMapGrid> objUserBranchMapDetail = new List<UserBranchMapGrid>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmployeeSno", EmployeeSno));
            DataSet dataSet = MasterExecuteCommand(_get_UserBranchMap_Detail_, parameters);
            objUserBranchMapDetail = dataSet.Tables[0].ToCollection<UserBranchMapGrid>();
            return objUserBranchMapDetail;
        }
    }
}

