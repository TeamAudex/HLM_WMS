using Entity.Operations;
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
    public class CycleCountAdjustApprovalRepository : RepositoryBaseNew
    {
        const string _Edit = "USP_CycleCountAdjust_Approval_Edit";
        const string _Insert = "USP_CycleCountAdjust_Approval_Insert";
        const string _Search = "USP_CycleCountAdjust_Approval_Search";
        public CycleCountAdjustApprovalList Edit(int CycleCountSno)
        {
            CycleCountAdjustApprovalList objEdit = new CycleCountAdjustApprovalList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            SqlParameter ParmCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            ParmCycleCountSno.SqlDbType = SqlDbType.Int;
            Sqlparams.Add(ParmCycleCountSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
                objEdit.CycleCountAdjustApproval = ds.Tables[0].ToCollection<CycleCountAdjustApproval>().FirstOrDefault();
                objEdit.CycleCountAdjustApprovalDet = ds.Tables[1].ToCollection<CycleCountAdjustApprovalDet>();
            }
            catch (Exception ex)
            {

            }
            return objEdit;
        }

        public string Insert(CycleCountAdjustApprovalList ObjCycleCountAdjustApprovalList)
        {
            List<SqlParameter> objParams = new List<SqlParameter>();

            SqlParameter CycleCountSno = new SqlParameter("@CycleCountSno", ObjCycleCountAdjustApprovalList.CycleCountAdjustApproval.CycleCountSno);
            CycleCountSno.SqlDbType = SqlDbType.Int;
            objParams.Add(CycleCountSno);

            SqlParameter AdjustDate = new SqlParameter("@AdjustDate", ObjCycleCountAdjustApprovalList.CycleCountAdjustApproval.AdjustDate);
            AdjustDate.SqlDbType = SqlDbType.VarChar;
            objParams.Add(AdjustDate);

            SqlParameter ApprovalStatus = new SqlParameter("@ApprovalStatus", ObjCycleCountAdjustApprovalList.CycleCountAdjustApproval.ApprovalStatus);
            ApprovalStatus.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ApprovalStatus);

            SqlParameter CreOpr = new SqlParameter("@CreOpr", ObjCycleCountAdjustApprovalList.CycleCountAdjustApproval.CreOpr);
            CreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(CreOpr);

            SqlParameter IpNumber = new SqlParameter("@IpNumber", ObjCycleCountAdjustApprovalList.CycleCountAdjustApproval.IpNumber);
            IpNumber.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(IpNumber);

            DataTable ArrCycleCountDet = new DataTable();

            ArrCycleCountDet.Columns.Add("CCphysicalSno");
            ArrCycleCountDet.Columns.Add("LocStockSno");
            ArrCycleCountDet.Columns.Add("SystemCount");
            ArrCycleCountDet.Columns.Add("PhysicalCount");
            ArrCycleCountDet.Columns.Add("Reason");
            ArrCycleCountDet.Columns.Add("StorageLocationSno");
            ArrCycleCountDet.Columns.Add("StockTypeSno");
            ArrCycleCountDet.Columns.Add("ApproverRemarks");

            foreach (CycleCountAdjustApprovalDet objDet in ObjCycleCountAdjustApprovalList.CycleCountAdjustApprovalDet)
            {
                ArrCycleCountDet.Rows.Add(objDet.CCphysicalSno, objDet.LocStockSno, objDet.SystemCount, objDet.PhysicalCount, objDet.Reason, objDet.StorageLocationSno, objDet.StockTypeSno, objDet.ApproverRemarks);
            }

            SqlParameter WarehouseZoneDet = new SqlParameter();
            WarehouseZoneDet.ParameterName = "@CycleCountAdjustApprovalDet";
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
        public Tuple<List<CycleCountAdjustApprovalSearch>, int> Search(PageRequest pageRequest)
        {
            List<CycleCountAdjustApprovalSearch> ObjSearch = new List<CycleCountAdjustApprovalSearch>();
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
                ObjSearch = dataSet.Tables[0].ToCollection<CycleCountAdjustApprovalSearch>();
            }
            return new Tuple<List<CycleCountAdjustApprovalSearch>, int>(ObjSearch, recordCount);
        }
    }
}
