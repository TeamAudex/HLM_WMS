using Entity.Masters;
using Librarys;
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

namespace Repository.Masters
{
    public class UserStateMapRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_UserStateMap_Insert";
        public string Insert(UserStateMapList UserStateMaplist)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter paraUserStateMapSno = new SqlParameter("@UserStateMapSno", UserStateMaplist.UserStateMap.UserStateMapSno);
            paraUserStateMapSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paraUserStateMapSno);

            SqlParameter paraUserSno = new SqlParameter("@UserSno", UserStateMaplist.UserStateMap.UserSno);
            paraUserSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paraUserSno);

            SqlParameter ParamsCreopr = new SqlParameter("@CreOpr", UserStateMaplist.UserStateMap.CreOpr);
            ParamsCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(ParamsCreopr);

            SqlParameter ParamsIpNumber = new SqlParameter("@IPNumber", UserStateMaplist.UserStateMap.IPNumber);
            ParamsIpNumber.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(ParamsIpNumber);

            SqlParameter ParamsActionName = new SqlParameter("@ActionName", UserStateMaplist.UserStateMap.ActionName);
            ParamsActionName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(ParamsActionName);

            SqlParameter ParaSts = new SqlParameter("@Sts", UserStateMaplist.UserStateMap.Sts);
            ParaSts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(ParaSts);

            DataTable ArrUserStateMapDet = new DataTable();
            ArrUserStateMapDet.Columns.Add("UserStateMapDetSno");
            ArrUserStateMapDet.Columns.Add("UserStateMapSno");
            ArrUserStateMapDet.Columns.Add("StateSno");
            ArrUserStateMapDet.Columns.Add("Sts");

            foreach (UserStateMapDet objDet in UserStateMaplist.UserStateMapDet)
            {
                ArrUserStateMapDet.Rows.Add(objDet.UserStateMapDetSno, objDet.UserStateMapSno, objDet.StateSno, objDet.Sts);
            }

            SqlParameter paraUserStateMapDet = new SqlParameter();
            paraUserStateMapDet.ParameterName = "@UserStateMapDet";
            paraUserStateMapDet.SqlDbType = SqlDbType.Structured;
            paraUserStateMapDet.Value = ArrUserStateMapDet;
            paraUserStateMapDet.Direction = ParameterDirection.Input;
            sqlParameters.Add(paraUserStateMapDet);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);
            string Result = ds.Tables[0].Rows[0][0].ToString();
            return Result;
        }

        const string _Search = "USP_UserStateMap_Search";
        public Tuple<List<UserStateMap>, int> Search(PageRequest pageRequest)
        {
            List<UserStateMap> objUserStateMap = new List<UserStateMap>();
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

                    DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);
                    objUserStateMap = dataSet.Tables[0].ToCollection<UserStateMap>();
                }
                catch (Exception ee) { }
            }
            return new Tuple<List<UserStateMap>, int>(objUserStateMap, recordCount);
        }

        const string _Edit = "USP_UserStateMap_Edit";
        public UserStateMapList Edit(int UserStateMapSno)
        {
            UserStateMapList objUserStateMapList = new UserStateMapList();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserStateMapSno", UserStateMapSno));

            DataSet dataSet = MasterExecuteCommand(_Edit, parameters);
            objUserStateMapList.UserStateMap = dataSet.Tables[0].ToCollection<UserStateMap>().FirstOrDefault();
            objUserStateMapList.UserStateMapDet = dataSet.Tables[1].ToCollection<UserStateMapDet>();
            return objUserStateMapList;
        }

        const string _GetStateDetails = "USP_UserStateMap_GetStateDetails";
        public List<UserStateMapDet> GetStateDetails()
        {
            List<UserStateMapDet> objUserStateMapDet = new List<UserStateMapDet>();
                
            List<SqlParameter> listofSqlParameter = new List<SqlParameter>();   

            DataSet dataSet = MasterExecuteCommand(_GetStateDetails, listofSqlParameter);
            objUserStateMapDet = dataSet.Tables[0].ToCollection<UserStateMapDet>();
            return objUserStateMapDet;
        }
    }
}
