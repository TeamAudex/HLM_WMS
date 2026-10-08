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
    public class DashBoardRepository : RepositoryBaseNew
    {
        const string sp_dashboard = "USP_LIVE_TRACKING_DASHBORD";
        public LiveTrackDet LoadLiveData (int UserSno)
        {
            LiveTrackDet ObjLiveData = new LiveTrackDet();
            ObjLiveData.objCount = new LiveTrack();
            ObjLiveData.objTask = new List<task>();
            ObjLiveData.objProcess = new List<process>();

            SqlParameter paramUserSno = new SqlParameter("@UserSno", UserSno);
            SqlParameter paramActionType= new SqlParameter("@ActionType", "Fetch");
            SqlCommand sqlCmd = new SqlCommand(sp_dashboard);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramUserSno);
            sqlCmd.Parameters.Add(paramActionType);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;


            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            ds.Tables.Add(dt);
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Load(dataReader, LoadOption.Upsert, dt, dt1, dt2);
            ObjLiveData.objCount  = ds.Tables[0].ToCustomList<LiveTrack>().FirstOrDefault();
            ObjLiveData.objTask  = ds.Tables[1].ToCollection<task>();
            ObjLiveData.objProcess = ds.Tables[2].ToCollection<process>();

            return ObjLiveData;
        }
        public LiveTrackDet FilterLiveData(request Objrequest)
        {
            LiveTrackDet ObjLiveData = new LiveTrackDet();
            ObjLiveData.objCount = new LiveTrack();
            ObjLiveData.objTask = new List<task>();
            ObjLiveData.objProcess = new List<process>();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter paramActionType = new SqlParameter("@ActionType", "Filter");
            paramActionType.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paramActionType);

            SqlParameter paramLSPSno = new SqlParameter("@LSPSno", Objrequest.objSearch.LSPSno);
            paramLSPSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramLSPSno);

            SqlParameter paramLRSno = new SqlParameter("@LRSno", Objrequest.objSearch.LRSno);
            paramLRSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramLRSno);

            SqlParameter paramTrackBy = new SqlParameter("@TrackBy", Objrequest.objSearch.TrackBy);
            paramTrackBy.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paramTrackBy);

            SqlParameter paramUserSno = new SqlParameter("@UserSno", Objrequest.objSearch.UserSno);
            paramUserSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramUserSno);

            SqlParameter paramFilterDate = new SqlParameter("@FilterDate", Objrequest.objSearch.FilterDate);
            paramFilterDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paramFilterDate);

            DataSet ds = ExecuteCommand(sp_dashboard, sqlParameters);
            ObjLiveData.objCount = ds.Tables[0].ToCustomList<LiveTrack>().FirstOrDefault();
            ObjLiveData.objTask = ds.Tables[1].ToCollection<task>();
            ObjLiveData.objProcess = ds.Tables[2].ToCollection<process>();

            return ObjLiveData;
        }
    }
}
