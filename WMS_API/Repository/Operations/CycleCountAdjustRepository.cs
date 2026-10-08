using Entity.Operations;
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

namespace Repository.Operations
{
    public class CycleCountAdjustRepository : RepositoryBaseNew
    {

        const string _Fetch = "USP_CCAdjust_Fetch";
        const string _Excel = "USP_CCAdjust_Excel";
        const string _PDF = "USP_CCAdjust_PDF";
        const string _Insert = "USP_CCAdjust_Insert";
        const string _Search = "USP_CycleCountAdjust__Search";
        const string _Edit = "";
        const string _DropDown = "GetStockType";

        public List<STDD> DropDown()
        {
            List<STDD> objSTDD = new List<STDD>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet dataSet = MasterExecuteCommand(_DropDown, parameters);
            DataTable dtBranch = new DataTable();
            objSTDD = dataSet.Tables[0].ToCollection<STDD>();

            return objSTDD;
        }

        public CycleCountList GetCycleCount(int CycleCountSno)
        {
            CycleCountList objRes = new CycleCountList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            SqlParameter ParmCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            ParmCycleCountSno.SqlDbType = SqlDbType.Int;
            Sqlparams.Add(ParmCycleCountSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Fetch, Sqlparams);
                objRes.objCycleCount = ds.Tables[0].ToCollection<CycleCountAdjust>().FirstOrDefault();
                objRes.ArrCycleCountDet = ds.Tables[1].ToCollection<CycleCountAdjustDet>();
            }
            catch (Exception ex)
            {

            }
            return objRes;
        }

        public CycleCountList GetCycleExcel(int CycleCountSno)
        {
            CycleCountList objRes = new CycleCountList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            SqlParameter ParmCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            ParmCycleCountSno.SqlDbType = SqlDbType.Int;
            Sqlparams.Add(ParmCycleCountSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Excel, Sqlparams);
                objRes.objCycleCount = ds.Tables[0].ToCollection<CycleCountAdjust>().FirstOrDefault();
                objRes.ArrCycleCountDet = ds.Tables[1].ToCollection<CycleCountAdjustDet>();
            }
            catch (Exception ex)
            {

            }
            return objRes;
        }

        public DataSet GetPDF(int CycleCountSno)
        {
            DataSet ds = new DataSet();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            SqlParameter ParmCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            ParmCycleCountSno.SqlDbType = SqlDbType.Int;
            Sqlparams.Add(ParmCycleCountSno);

            try
            {
                 ds = MasterExecuteCommand(_PDF, Sqlparams);
                //objRes.objCycleCount = ds.Tables[0].ToCollection<CycleCountAdjust>().FirstOrDefault();
                //objRes.ArrCycleCountDet = ds.Tables[1].ToCollection<CycleCountAdjustDet>();
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
        public string Insert(CycleCountList ObjCycleCountList)
        {
            List<SqlParameter> objParams = new List<SqlParameter>();

            SqlParameter CycleCountSno = new SqlParameter("@CycleCountSno", ObjCycleCountList.objCycleCount.CycleCountSno);
            CycleCountSno.SqlDbType = SqlDbType.Int;
            objParams.Add(CycleCountSno);

            SqlParameter AdjustDate = new SqlParameter("@AdjustDate", ObjCycleCountList.objCycleCount.AdjustDate);
            AdjustDate.SqlDbType = SqlDbType.VarChar;
            objParams.Add(AdjustDate);

            SqlParameter CreOpr = new SqlParameter("@CreOpr", ObjCycleCountList.objCycleCount.CreOpr);
            CreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(CreOpr);

            SqlParameter IpNumber = new SqlParameter("@IpNumber", ObjCycleCountList.objCycleCount.IpNumber);
            IpNumber.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(IpNumber);

            SqlParameter SubmittedSts = new SqlParameter("@SubmittedSts", ObjCycleCountList.objCycleCount.SubmittedSts);
            SubmittedSts.SqlDbType = SqlDbType.Bit;
            objParams.Add(SubmittedSts);

            DataTable ArrCycleCountDet = new DataTable();

            ArrCycleCountDet.Columns.Add("CCphysicalSno");
            ArrCycleCountDet.Columns.Add("LocStockSno");
            ArrCycleCountDet.Columns.Add("SystemCount");
            ArrCycleCountDet.Columns.Add("PhysicalCount");
            ArrCycleCountDet.Columns.Add("Reason");
            ArrCycleCountDet.Columns.Add("StorageLocationSno");
            ArrCycleCountDet.Columns.Add("StockTypeSno");

            foreach (CycleCountAdjustDet objDet in ObjCycleCountList.ArrCycleCountDet)
            {
                ArrCycleCountDet.Rows.Add(objDet.CCphysicalSno,objDet.LocStockSno, objDet.SystemCount, objDet.PhysicalCount, objDet.Reason,objDet.StorageLocationSno, objDet.StockTypeSno);
            }

            SqlParameter WarehouseZoneDet = new SqlParameter();
            WarehouseZoneDet.ParameterName = "@CycleCountDet";
            WarehouseZoneDet.SqlDbType = SqlDbType.Structured;
            WarehouseZoneDet.Value = ArrCycleCountDet;
            WarehouseZoneDet.Direction = ParameterDirection.Input;
            objParams.Add(WarehouseZoneDet);

            string Result = "";
            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objParams);
                Result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }
        public Tuple<List<CycleCountAdjustSearch>, int> Search(PageRequest pageRequest)
        {
            List<CycleCountAdjustSearch> ObjSearch = new List<CycleCountAdjustSearch>();
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
                ObjSearch = dataSet.Tables[0].ToCollection<CycleCountAdjustSearch>();
            }
            return new Tuple<List<CycleCountAdjustSearch>, int>(ObjSearch, recordCount);

        }
    }
}