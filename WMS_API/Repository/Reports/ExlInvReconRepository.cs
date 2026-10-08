using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using System.Data.SqlClient;
using System.Data;
using POMS.Entity.Masters;
using POM.Repository;
using Librarys.Extenders;
using Librarys;

namespace POMS.Repository
{
    public class ExlInvReconRepository : RepositoryBaseNew
    {
        const string _Check = "ExlInvReconciliationUpload";
        public List<ExlInvReconciliationDet> CheckforExcel(List<ExlInvReconciliationDet> obj, int InvStsSno, int SBUSno, int BranchSno, string FromDate, string ToDate) //,int BranchSno, int businessUnitSno
        {

            DataTable tt = new DataTable();
            tt.Columns.Add("DocumentFilename");
            tt.Columns.Add("FilePath");
            //tt.Columns.Add("Branch");
            //tt.Columns.Add("BusinessUnit");
            tt.Columns.Add("InvoiceNo");
            tt.Columns.Add("InvoiceDate");
            tt.Columns.Add("InvoiceStatus");




            foreach (ExlInvReconciliationDet dd in obj)
            {
                tt.Rows.Add(
                            dd.DocumentFilename,
                            dd.FilePath,
                            //dd.Branch,
                            //dd.BusinessUnit,
                            dd.InvoiceNo,
                            dd.InvoiceDate,
                            dd.InvoiceStatus              
                            );
            }

            SqlParameter prInvStsSno = new SqlParameter("@InvStsSno", InvStsSno);
            prInvStsSno.SqlDbType = SqlDbType.Int;

            SqlParameter prBusinessUnitSno = new SqlParameter("@BusinessUnitSno", SBUSno);
            prBusinessUnitSno.SqlDbType = SqlDbType.Int;

            SqlParameter prBranchSno = new SqlParameter("@BranchSno", BranchSno);
            prBranchSno.SqlDbType = SqlDbType.Int;

            SqlParameter prFromDate = new SqlParameter("@FromDate", FromDate);
            prFromDate.SqlDbType = SqlDbType.NVarChar;

            SqlParameter prToDate = new SqlParameter("@ToDate", ToDate);
            prToDate.SqlDbType = SqlDbType.NVarChar;

            SqlParameter ParamPriupload = new SqlParameter();
            ParamPriupload.ParameterName = "@ExcelDetails";
            ParamPriupload.SqlDbType = SqlDbType.Structured;
            ParamPriupload.Value = tt;
            ParamPriupload.Direction = ParameterDirection.Input;


            SqlCommand sqlCmd = new SqlCommand("ExlInvReconciliationUpload");
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 20000;
            sqlCmd.Parameters.Add(ParamPriupload);
            sqlCmd.Parameters.Add(prInvStsSno);
            sqlCmd.Parameters.Add(prBusinessUnitSno);
            sqlCmd.Parameters.Add(prBranchSno);
            sqlCmd.Parameters.Add(prFromDate);
            sqlCmd.Parameters.Add(prToDate);

            try
            {
                SqlDataReader dataReader = sqlCmd.ExecuteReader();


                DataSet ds = new DataSet();
                DataTable dtl = new DataTable();
                ds.Tables.Add(dtl);
                ds.Load(dataReader, LoadOption.OverwriteChanges, dtl);

                obj = ds.Tables[0].ToCollection<ExlInvReconciliationDet>();
            }
            catch (Exception ex) { }
            return obj;
        }

        string _InsertUpload = "ExlInvReconciliationInsert";
        public string Upload_Insert(ExlInvReconBoth objUpload)
        {
            List<SqlParameter> SQLparameter = new List<SqlParameter>();

            SqlParameter PrimarySno = new SqlParameter("@InvReconSno", objUpload.ParentClass.PrimarySno);
            PrimarySno.SqlDbType = SqlDbType.Int;
            SQLparameter.Add(PrimarySno);

            SqlParameter BusinessUnitSno = new SqlParameter("@BusinessUnitSno", objUpload.ParentClass.BusinessUnitSno);
            BusinessUnitSno.SqlDbType = SqlDbType.Int;
            SQLparameter.Add(BusinessUnitSno);

            SqlParameter BranchSno = new SqlParameter("@BranchSno", objUpload.ParentClass.BranchSno);
            BranchSno.SqlDbType = SqlDbType.Int;
            SQLparameter.Add(BranchSno);

            SqlParameter CreOpr = new SqlParameter("@Creopr", objUpload.ParentClass.Creopr);
            CreOpr.SqlDbType = SqlDbType.Int;
            SQLparameter.Add(CreOpr);


            SqlParameter ActionName = new SqlParameter("@ActionName", objUpload.ParentClass.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            SQLparameter.Add(ActionName);

            SqlParameter IPNumber = new SqlParameter("@IpNumber", objUpload.ParentClass.IPNumber);
            IPNumber.SqlDbType = SqlDbType.NVarChar;
            SQLparameter.Add(IPNumber);

            SqlParameter SQLparameternDet = new SqlParameter();
            SQLparameternDet.ParameterName = "@UploadDetails";
            SQLparameternDet.SqlDbType = SqlDbType.Structured;
            SQLparameternDet.Value = objUpload.ExlInvReconciliationDet.ToDataTable<ExlInvReconciliationDet>();
            SQLparameternDet.Direction = ParameterDirection.Input;
            SQLparameter.Add(SQLparameternDet);

            DataSet ds = ExecuteCommand(_InsertUpload, SQLparameter);
            string Result = ds.Tables[0].Rows[0][0].ToString();
            return Result;
        }

    }
}
