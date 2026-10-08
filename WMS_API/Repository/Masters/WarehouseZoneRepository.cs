


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

namespace POMS.Repository
{
    public class WarehouseZoneRepository : RepositoryBaseNew
    {


        const string _droptype = "USP_Storagelocation_Dropdown";
        public Storagelocationlist StoragelocationDD()
        {
            Storagelocationlist objdrop = new Storagelocationlist();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_droptype, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.StoragelocationDropdown = ds.Tables[0].ToCollection<StoragelocationDD>();
            return objdrop;
        }

        public Dropdownlist StockTypedropdown()
        {
            Dropdownlist objdrop = new Dropdownlist();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_droptype, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objStockTypeDD = ds.Tables[0].ToCollection<StockTypedropdown>();
            return objdrop;
        }

        const string _Insert = "USP_WarehouseZone_Insert";
        public WarehouseZoneResult Insert(WarehouseZoneMaster objclass)
        {

            WarehouseZoneResult ObjResult = new WarehouseZoneResult();

            List<SqlParameter> objParams = new List<SqlParameter>();

            SqlParameter objWarehouseZoneSno = new SqlParameter("@WarehouseZoneSno", objclass.objWarehouseZone.WarehouseZoneSno);
            objWarehouseZoneSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objWarehouseZoneSno);


            SqlParameter objWarehouseSno = new SqlParameter("@WarehouseSno", objclass.objWarehouseZone.WarehouseSno);
            objWarehouseSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objWarehouseSno);

            SqlParameter objFloorSno = new SqlParameter("@FloorSno", objclass.objWarehouseZone.FloorSno);
            objFloorSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objFloorSno);


            SqlParameter objZoneName = new SqlParameter("@ZoneName", objclass.objWarehouseZone.ZoneName);
            objZoneName.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objZoneName);

            SqlParameter objPickOrder = new SqlParameter("@PickOrder", objclass.objWarehouseZone.PickOrder);
            objPickOrder.SqlDbType = SqlDbType.Int;
            objParams.Add(objPickOrder);

            SqlParameter objZoneDetails = new SqlParameter("@ZoneDetails", objclass.objWarehouseZone.ZoneDetails);
            objZoneDetails.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objZoneDetails);

            SqlParameter objStorageTypeSno = new SqlParameter("@StorageTypeSno", objclass.objWarehouseZone.StorageTypeSno);
            objStorageTypeSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objStorageTypeSno);

            SqlParameter objSqlParamIPNumber = new SqlParameter("@IPNumber", objclass.objWarehouseZone.IpNumber);
            objSqlParamIPNumber.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objSqlParamIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objclass.objWarehouseZone.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(ActionName);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", objclass.objWarehouseZone.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(objCreOpr);

            SqlParameter objSqlParamSts = new SqlParameter("@Sts", objclass.objWarehouseZone.Sts);
            objSqlParamSts.SqlDbType = SqlDbType.Bit;
            objParams.Add(objSqlParamSts);

            DataTable ArrWarehouseZoneDet = new DataTable();

            ArrWarehouseZoneDet.Columns.Add("WarehouseZoneDetSno");
            ArrWarehouseZoneDet.Columns.Add("WarehouseZoneSno");
            ArrWarehouseZoneDet.Columns.Add("ItemNameSno");
            ArrWarehouseZoneDet.Columns.Add("UOMSno");
            ArrWarehouseZoneDet.Columns.Add("ItemTypeSno");
            ArrWarehouseZoneDet.Columns.Add("Sts");

            foreach (WarehouseZoneDet objDet in objclass.objWarehouseZoneDet)
            {
                ArrWarehouseZoneDet.Rows.Add(objDet.WarehouseZoneDetSno, objDet.WarehouseZoneSno, objDet.ItemNameSno, objDet.UOMSno , objDet.ItemTypeSno, objDet.Sts);
            }

            SqlParameter WarehouseZoneDet = new SqlParameter();
            WarehouseZoneDet.ParameterName = "@WarehouseZoneDet";
            WarehouseZoneDet.SqlDbType = SqlDbType.Structured;
            WarehouseZoneDet.Value = ArrWarehouseZoneDet;
            WarehouseZoneDet.Direction = ParameterDirection.Input;
            objParams.Add(WarehouseZoneDet);

            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objParams);
                ObjResult = ds.Tables[0].ToCustomList<WarehouseZoneResult>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return ObjResult;
        }

        const string _Search = "USP_WarehouseZone_Search";

        public Tuple<List<WarehouseZone>, int> Search(PageRequest pageRequest)
        {
            List<WarehouseZone> SearchList = new List<WarehouseZone>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();


                    parameters.Add(new SqlParameter("@TrnType", pageRequest.TrnType));
                    parameters.Add(new SqlParameter("@UserSno", pageRequest.UserSno));
                    parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                    parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                    parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                    parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                    parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                    parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);

                    SearchList = dataSet.Tables[0].ToCollection<WarehouseZone>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<WarehouseZone>, int>(SearchList, recordCount);
        }
        const string _Edit = "USP_WarehouseZone_Edit";


        public WarehouseZoneMaster Edit(int WarehouseZoneSno)
        {
            SqlParameter paramActionID = new SqlParameter("@WarehouseZoneSno", WarehouseZoneSno);
            SqlCommand sqlCmd = new SqlCommand(_Edit);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            WarehouseZoneMaster objWarehouseZoneMaster = new WarehouseZoneMaster();

            objWarehouseZoneMaster.objWarehouseZone = new WarehouseZone();
            objWarehouseZoneMaster.objWarehouseZoneDet = new List<WarehouseZoneDet>();

            DataSet dsWarehouseZoneMasterList = new DataSet();
            DataTable dtWarehouseZoneMaster = new DataTable();
            DataTable dtWarehouseZoneDet = new DataTable();

            dsWarehouseZoneMasterList.Tables.Add(dtWarehouseZoneMaster);
            dsWarehouseZoneMasterList.Tables.Add(dtWarehouseZoneDet);

            try
            {
                dsWarehouseZoneMasterList.Load(dataReader, LoadOption.OverwriteChanges, dtWarehouseZoneMaster, dtWarehouseZoneDet);
                objWarehouseZoneMaster.objWarehouseZone = dsWarehouseZoneMasterList.Tables[0].ToCustomList<WarehouseZone>().FirstOrDefault();
                objWarehouseZoneMaster.objWarehouseZoneDet = dsWarehouseZoneMasterList.Tables[1].ToCollection<WarehouseZoneDet>();

            }
            catch (Exception ex)
            {
                objWarehouseZoneMaster.Result = ex.Message.ToString();
            }

            return objWarehouseZoneMaster;
        }
    }
}
