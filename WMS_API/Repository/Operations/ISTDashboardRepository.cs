using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using POMS.Entity;
using POMS.Entity.Masters;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using System.Data;
using Entity.Operations;
using System.IO;
using System.Net;
using System.Net.Security;
using POMS.Repository;
using Newtonsoft.Json;

namespace Repository.Operations
{
  public class ISTDashboardRepository: RepositoryBaseNew
    {
        const string _LoadDash = "USP_IST_DASHBOARD";
        public List<IST> LoadDash(int UserSno, string RoleFlag)
        {
            List<IST> objISTDashboard = new List<IST>();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@UserSno", UserSno));
            Sqlparams.Add(new SqlParameter("@RoleFlag", RoleFlag));
            DataSet ds = MasterExecuteCommand(_LoadDash, Sqlparams);
            objISTDashboard = ds.Tables[0].ToCustomList<IST>();
            return objISTDashboard;
        }

        const string _ISTDetDash = "USP_IST_LOC_DET_DASHBOARD";
        public List<ISTDet> ISTDetDash(int UserSno, int ISTSno)
        {
            List<ISTDet> objISTDashboard = new List<ISTDet>();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@UserSno", UserSno));
            Sqlparams.Add(new SqlParameter("@ISTSno", ISTSno));
            DataSet ds = MasterExecuteCommand(_ISTDetDash, Sqlparams);
            objISTDashboard = ds.Tables[0].ToCustomList<ISTDet>();
            return objISTDashboard;
        }

        const string _PACFetch = "USP_IST_PACONF_FETCH";
        public PAFetch PACFetch(int PutAwayLocSno,int ISTDetSno)
        {
            PAFetch ObjPA = new PAFetch();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramPALocSno = new SqlParameter("@PutAwayLocSno", PutAwayLocSno);
            paramPALocSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPALocSno);


            SqlParameter paramISTDetSno = new SqlParameter("@ISTDetSno", ISTDetSno);
            paramISTDetSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramISTDetSno);
            try
            {
                DataSet ds = ExecuteCommand(_PACFetch, parameters);
                ObjPA.objPAConfirm = ds.Tables[0].ToCollection<PAConfirm>().FirstOrDefault();
                ObjPA.ArrPutAway = ds.Tables[0].ToCollection<PAConfirmDet>();
            }
            catch (Exception ex)
            {

            }

            return ObjPA;
        }
    }
}
