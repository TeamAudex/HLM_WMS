using Entity;
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
    public class WHLayoutDetailsRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_WHLayoutDetails_Insert";
        public WHLayoutDetailsResult Insert(WHLayoutDetailsList objWHLayoutDetailsList)
        {
            WHLayoutDetailsResult ObjResult = new WHLayoutDetailsResult();

            List<SqlParameter> objParams = new List<SqlParameter>();

            SqlParameter paraWarehouseLayoutSno = new SqlParameter("@WHLayoutDetailsSno", objWHLayoutDetailsList.ObjWHLayoutDetails.WHLayoutDetailsSno);
            paraWarehouseLayoutSno.SqlDbType = SqlDbType.Int;
            objParams.Add(paraWarehouseLayoutSno);

            SqlParameter objWarehouseSno = new SqlParameter("@WarehouseSno", objWHLayoutDetailsList.ObjWHLayoutDetails.WarehouseSno);
            objWarehouseSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objWarehouseSno);

            SqlParameter objRowsSno = new SqlParameter("@RowsSno", objWHLayoutDetailsList.ObjWHLayoutDetails.RowsSno);
            objRowsSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objRowsSno);

            SqlParameter objUOMSno = new SqlParameter("@UOMSno", objWHLayoutDetailsList.ObjWHLayoutDetails.UOMSno);
            objUOMSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objUOMSno);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", objWHLayoutDetailsList.ObjWHLayoutDetails.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(objCreOpr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objWHLayoutDetailsList.ObjWHLayoutDetails.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objWHLayoutDetailsList.ObjWHLayoutDetails.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ActionName);

            SqlParameter ReqLog = new SqlParameter("@ReqLog", objWHLayoutDetailsList.ObjWHLayoutDetails.ReqLog);
            ReqLog.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ReqLog);

            SqlParameter objsts = new SqlParameter("@Sts", objWHLayoutDetailsList.ObjWHLayoutDetails.Sts);
            objsts.SqlDbType = SqlDbType.Bit;
            objParams.Add(objsts);

            DataTable ArrWarehouseLayoutDetailsLevelDet = new DataTable();

            ArrWarehouseLayoutDetailsLevelDet.Columns.Add("WHLoyoutDetailsLevelDetSno");
            ArrWarehouseLayoutDetailsLevelDet.Columns.Add("LevelNameReadonly");
            ArrWarehouseLayoutDetailsLevelDet.Columns.Add("LevelName");
            ArrWarehouseLayoutDetailsLevelDet.Columns.Add("Sts");

            foreach (WarehouseLayoutDetailsLevelDet objDet in objWHLayoutDetailsList.ObjWarehouseLayoutDetailsLevelDet)
            {
                ArrWarehouseLayoutDetailsLevelDet.Rows.Add(objDet.WHLoyoutDetailsLevelDetSno, objDet.LevelNameReadonly, objDet.LevelName, objDet.Sts);
            }

            SqlParameter WhLayoutRow = new SqlParameter();
            WhLayoutRow.ParameterName = "@WarehouseLayoutDetailsLevelDet";
            WhLayoutRow.SqlDbType = SqlDbType.Structured;
            WhLayoutRow.Value = ArrWarehouseLayoutDetailsLevelDet;
            WhLayoutRow.Direction = ParameterDirection.Input;
            objParams.Add(WhLayoutRow);

            DataTable ArrWarehouseLayoutDetailsRackDet = new DataTable();

            ArrWarehouseLayoutDetailsRackDet.Columns.Add("WHLoyoutDetailsRackDetSno");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("LevelName");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("Rack");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("NonStorageArea");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("Length");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("Breadth");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("Height");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("TotalVolume");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("MaxWeight");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("ZoneSno");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("SubZoneSno");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("StockTypeSno");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("StorageTypeSno");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("StorageMappedDevice");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("StorageMappedDeviceRadio");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("PalletTypeSno");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("StorageMethod");
            ArrWarehouseLayoutDetailsRackDet.Columns.Add("Sts");

            foreach (WarehouseLayoutDetailsRackDet objDet in objWHLayoutDetailsList.ObjWarehouseLayoutDetailsRackDet)
            {
                ArrWarehouseLayoutDetailsRackDet.Rows.Add(objDet.WHLoyoutDetailsRackDetSno, objDet.LevelName, objDet.Rack, objDet.NonStorageArea, objDet.Length, objDet.Breadth, objDet.Height, objDet.TotalVolume, objDet.MaxWeight, objDet.ZoneSno, objDet.SubZoneSno, objDet.StockTypeSno, objDet.StorageTypeSno, objDet.StorageMappedDevice, objDet.StorageMappedDeviceRadio, objDet.PalletTypeSno, objDet.StorageMethod, objDet.Sts);
            }

            SqlParameter WhLayoutcol = new SqlParameter();
            WhLayoutcol.ParameterName = "@WarehouseLayoutDetailsRackDet";
            WhLayoutcol.SqlDbType = SqlDbType.Structured;
            WhLayoutcol.Value = ArrWarehouseLayoutDetailsRackDet;
            WhLayoutcol.Direction = ParameterDirection.Input;
            objParams.Add(WhLayoutcol);

            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objParams);
                ObjResult = ds.Tables[0].ToCustomList<WHLayoutDetailsResult>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return ObjResult;

        }

        const string _Search = "USP_WHLayoutDetails_Search";
        public Tuple<List<WHLayoutDetails>, int> Search(PageRequest pageRequest)
        {
            List<WHLayoutDetails> SearchList = new List<WHLayoutDetails>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                parameters.Add(new SqlParameter("@UserSno", pageRequest.UserSno));
                parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                SearchList = dataSet.Tables[0].ToCollection<WHLayoutDetails>();
            }
            return new Tuple<List<WHLayoutDetails>, int>(SearchList, recordCount);

        }

        const string _Edit = "USP_WHLayoutDetails_Edit";
        public WHLayoutDetailsList Edit(int WHLayoutDetailsSno)
        {
            SqlParameter paramActionID = new SqlParameter("@WHLayoutDetailsSno", WHLayoutDetailsSno);
            SqlCommand sqlCmd = new SqlCommand(_Edit);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            WHLayoutDetailsList ObjWHLayoutDetailsList = new WHLayoutDetailsList();
            ObjWHLayoutDetailsList.ObjWHLayoutDetails = new WHLayoutDetails();
            ObjWHLayoutDetailsList.ObjWarehouseLayoutDetailsLevelDet = new List<WarehouseLayoutDetailsLevelDet>();
            ObjWHLayoutDetailsList.ObjWarehouseLayoutDetailsRackDet = new List<WarehouseLayoutDetailsRackDet>();

            DataSet ds = new DataSet();
            DataTable ArrWHLayoutDetails = new DataTable();
            DataTable ArrWarehouseLayoutDetailsLevelDet = new DataTable();
            DataTable ArrWarehouseLayoutDetailsRackDet = new DataTable();

            ds.Tables.Add(ArrWHLayoutDetails);
            ds.Tables.Add(ArrWarehouseLayoutDetailsLevelDet);
            ds.Tables.Add(ArrWarehouseLayoutDetailsRackDet);

            try
            {
                ds.Load(dataReader, LoadOption.OverwriteChanges, ArrWHLayoutDetails, ArrWarehouseLayoutDetailsLevelDet, ArrWarehouseLayoutDetailsRackDet);
                ObjWHLayoutDetailsList.ObjWHLayoutDetails = ds.Tables[0].ToCustomList<WHLayoutDetails>().FirstOrDefault();
                ObjWHLayoutDetailsList.ObjWarehouseLayoutDetailsLevelDet = ds.Tables[1].ToCollection<WarehouseLayoutDetailsLevelDet>();
                ObjWHLayoutDetailsList.ObjWarehouseLayoutDetailsLevelDet = ds.Tables[2].ToCollection<WarehouseLayoutDetailsLevelDet>();
            }
            catch (Exception ex)
            {
            }
            return ObjWHLayoutDetailsList;
        }

        const string _Dropdown = "USP_WHLayoutDetails_DropDown";
        public WHLayoutDetailDropdownlist WHLDDropDown(int WarehouseSno)
        {
            WHLayoutDetailDropdownlist objdrop = new WHLayoutDetailDropdownlist();

            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter ParamWarehouseSno = new SqlParameter("@WarehouseSno", WarehouseSno);
            ParamWarehouseSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(ParamWarehouseSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Dropdown, sqlparams);
                DataTable dtBranch = new DataTable();
                objdrop.ObjRow = ds.Tables[0].ToCollection<RowDropdown>();
                objdrop.ObjUOM = ds.Tables[1].ToCollection<WHDUOMDropdown>();
                objdrop.ObjZone = ds.Tables[2].ToCollection<ZoneDropdown>();
                objdrop.ObjSubzone = ds.Tables[3].ToCollection<SubzoneDropdown>();
                objdrop.ObjStockType = ds.Tables[4].ToCollection<StockTypeDropdown>();
                objdrop.ObjStorageType = ds.Tables[5].ToCollection<StorageTypeDropdown>();
                objdrop.ObjPalletType = ds.Tables[6].ToCollection<WLDPalletTypeDropdown>();
            }
            catch(Exception ex)
            {

            }
          
            return objdrop;
        }

        const string _Fetch = "USP_WHLayoutDetails_Fetch";
        public WHLayoutDetailsList Fetch(int WarehouseSno, int RowsSno)
        {
            WHLayoutDetailsList objWHLayoutDetailsList = new WHLayoutDetailsList();

            List<SqlParameter> objSqlparameters = new List<SqlParameter>();

            SqlParameter paraWarehouseSno = new SqlParameter("@WarehouseSno", WarehouseSno);
            paraWarehouseSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(paraWarehouseSno);

            SqlParameter paraRowsSno = new SqlParameter("@RowsSno", RowsSno);
            paraRowsSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(paraRowsSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Fetch, objSqlparameters);
                objWHLayoutDetailsList.ObjWarehouseLayoutDetailsLevelDet = ds.Tables[0].ToCollection<WarehouseLayoutDetailsLevelDet>();
                objWHLayoutDetailsList.ObjWarehouseLayoutDetailsRackDet = ds.Tables[1].ToCollection<WarehouseLayoutDetailsRackDet>();
                objWHLayoutDetailsList.ObjWHLayoutDetails = ds.Tables[2].ToCollection<WHLayoutDetails>().FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return objWHLayoutDetailsList;
        }

        const string _PalletTypeFetch = "USP_WHLayoutDetails_PalletType_Fetch";
        public WHLayoutDetailsList PalletTypeFetch(int PalletTypeSno)
        {
            WHLayoutDetailsList objWHLayoutDetailsList = new WHLayoutDetailsList();

            List<SqlParameter> objSqlparameters = new List<SqlParameter>();

            SqlParameter paraPalletTypeSno = new SqlParameter("@PalletTypeSno", PalletTypeSno);
            paraPalletTypeSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(paraPalletTypeSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_PalletTypeFetch, objSqlparameters);
                objWHLayoutDetailsList.ObjWarehouseLayoutDetailsRackDet = ds.Tables[0].ToCollection<WarehouseLayoutDetailsRackDet>();
            }
            catch (Exception ex)
            {
            }
            return objWHLayoutDetailsList;
        }
    }
}
