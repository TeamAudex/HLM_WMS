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
    public class CycleCountPlanRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_CycleCount_Plan_Insert";
        public CycleCountPlanResult Insert(CycleCountPlanList objCycleCountPlanList)
        {
            CycleCountPlanResult ObjResult = new CycleCountPlanResult();
            List<SqlParameter> objSqlParams = new List<SqlParameter>();


            SqlParameter paraCycleCountPlanningSno = new SqlParameter("@CycleCountPlanningSno", objCycleCountPlanList.objCycleCountPlan.CycleCountPlanningSno);
            paraCycleCountPlanningSno.SqlDbType = SqlDbType.Int;
            objSqlParams.Add(paraCycleCountPlanningSno);

            SqlParameter objWarehouseSno = new SqlParameter("@WarehouseSno", objCycleCountPlanList.objCycleCountPlan.WarehouseSno);
            objWarehouseSno.SqlDbType = SqlDbType.Int;
            objSqlParams.Add(objWarehouseSno);

            SqlParameter paraPlanningDate = new SqlParameter("@PlanningDate", objCycleCountPlanList.objCycleCountPlan.PlanningDate);
            paraPlanningDate.SqlDbType = SqlDbType.VarChar;
            objSqlParams.Add(paraPlanningDate);

            SqlParameter paraTypeOfCycleCount = new SqlParameter("@TypeOfCycleCount", objCycleCountPlanList.objCycleCountPlan.TypeOfCycleCount);
            paraTypeOfCycleCount.SqlDbType = SqlDbType.VarChar;
            objSqlParams.Add(paraTypeOfCycleCount);

            SqlParameter paraStartDate = new SqlParameter("@StartDate", objCycleCountPlanList.objCycleCountPlan.StartDate);
            paraStartDate.SqlDbType = SqlDbType.VarChar;
            objSqlParams.Add(paraStartDate);

            SqlParameter paraNoOfMonth = new SqlParameter("@NoOfMonth", objCycleCountPlanList.objCycleCountPlan.NoOfMonth);
            paraNoOfMonth.SqlDbType = SqlDbType.Int;
            objSqlParams.Add(paraNoOfMonth);

            SqlParameter paraCycleCountDate = new SqlParameter("@CycleCountDate", objCycleCountPlanList.objCycleCountPlan.CycleCountDate);
            paraCycleCountDate.SqlDbType = SqlDbType.VarChar;
            objSqlParams.Add(paraCycleCountDate);

            SqlParameter paraCycleCountBasedOn = new SqlParameter("@CycleCountBasedOn", objCycleCountPlanList.objCycleCountPlan.CycleCountBasedOn);
            paraCycleCountBasedOn.SqlDbType = SqlDbType.VarChar;
            objSqlParams.Add(paraCycleCountBasedOn);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", objCycleCountPlanList.objCycleCountPlan.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            objSqlParams.Add(objCreOpr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objCycleCountPlanList.objCycleCountPlan.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            objSqlParams.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objCycleCountPlanList.objCycleCountPlan.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            objSqlParams.Add(ActionName);
            
            SqlParameter objsts = new SqlParameter("@Sts", objCycleCountPlanList.objCycleCountPlan.Sts);
            objsts.SqlDbType = SqlDbType.Bit;
            objSqlParams.Add(objsts);

            SqlParameter paraSubmittedSts = new SqlParameter("@SubmittedSts", objCycleCountPlanList.objCycleCountPlan.SubmittedSts);
            paraSubmittedSts.SqlDbType = SqlDbType.Bit;
            objSqlParams.Add(paraSubmittedSts);

            DataTable ArrCycleCountPlanDet = new DataTable();

            ArrCycleCountPlanDet.Columns.Add("CycleCountPlanningDetSno");
            ArrCycleCountPlanDet.Columns.Add("ItemSno");
            ArrCycleCountPlanDet.Columns.Add("ItemTypeSno");
            ArrCycleCountPlanDet.Columns.Add("SubZoneSno");
            ArrCycleCountPlanDet.Columns.Add("RackLocationSno");
            ArrCycleCountPlanDet.Columns.Add("StockTypeSno");
            ArrCycleCountPlanDet.Columns.Add("UOMSno");
            ArrCycleCountPlanDet.Columns.Add("BatchNo");
            ArrCycleCountPlanDet.Columns.Add("Sts");

            foreach (CycleCountPlanDet objDet in objCycleCountPlanList.ObjCycleCountPlanDet)
            {
                ArrCycleCountPlanDet.Rows.Add(objDet.CycleCountPlanningDetSno, objDet.ItemSno, objDet.ItemTypeSno, objDet.SubZoneSno, objDet.RackLocationSno, objDet.StockTypeSno, objDet.UOMSno, objDet.BatchNo, objDet.Sts);
            }

            SqlParameter WhLayoutRow = new SqlParameter();
            WhLayoutRow.ParameterName = "@CycleCountPlanDet";
            WhLayoutRow.SqlDbType = SqlDbType.Structured;
            WhLayoutRow.Value = ArrCycleCountPlanDet;
            WhLayoutRow.Direction = ParameterDirection.Input;
            objSqlParams.Add(WhLayoutRow);
            
            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objSqlParams);
                ObjResult = ds.Tables[0].ToCustomList<CycleCountPlanResult>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return ObjResult;

        }


        const string _Search = "USP_CycleCount_Plan_Search";

        public Tuple<List<CycleCountPlan>, int> Search(PageRequest pageRequest)
        {
            List<CycleCountPlan> SearchList = new List<CycleCountPlan>();
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
                SearchList = dataSet.Tables[0].ToCollection<CycleCountPlan>();
            }
            return new Tuple<List<CycleCountPlan>, int>(SearchList, recordCount);

        }

        const string _Edit = "USP_CycleCount_Plan_Edit";
        public CycleCountPlanList Edit(int CycleCountPlanningSno)
        {

            CycleCountPlanList objCycleCountPlanList = new CycleCountPlanList();

            List<SqlParameter> objSqlparameters = new List<SqlParameter>();

            SqlParameter paraCycleCountPlanningSno = new SqlParameter("@CycleCountPlanningSno", CycleCountPlanningSno);
            paraCycleCountPlanningSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(paraCycleCountPlanningSno);
            
            try
            {
                DataSet ds = MasterExecuteCommand(_Edit, objSqlparameters);
                objCycleCountPlanList.objCycleCountPlan = ds.Tables[0].ToCollection<CycleCountPlan>().FirstOrDefault();
                objCycleCountPlanList.ObjCycleCountPlanDet = ds.Tables[1].ToCustomList<CycleCountPlanDet>();         
            }
            catch (Exception ex)
            {
            }
            return objCycleCountPlanList;
        }
    }
}
