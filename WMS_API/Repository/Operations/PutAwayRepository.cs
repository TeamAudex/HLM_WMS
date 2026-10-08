
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity.Operations;
using POM.Repository;
using Librarys.Extenders;
using Librarys;
using EncryptDecryptAssembly;
using POMS.Entity;

namespace Repository.Operations
{
    public class PutAwayRepository : RepositoryBaseNew
    {
        const string _Fetch = "USP_PutAway_Fetch";
        const string _Insert = "USP_PutAway_Insert";
        const string _Search = "USP_PutAway_Search";
        const string _Edit = "USP_PutAway_Edit";
        const string _DashFetch = "USP_PutAwayDash_Fetch";
        const string _DashFetchNew = "USP_PACDash_Fetch";
        const string _ConfirmFetch = "USP_PutAwayCon_Fetch";
        const string _PACFetch = "USP_PutAwayConfirm_Fetch";
        const string _ConfirmInsert = "USP_PutAwayCon_Insert";
        const string _PACInsert = "USP_PAConfirm_Insert";
        const string _PrintSearch = "GetPutAwayEmployee";
        const string _Print = "PutAwayReport";
        const string _PALocation = "USP_PAC_Location";

        public List<PutAwayDet> Fetch(int WarehouseSno,string FromDate,string ToDate,string SelectedGrnSno,string SelectedBatchNo,string SelectedLotNo,int StoragelocationSno)
        {
            
            List<PutAwayDet> ArrFetch = new List<PutAwayDet>();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramWarehouse = new SqlParameter("@WarehouseSno", WarehouseSno);
            paramWarehouse.SqlDbType = SqlDbType.Int;
            parameters.Add(paramWarehouse);

            SqlParameter paramFromDate = new SqlParameter("@FromDate", FromDate);
            paramFromDate.SqlDbType = SqlDbType.VarChar;
            parameters.Add(paramFromDate);

            SqlParameter paramToDate = new SqlParameter("@ToDate", ToDate);
            paramToDate.SqlDbType = SqlDbType.VarChar;
            parameters.Add(paramToDate);

            SqlParameter paramStoragelocationSno = new SqlParameter("@StoragelocationSno", StoragelocationSno);
            paramStoragelocationSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramStoragelocationSno);

            SqlParameter paramSelectedGrn = new SqlParameter("@SelectedGrnSno", SelectedGrnSno);
            paramSelectedGrn.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramSelectedGrn);

            SqlParameter paramSelectedBatchNo = new SqlParameter("@SelectedBatchNo", SelectedBatchNo);
            paramSelectedBatchNo.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramSelectedBatchNo);

            SqlParameter paramSelectedLotNo = new SqlParameter("@SelectedLotNo", SelectedLotNo);
            paramSelectedLotNo.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramSelectedLotNo);

            try
            {
                DataSet ds = MasterExecuteCommand(_Fetch, parameters);
                ArrFetch = ds.Tables[0].ToCollection<PutAwayDet>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ArrFetch;
        }
        public PutAwaySave Edit(int PutAwaySno)
        {

            PutAwaySave ObjPutAway = new PutAwaySave();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramWarehouse = new SqlParameter("@PutAwaySno", PutAwaySno);
            paramWarehouse.SqlDbType = SqlDbType.Int;
            parameters.Add(paramWarehouse);

            try
            {
                DataSet ds = MasterExecuteCommand(_Edit, parameters);
                ObjPutAway.objPutAway = ds.Tables[0].ToCollection<PutAway>().FirstOrDefault();
                ObjPutAway.ArrPutAwayDet = ds.Tables[1].ToCollection<PutAwayDet>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjPutAway;
        }
        public PutAwayResponse Insert(PutAwaySave ObjSave)
        {
            string Result = "";

            PutAwayResponse objResp = new PutAwayResponse();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramPutAway = new SqlParameter("@PutAwaySno", ObjSave.objPutAway.PutAwaySno);
            paramPutAway.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPutAway);

            SqlParameter paramWarehouse = new SqlParameter("@WarehouseSno", ObjSave.objPutAway.WarehouseSno);
            paramWarehouse.SqlDbType = SqlDbType.Int;
            parameters.Add(paramWarehouse);

            SqlParameter paramFromDate = new SqlParameter("@FromDate", ObjSave.objPutAway.FromDate);
            paramFromDate.SqlDbType = SqlDbType.VarChar;
            parameters.Add(paramFromDate);

            SqlParameter paramToDate = new SqlParameter("@ToDate", ObjSave.objPutAway.ToDate);
            paramToDate.SqlDbType = SqlDbType.VarChar;
            parameters.Add(paramToDate);

            SqlParameter paramSelectedGrn = new SqlParameter("@SelectedGrn", ObjSave.objPutAway.SelectedGrn);
            paramSelectedGrn.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramSelectedGrn);

            SqlParameter paramSelectedGrnSno = new SqlParameter("@SelectedGrnSno", ObjSave.objPutAway.SelectedGrnSno);
            paramSelectedGrnSno.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramSelectedGrnSno);

            SqlParameter paramSelectedBatchNo = new SqlParameter("@SelectedBatchNo", ObjSave.objPutAway.SelectedBatchNo);
            paramSelectedBatchNo.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramSelectedBatchNo);

            SqlParameter paramSelectedLotNo = new SqlParameter("@SelectedLotNo", ObjSave.objPutAway.SelectedLotNo);
            paramSelectedLotNo.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramSelectedLotNo);

            SqlParameter paramEntryDate = new SqlParameter("@EntryDate", ObjSave.objPutAway.EntryDate);
            paramEntryDate.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramEntryDate);

            SqlParameter paramPutterSno = new SqlParameter("@PutterSno", ObjSave.objPutAway.PutterSno);
            paramPutterSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPutterSno);

            SqlParameter paramCreOpr = new SqlParameter("@CreOpr", ObjSave.objPutAway.CreOpr);
            paramCreOpr.SqlDbType = SqlDbType.Int;
            parameters.Add(paramCreOpr);

            SqlParameter paramIPNumber = new SqlParameter("@IPNumber", ObjSave.objPutAway.IPNumber);
            paramIPNumber.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(paramIPNumber);

            SqlParameter paramPutAwayType = new SqlParameter("@PutAwayType", ObjSave.objPutAway.PutAwayType);
            paramPutAwayType.SqlDbType = SqlDbType.Char;
            parameters.Add(paramPutAwayType);

            SqlParameter paramVirtualLoc = new SqlParameter("@VirtualLoc", ObjSave.objPutAway.VirtualLoc);
            paramVirtualLoc.SqlDbType = SqlDbType.Bit;
            parameters.Add(paramVirtualLoc);

            SqlParameter ParamBatchMix = new SqlParameter("@BatchMixingFlag", ObjSave.objPutAway.BatchMixingFlag);
            ParamBatchMix.SqlDbType = SqlDbType.Bit;
            parameters.Add(ParamBatchMix);

            SqlParameter ParamVirtualLocSno = new SqlParameter("@VirtualLocSno", ObjSave.objPutAway.VirtualLocSno);
            ParamVirtualLocSno.SqlDbType = SqlDbType.Int;
            parameters.Add(ParamVirtualLocSno);

            DataTable DetPutAway = new DataTable();
            DetPutAway.Columns.Add("GRNSno");
            DetPutAway.Columns.Add("GRNDetSno");
            DetPutAway.Columns.Add("Qty");
            DetPutAway.Columns.Add("PutterSno");
            DetPutAway.Columns.Add("Sts");

            foreach(PutAwayDet Arr in ObjSave.ArrPutAwayDet)
            {
                DetPutAway.Rows.Add(Arr.GRNSno,Arr.GRNDetSno,Arr.Qty,Arr.PutterSno,Arr.Sts);
            }

            SqlParameter paramPutAwayDet = new SqlParameter();
            paramPutAwayDet.ParameterName = "@PutAwayDet";
            paramPutAwayDet.SqlDbType = SqlDbType.Structured;
            paramPutAwayDet.Value = DetPutAway;
            paramPutAwayDet.Direction = ParameterDirection.Input;
            parameters.Add(paramPutAwayDet);

            try
            {
                DataSet ds = ExecuteCommand(_Insert, parameters);
                // Result = ds.Tables[0].Rows[0][0].ToString();
                objResp = ds.Tables[0].ToCustomList<PutAwayResponse>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                objResp.Result = ex.Message.ToString();
            }

            return objResp;
        }
        public Tuple<List<PutAwaySearch>, int> Search(PageRequest pageRequest)
        {
            List<PutAwaySearch> ObjSearch = new List<PutAwaySearch>();
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
                ObjSearch = dataSet.Tables[0].ToCollection<PutAwaySearch>();
            }
            return new Tuple<List<PutAwaySearch>, int>(ObjSearch, recordCount);

        }

        public List<PutAwayDash> PADashFetch(int EmployeeSno, string RoleFlag)
        {
            List<PutAwayDash> ArrPutAway = new List<PutAwayDash>();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramEmployeeSno = new SqlParameter("@EmployeeSno", EmployeeSno);
            paramEmployeeSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramEmployeeSno);

            SqlParameter paramRoleFlag = new SqlParameter("@RoleFlag", RoleFlag);
            paramRoleFlag.SqlDbType = SqlDbType.Char;
            parameters.Add(paramRoleFlag);

            try
            {
                DataSet ds = ExecuteCommand(_DashFetch, parameters);
                ArrPutAway = ds.Tables[0].ToCollection<PutAwayDash>();
            }
            catch(Exception ex)
            {

            }

            return ArrPutAway;
        }
        public PACDashFetch PACDashFetch(int EmployeeSno, string RoleFlag)
        {
            PACDashFetch objFetch = new PACDashFetch();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramEmployeeSno = new SqlParameter("@EmployeeSno", EmployeeSno);
            paramEmployeeSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramEmployeeSno);

            SqlParameter paramRoleFlag = new SqlParameter("@RoleFlag", RoleFlag);
            paramRoleFlag.SqlDbType = SqlDbType.Char;
            parameters.Add(paramRoleFlag);

            try
            {
                DataSet ds = ExecuteCommand(_DashFetchNew, parameters);
                objFetch.objPACDash = ds.Tables[0].ToCollection<PACDash>();
                objFetch.objPACDashDet = ds.Tables[1].ToCollection<PACDashDet>();
            }
            catch (Exception ex)
            {

            }

            return objFetch;
        }
        public PutAwayConfirm PAConfirmFetch(int PutAwayLocSno)
        {
            PutAwayConfirm ObjPutAway = new PutAwayConfirm();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramPALocSno = new SqlParameter("@PutAwayLocSno", PutAwayLocSno);
            paramPALocSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPALocSno);


            try
            {
                DataSet ds = ExecuteCommand(_ConfirmFetch, parameters);
                ObjPutAway = ds.Tables[0].ToCollection<PutAwayConfirm>().FirstOrDefault();
            }
            catch (Exception ex)
            {

            }

            return ObjPutAway;
        }
        public string PAConfirmInsert(PutAwayConfirm objConfirm)
        {
            string Result = "";

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramPALocSno = new SqlParameter("@PutAwayLocSno", objConfirm.PutAwayLocSno);
            paramPALocSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPALocSno);

            SqlParameter paramWarehouseSno = new SqlParameter("@WarehouseSno", objConfirm.WarehouseSno);
            paramWarehouseSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramWarehouseSno);

            SqlParameter paramLocationSno = new SqlParameter("@LocationSno", objConfirm.LocationSno);
            paramLocationSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramLocationSno);

            SqlParameter paramSubZoneSno = new SqlParameter("@SubZoneSno", objConfirm.SubZoneSno);
            paramSubZoneSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramSubZoneSno);

            SqlParameter paramPalletSno = new SqlParameter("@PalletSno", objConfirm.PalletSno);
            paramPalletSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPalletSno);

            SqlParameter paramPalletTypeSno = new SqlParameter("@PalletTypeSno", objConfirm.PalletTypeSno);
            paramPalletTypeSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPalletTypeSno);


            //SqlParameter paramStorageLocationSno = new SqlParameter("@StorageLocationSno", objConfirm.StoragelocationSno);
            //paramStorageLocationSno.SqlDbType = SqlDbType.Int;
            //parameters.Add(paramStorageLocationSno);


            try
            {
                DataSet ds = ExecuteCommand(_ConfirmInsert, parameters);
                Result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }

            return Result;
        }

        public DataTable PrintSearch(int PutAwaySno)
        {
            DataTable dt = new DataTable();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@PutAwaySno", PutAwaySno));
            DataSet ds = MasterExecuteCommand(_PrintSearch, Sqlparams);
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable Print(int PutAwaySno, int EmployeeSno)
        {
            DataTable dt = new DataTable();

            List<SqlParameter> objSqlparameters = new List<SqlParameter>();

            SqlParameter ParamPutAwaySno = new SqlParameter("@PutAwaySno", PutAwaySno);
            ParamPutAwaySno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(ParamPutAwaySno);

            SqlParameter ParamEmployeeSno = new SqlParameter("@EmployeeSno", EmployeeSno);
            ParamEmployeeSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(ParamEmployeeSno);

            try
            {
                DataSet ds = ExecuteCommand(_Print, objSqlparameters);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
        public PAFetch PACFetch(int PutAwayLocSno)
        {
            PAFetch ObjPA = new PAFetch();

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramPALocSno = new SqlParameter("@PutAwayLocSno", PutAwayLocSno);
            paramPALocSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPALocSno);


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
        public string PACInsert(PAFetch objConfirm)
        {
            string Result = "";

            List<SqlParameter> parameters = new List<SqlParameter>();


            SqlParameter paramPutAwaySno = new SqlParameter("@PutAwaySno", objConfirm.objPAConfirm.PutAwaySno);
            paramPutAwaySno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPutAwaySno);

            SqlParameter paramPutAwayDetSno = new SqlParameter("@PutAwayDetSno", objConfirm.objPAConfirm.PutAwayDetSno);
            paramPutAwayDetSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPutAwayDetSno);

            SqlParameter paramPALocSno = new SqlParameter("@PutAwayLocSno", objConfirm.objPAConfirm.PutAwayLocSno);
            paramPALocSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPALocSno);

            SqlParameter paramWarehouseSno = new SqlParameter("@WarehouseSno", objConfirm.objPAConfirm.WarehouseSno);
            paramWarehouseSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramWarehouseSno);

            SqlParameter paramLocationSno = new SqlParameter("@LocationSno", objConfirm.objPAConfirm.LocationSno);
            paramLocationSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramLocationSno);

            SqlParameter paramSubZoneSno = new SqlParameter("@SubZoneSno", objConfirm.objPAConfirm.SubZoneSno);
            paramSubZoneSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramSubZoneSno);

            SqlParameter paramPalletSno = new SqlParameter("@PalletSno", objConfirm.objPAConfirm.PalletSno);
            paramPalletSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPalletSno);

            SqlParameter paramPalletTypeSno = new SqlParameter("@PalletTypeSno", objConfirm.objPAConfirm.PalletTypeSno);
            paramPalletTypeSno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramPalletTypeSno);

            SqlParameter paramQty = new SqlParameter("@Qty", objConfirm.objPAConfirm.Qty);
            paramQty.SqlDbType = SqlDbType.Decimal;
            parameters.Add(paramQty);

            SqlParameter paramLocationFlag = new SqlParameter("@LocationFlag", objConfirm.objPAConfirm.LocationFlag);
            paramLocationFlag.SqlDbType = SqlDbType.Char;
            parameters.Add(paramLocationFlag);

            SqlParameter paramEntryType = new SqlParameter("@EntryType", objConfirm.objPAConfirm.EntryType);
            paramEntryType.SqlDbType = SqlDbType.Char;
            parameters.Add(paramEntryType);

            DataTable DetPutAway = new DataTable();

            DetPutAway.Columns.Add("PutAwayLocSno");
            DetPutAway.Columns.Add("Qty");
            DetPutAway.Columns.Add("SubZoneSno");
            DetPutAway.Columns.Add("LocationSno");
            DetPutAway.Columns.Add("Location");
            DetPutAway.Columns.Add("PalletSno");
            DetPutAway.Columns.Add("PalletTypeSno");
            DetPutAway.Columns.Add("Pallet");

            foreach (PAConfirmDet Arr in objConfirm.ArrPutAway)
            {
                DetPutAway.Rows.Add(Arr.PutAwayLocSno, Arr.Qty, Arr.SubZoneSno, Arr.LocationSno, Arr.Location, Arr.PalletSno, Arr.PalletTypeSno, Arr.Pallet);
            }

            SqlParameter paramPALoc = new SqlParameter();
            paramPALoc.ParameterName = "@PALocations";
            paramPALoc.SqlDbType = SqlDbType.Structured;
            paramPALoc.Value = DetPutAway;
            paramPALoc.Direction = ParameterDirection.Input;
            parameters.Add(paramPALoc);

            try
            {
                DataSet ds = ExecuteCommand(_PACInsert, parameters);
                Result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }

            return Result;
        }
        public LocData PACLocation(int UserSno, string TypeValue, int WarehouseSno, int ItemSno, int GRNDetSno, int PutAwayLocSno)
        {
            LocData ObjLOC = new LocData();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@TypeValue", TypeValue));
            parameters.Add(new SqlParameter("@WarehouseSno", WarehouseSno));
            parameters.Add(new SqlParameter("@ItemSno", ItemSno));
            parameters.Add(new SqlParameter("@GRNDetSno", GRNDetSno));
            parameters.Add(new SqlParameter("@PutAwayLocSno", PutAwayLocSno));

            try
            {
                DataSet ds = ExecuteCommand(_PALocation, parameters);
                ObjLOC = ds.Tables[0].ToCollection<LocData>().FirstOrDefault();
            }
            catch (Exception ex)
            {

            }

            return ObjLOC;
        }

    }
}
