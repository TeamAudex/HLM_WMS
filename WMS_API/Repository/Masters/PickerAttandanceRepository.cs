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

namespace Repository.Masters
{
   public class PickerAttandanceRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_PickerAttnd_Insert";
        const string _Search = "USP_PickerAttand_Search";
        const string _Edit = "USP_PickerAttand_Edit";

        public PickerAttandanceResult Insert(PickerAttandancedetList objPickerAttandance)
        {
            PickerAttandanceResult ObjResult = new PickerAttandanceResult();
            List<SqlParameter> objParams = new List<SqlParameter>();

            SqlParameter paraPickerAttandanceSno = new SqlParameter("@PickerAttandanceSno", objPickerAttandance.objPickerAttandance.PickerAttandanceSno);
            paraPickerAttandanceSno.SqlDbType = SqlDbType.Int;
            objParams.Add(paraPickerAttandanceSno);

            SqlParameter paraWarehouseSno = new SqlParameter("@WarehouseSno", objPickerAttandance.objPickerAttandance.WarehouseSno);
            paraWarehouseSno.SqlDbType = SqlDbType.Int;
            objParams.Add(paraWarehouseSno);

            SqlParameter paraEntryDate = new SqlParameter("@EntryDate", objPickerAttandance.objPickerAttandance.EntryDate);
            paraEntryDate.SqlDbType = SqlDbType.VarChar;
            objParams.Add(paraEntryDate);

            SqlParameter paraTypeOfPicker = new SqlParameter("@TypeOfPicker", objPickerAttandance.objPickerAttandance.TypeOfPicker);
            paraTypeOfPicker.SqlDbType = SqlDbType.VarChar;
            objParams.Add(paraTypeOfPicker);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", objPickerAttandance.objPickerAttandance.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(objCreOpr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objPickerAttandance.objPickerAttandance.IpNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objPickerAttandance.objPickerAttandance.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ActionName);

            SqlParameter ReqLog = new SqlParameter("@ReqLog", objPickerAttandance.objPickerAttandance.ReqLog);
            ReqLog.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ReqLog);

            SqlParameter objsts = new SqlParameter("@Sts", objPickerAttandance.objPickerAttandance.Sts);
            objsts.SqlDbType = SqlDbType.Bit;
            objParams.Add(objsts);

            SqlParameter paraSubmittedSts = new SqlParameter("@SubmittedSts", objPickerAttandance.objPickerAttandance.SubmittedSts);
            paraSubmittedSts.SqlDbType = SqlDbType.Bit;
            objParams.Add(paraSubmittedSts);

            DataTable ArrPickerAttandanceRow = new DataTable();

            ArrPickerAttandanceRow.Columns.Add("PickerAtnddetSno");
            ArrPickerAttandanceRow.Columns.Add("PickerAtndSno");
            ArrPickerAttandanceRow.Columns.Add("EmployeeSno");
            ArrPickerAttandanceRow.Columns.Add("sts");
            foreach (PickerAttandancedet objDet in objPickerAttandance.ObjPickerAttandancedet)
            {
                ArrPickerAttandanceRow.Rows.Add(objDet.PickerAtnddetSno, objDet.PickerAtndSno, objDet.EmployeeSno, objDet.sts);
            }
            SqlParameter PickerAttandanceRow = new SqlParameter();
            PickerAttandanceRow.ParameterName = "@PickerAtnddetSno";
            PickerAttandanceRow.SqlDbType = SqlDbType.Structured;
            PickerAttandanceRow.Value = ArrPickerAttandanceRow;
            PickerAttandanceRow.Direction = ParameterDirection.Input;
            objParams.Add(PickerAttandanceRow);

            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objParams);
                ObjResult = ds.Tables[0].ToCustomList<PickerAttandanceResult>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return ObjResult;
    }
        public Tuple<List<PickerAttandance>, int> Search(PageRequest pageRequest)
        {
            List<PickerAttandance> SearchList = new List<PickerAttandance>();
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
                SearchList = dataSet.Tables[0].ToCollection<PickerAttandance>();
            }
            return new Tuple<List<PickerAttandance>, int>(SearchList, recordCount);
        }
        public PickerAttandancedetList Edit(int PickerAttandanceSno)
        {
            PickerAttandancedetList objEdit = new PickerAttandancedetList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paraPickerAttandanceSno = new SqlParameter("@PickerAttandanceSno", PickerAttandanceSno);
            paraPickerAttandanceSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paraPickerAttandanceSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Edit, sqlparams);
                objEdit.objPickerAttandance = ds.Tables[0].ToCustomList<PickerAttandance>().FirstOrDefault();
                objEdit.ObjPickerAttandancedet = ds.Tables[1].ToCustomList<PickerAttandancedet>();
            }
            catch(Exception ex)
            {
                
            }

            return objEdit;

        }
    }
}
