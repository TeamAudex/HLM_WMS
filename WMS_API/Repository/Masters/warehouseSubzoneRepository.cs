using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Librarys.Extenders;
using Librarys;
using Entity;
using POM.Repository;
using POMS.Entity;
using Entity.Masters;

namespace Repository.master
{
    public class warehouseSubzoneRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_WarehouseSubZone_Insert";
        const string _Search = "USP_WarehouseSubZone_Search";
        const string _Edit = "USP_WarehouseSubZone_Edit";
        const string _ItemFetch = "USP_ZoneItems_Fetch";
        const string _WarehouseSubZoneDropdown = "USP_WHSubZone_DropDown";
        public WarehouseSubZoneResult Insert(WarehouseSubZoneDetList objWarehouseSubZone)
        {
            WarehouseSubZoneResult ObjResult = new WarehouseSubZoneResult();
            List<SqlParameter> objParams = new List<SqlParameter>();

            SqlParameter parawarehouseSubZoneSno = new SqlParameter("@warehouseSubZoneSno", objWarehouseSubZone.objWarehouseSubZone.warehouseSubZoneSno);
            parawarehouseSubZoneSno.SqlDbType = SqlDbType.Int;
            objParams.Add(parawarehouseSubZoneSno);

            SqlParameter objWarehouseSno = new SqlParameter("@WarehouseSno", objWarehouseSubZone.objWarehouseSubZone.WarehouseSno);
            objWarehouseSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objWarehouseSno);


            SqlParameter objZoneNameSno = new SqlParameter("@ZoneNameSno", objWarehouseSubZone.objWarehouseSubZone.ZoneNameSno);
            objZoneNameSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objZoneNameSno);

            SqlParameter objSubZoneName = new SqlParameter("@SubZoneName", objWarehouseSubZone.objWarehouseSubZone.SubZoneName);
            objSubZoneName.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objSubZoneName);

            SqlParameter objUOMSno = new SqlParameter("@UOMSno", objWarehouseSubZone.objWarehouseSubZone.UOMSno);
            objUOMSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objUOMSno);


            SqlParameter objLength = new SqlParameter("@Length", objWarehouseSubZone.objWarehouseSubZone.Length);
            objLength.SqlDbType = SqlDbType.Decimal;
            objLength.Direction = ParameterDirection.Input;
            objParams.Add(objLength);

            SqlParameter objBreadth = new SqlParameter("@Breadth", objWarehouseSubZone.objWarehouseSubZone.Breadth);
            objBreadth.SqlDbType = SqlDbType.Decimal;
            objBreadth.Direction = ParameterDirection.Input;
            objParams.Add(objBreadth);

            SqlParameter objHeight = new SqlParameter("@Height", objWarehouseSubZone.objWarehouseSubZone.Height);
            objHeight.SqlDbType = SqlDbType.Decimal;
            objHeight.Direction = ParameterDirection.Input;
            objParams.Add(objHeight);

            SqlParameter objWeight = new SqlParameter("@Weight", objWarehouseSubZone.objWarehouseSubZone.Weight);
            objWeight.SqlDbType = SqlDbType.Decimal;
            objWeight.Direction = ParameterDirection.Input;
            objParams.Add(objWeight);

            SqlParameter objVolume = new SqlParameter("@Volume", objWarehouseSubZone.objWarehouseSubZone.Volume);
            objVolume.SqlDbType = SqlDbType.Decimal;
            objVolume.Direction = ParameterDirection.Input;
            objParams.Add(objVolume);

            SqlParameter objTemperatureSno = new SqlParameter("@TemperatureSno", objWarehouseSubZone.objWarehouseSubZone.TemperatureSno);
            objTemperatureSno.SqlDbType = SqlDbType.Int;
            objTemperatureSno.Direction = ParameterDirection.Input;
            objParams.Add(objTemperatureSno);

            SqlParameter objZoneDetails = new SqlParameter("@ZoneDetails", objWarehouseSubZone.objWarehouseSubZone.ZoneDetails);
            objZoneDetails.SqlDbType = SqlDbType.VarChar;
            objZoneDetails.Direction = ParameterDirection.Input;
            objParams.Add(objZoneDetails);

            SqlParameter objRackBased = new SqlParameter("@RackBased", objWarehouseSubZone.objWarehouseSubZone.RackBased);
            objRackBased.SqlDbType = SqlDbType.Bit;
            objParams.Add(objRackBased);

            SqlParameter objStorageTypeSno = new SqlParameter("@StorageTypeSno", objWarehouseSubZone.objWarehouseSubZone.StorageTypeSno);
            objStorageTypeSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objStorageTypeSno);

            SqlParameter objStorageTypeNewSno = new SqlParameter("@StorageTypeNewSno", objWarehouseSubZone.objWarehouseSubZone.StorageTypeNewSno);
            objStorageTypeNewSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objStorageTypeNewSno);

            SqlParameter objStorageMappedDevice = new SqlParameter("@StorageDeviceMapped", objWarehouseSubZone.objWarehouseSubZone.StorageMappedDevice);
            objStorageMappedDevice.SqlDbType = SqlDbType.Bit;
            objParams.Add(objStorageMappedDevice);


            SqlParameter objStorageMappedDeviceRadio = new SqlParameter("@PalletMovementType", objWarehouseSubZone.objWarehouseSubZone.StorageMappedDeviceRadio);
            objStorageMappedDeviceRadio.SqlDbType = SqlDbType.VarChar;
            objStorageMappedDeviceRadio.Direction = ParameterDirection.Input;
            objParams.Add(objStorageMappedDeviceRadio);

            SqlParameter objStorageMethodtype = new SqlParameter("@StorageMethodtype", objWarehouseSubZone.objWarehouseSubZone.StorageMethodtype);
            objStorageMethodtype.SqlDbType = SqlDbType.VarChar;
            objStorageMethodtype.Direction = ParameterDirection.Input;
            objParams.Add(objStorageMethodtype);

            SqlParameter objPalletTypeSno = new SqlParameter("@PalletTypeSno", objWarehouseSubZone.objWarehouseSubZone.PalletTypeSno);
            objPalletTypeSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objPalletTypeSno);

            SqlParameter objVirtualLocation = new SqlParameter("@VirtualLocation", objWarehouseSubZone.objWarehouseSubZone.VirtualLocation);
            objVirtualLocation.SqlDbType = SqlDbType.Bit;
            objParams.Add(objVirtualLocation);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", objWarehouseSubZone.objWarehouseSubZone.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(objCreOpr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objWarehouseSubZone.objWarehouseSubZone.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objWarehouseSubZone.objWarehouseSubZone.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ActionName);

            SqlParameter ReqLog = new SqlParameter("@ReqLog", objWarehouseSubZone.objWarehouseSubZone.ReqLog);
            ReqLog.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ReqLog);

            SqlParameter objsts = new SqlParameter("@Sts", objWarehouseSubZone.objWarehouseSubZone.sts);
            objsts.SqlDbType = SqlDbType.Bit;
            objParams.Add(objsts);
            DataTable ArrWarehouseSubZoneRow = new DataTable();

            ArrWarehouseSubZoneRow.Columns.Add("WarehouseSubZonedetSno");
            ArrWarehouseSubZoneRow.Columns.Add("VendorSno");
            ArrWarehouseSubZoneRow.Columns.Add("Sts");
            foreach (SubZoneVendorDet objDet in objWarehouseSubZone.ObjWarehouseSubZoneDet)
            {
                ArrWarehouseSubZoneRow.Rows.Add(objDet.WarehouseSubZonedetSno, objDet.VendorSno, objDet.sts);
            }

            SqlParameter WhSubZoneRow = new SqlParameter();
            WhSubZoneRow.ParameterName = "@WarehouseSubZonedet";
            WhSubZoneRow.SqlDbType = SqlDbType.Structured;
            WhSubZoneRow.Value = ArrWarehouseSubZoneRow;
            WhSubZoneRow.Direction = ParameterDirection.Input;
            objParams.Add(WhSubZoneRow);

            DataTable ArrWarehouseSubZoneRow1 = new DataTable();

            ArrWarehouseSubZoneRow1.Columns.Add("WarehouseSubZonedet1Sno");
            ArrWarehouseSubZoneRow1.Columns.Add("ItemNameSno");
            ArrWarehouseSubZoneRow1.Columns.Add("UOM1Sno");
            ArrWarehouseSubZoneRow1.Columns.Add("ItemtypeSno");
            ArrWarehouseSubZoneRow1.Columns.Add("Sts");

            foreach (SubZoneItemDet objDet in objWarehouseSubZone.ObjWarehouseSubZoneDetone)
            {
                ArrWarehouseSubZoneRow1.Rows.Add(objDet.WarehouseSubZonedet1Sno, objDet.ItemNameSno, objDet.UOMSno, objDet.ItemtypeSno, objDet.sts);

            }

            SqlParameter WhSubZonerow1 = new SqlParameter();
            WhSubZonerow1.ParameterName = "@WarehouseSubZonedet1";
            WhSubZonerow1.SqlDbType = SqlDbType.Structured;
            WhSubZonerow1.Value = ArrWarehouseSubZoneRow1;
            WhSubZonerow1.Direction = ParameterDirection.Input;
            objParams.Add(WhSubZonerow1);

            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objParams);
                ObjResult = ds.Tables[0].ToCustomList<WarehouseSubZoneResult>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return ObjResult;

        }


        public Tuple<List<WarehouseSubZone>, int> Search(PageRequest pageRequest)
        {
            List<WarehouseSubZone> SearchList = new List<WarehouseSubZone>();
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
                SearchList = dataSet.Tables[0].ToCollection<WarehouseSubZone>();
            }
            return new Tuple<List<WarehouseSubZone>, int>(SearchList, recordCount);
        }
        public WarehouseSubZoneDetList Edit(int warehouseSubZoneSno)
        {
            SqlParameter paramActionID = new SqlParameter("@warehouseSubZoneSno", warehouseSubZoneSno);
            SqlCommand sqlCmd = new SqlCommand(_Edit);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            WarehouseSubZoneDetList objWarehouseSubZoneMaster = new WarehouseSubZoneDetList();

            objWarehouseSubZoneMaster.objWarehouseSubZone = new WarehouseSubZone();
            objWarehouseSubZoneMaster.ObjWarehouseSubZoneDet = new List<SubZoneVendorDet>();
            objWarehouseSubZoneMaster.ObjWarehouseSubZoneDetone = new List<SubZoneItemDet>();

            DataSet ds = new DataSet();
            DataTable ArrWarehouseSubZoneRow = new DataTable();
            DataTable WhSubZoneRow = new DataTable();
            DataTable ArrWarehouseSubZoneRow1 = new DataTable();

            ds.Tables.Add(ArrWarehouseSubZoneRow);
            ds.Tables.Add(WhSubZoneRow);
            ds.Tables.Add(ArrWarehouseSubZoneRow1);

            try
            {
                ds.Load(dataReader, LoadOption.OverwriteChanges, ArrWarehouseSubZoneRow, WhSubZoneRow, ArrWarehouseSubZoneRow1);
                objWarehouseSubZoneMaster.objWarehouseSubZone = ds.Tables[0].ToCustomList<WarehouseSubZone>().FirstOrDefault();
                objWarehouseSubZoneMaster.ObjWarehouseSubZoneDet = ds.Tables[1].ToCollection<SubZoneVendorDet>();
                objWarehouseSubZoneMaster.ObjWarehouseSubZoneDetone = ds.Tables[2].ToCollection<SubZoneItemDet>();
            }
            catch (Exception ex)
            {

            }
            return objWarehouseSubZoneMaster;
        }

        public warehouseSubZoneDropdownList warehouseSubZoneDropdown(int WarehouseSno)
        {
            warehouseSubZoneDropdownList objdrop = new warehouseSubZoneDropdownList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paraWarehouseSno = new SqlParameter("@WarehouseSno", WarehouseSno);
            paraWarehouseSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paraWarehouseSno);

            DataSet ds = MasterExecuteCommand(_WarehouseSubZoneDropdown, sqlparams);
            DataTable dt = new DataTable();
            objdrop.objUOMDropdown = ds.Tables[0].ToCollection<SZUOMDropdown>();
            objdrop.objStorageTypeDropdown = ds.Tables[1].ToCollection<StorageTypeDropdown1>();
            objdrop.ObjPalletTypeDropdown = ds.Tables[2].ToCollection<SZPalletTypeDropdown>();
            objdrop.objtempratureDropdown = ds.Tables[3].ToCollection<tempratureDropdown>();
            objdrop.objStorageTypeNewDropdown = ds.Tables[4].ToCollection<StorageTypeNewDropdown>();

            return objdrop;
        }


        public List<SubZoneItemDet> GetItems(int ZoneSno)
        {
            List<SubZoneItemDet> ArrItems = new List<SubZoneItemDet>();

            List<SqlParameter> objParams = new List<SqlParameter>();

            SqlParameter ParamZoneSno = new SqlParameter("@ZoneSno", ZoneSno);
            ParamZoneSno.SqlDbType = SqlDbType.Int;
            objParams.Add(ParamZoneSno);

            try
            {
                DataSet ds = ExecuteCommand(_ItemFetch, objParams);
                ArrItems = ds.Tables[0].ToCollection<SubZoneItemDet>();
            }
            catch (Exception ex)
            {

            }

            return ArrItems;
        }
    }
}

