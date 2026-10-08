using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Librarys.Extenders;
using Librarys;
using System.Data.SqlClient;
using Entity.Masters;
using POM.Repository;

namespace Repository.Master
{
    public class RoleRightsRepository : RepositoryBaseNew
    {
        const string _Fetch = "USP_Get_RoleRights";
        const string _Insert = "USP_RoleRights_Insert";
        const string _GetRights = "USP_ScreenRights_Get";
        public List<RolerightsDet> Fetch(int RoleSno)
        {
            List<RolerightsDet> objResult = new List<RolerightsDet>();

            List<SqlParameter> objparams = new List<SqlParameter>();

            SqlParameter ParamRoleSno = new SqlParameter("@RoleSno", RoleSno);
            ParamRoleSno.SqlDbType = SqlDbType.Int;
            objparams.Add(ParamRoleSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Fetch, objparams);
                objResult = ds.Tables[0].ToCollection<RolerightsDet>();
            }
            catch (Exception ex)
            {

            }
            return objResult;
        }
        public RoleRightResult insert(RoleRightSave ObjSave)
        {
            RoleRightResult objResult = new RoleRightResult();
            List<SqlParameter> objsqlParameters = new List<SqlParameter>();

            SqlParameter paramRoleSno = new SqlParameter("@RoleSno", ObjSave.ObjRoleRights.RoleSno);
            paramRoleSno.SqlDbType = SqlDbType.Int;
            objsqlParameters.Add(paramRoleSno);

            SqlParameter paramTokenNo = new SqlParameter("@TokenNo", ObjSave.ObjRoleRights.TokenNo);
            paramTokenNo.SqlDbType = SqlDbType.NVarChar;
            objsqlParameters.Add(paramTokenNo);

            SqlParameter paramCreopr = new SqlParameter("@UserSno", ObjSave.ObjRoleRights.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            objsqlParameters.Add(paramCreopr);


            SqlParameter paramIpNumber = new SqlParameter("@IpNumber", ObjSave.ObjRoleRights.IPNumber);
            paramIpNumber.SqlDbType = SqlDbType.NVarChar;
            objsqlParameters.Add(paramIpNumber);

            SqlParameter paramReqLog = new SqlParameter("@ReqLog", ObjSave.ObjRoleRights.ReqLog);
            paramReqLog.SqlDbType = SqlDbType.NVarChar;
            objsqlParameters.Add(paramReqLog);


            SqlParameter paramURL = new SqlParameter("@URL", ObjSave.ObjRoleRights.URL);
            paramURL.SqlDbType = SqlDbType.NVarChar;
            objsqlParameters.Add(paramURL);

            DataTable ArrRolerights = new DataTable();
            ArrRolerights.Columns.Add("RoleRightsSno");
            ArrRolerights.Columns.Add("MenuSno");
            ArrRolerights.Columns.Add("ViewFlag");
            ArrRolerights.Columns.Add("EditFlag");
            ArrRolerights.Columns.Add("AddFlag");
            ArrRolerights.Columns.Add("DeleteFlag");
            ArrRolerights.Columns.Add("Sts");

            foreach (RolerightsDet objDet in ObjSave.ArrRoleRights)
            {
                ArrRolerights.Rows.Add(objDet.RoleRightsSno, objDet.MenuSno, objDet.ViewFlag, objDet.EditFlag, objDet.AddFlag, objDet.DeleteFlag, objDet.Sts);
            }
            SqlParameter paramRolerights = new SqlParameter();
            paramRolerights.ParameterName = "@RoleRightsDetails";
            paramRolerights.SqlDbType = SqlDbType.Structured;
            paramRolerights.Value = ArrRolerights;
            paramRolerights.Direction = ParameterDirection.Input;
            objsqlParameters.Add(paramRolerights);
            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objsqlParameters);
                objResult = ds.Tables[0].ToCustomList<RoleRightResult>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                objResult.Result = ex.Message.ToString();
            }

            return objResult;
        }
        public ScreenRights GetRights(string UserSno, string URL)
        {
            ScreenRights objResult = new ScreenRights();

            List<SqlParameter> objparams = new List<SqlParameter>();

            SqlParameter ParamToken = new SqlParameter("@UserSno", UserSno);
            ParamToken.SqlDbType = SqlDbType.NVarChar;
            objparams.Add(ParamToken);

            SqlParameter ParamURL = new SqlParameter("@URL", URL);
            ParamURL.SqlDbType = SqlDbType.NVarChar;
            objparams.Add(ParamURL);

            try
            {
                DataSet ds = MasterExecuteCommand(_GetRights, objparams);
                objResult = ds.Tables[0].ToCollection<ScreenRights>().FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return objResult;
        }
    }

}

