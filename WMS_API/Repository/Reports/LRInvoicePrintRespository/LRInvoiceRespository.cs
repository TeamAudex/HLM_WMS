using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using System.Data.SqlClient;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using System.Data;

namespace POMS.Repository
{
    public class LRInvoiceRepository : RepositoryBaseNew
    {

        const string _Filter = "LRInvoicesearch";
        public List<LRInvoiceDet> Filter(LRInvoiceDet objDispatchModel)
        {        
          
            List<LRInvoiceDet> objDispatchGridModel = new List<LRInvoiceDet>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@VendorMasterSno", objDispatchModel.VendorMasterSno));
            parameters.Add(new SqlParameter("@BranchSno", objDispatchModel.BranchSno));
            parameters.Add(new SqlParameter("@LR_MAPPING_DET_SNO", objDispatchModel.LRNoSno));
            parameters.Add(new SqlParameter("@BusinessUnitSno", objDispatchModel.BusinessUnitSno));
            parameters.Add(new SqlParameter("@LR_MAPPING_NO", objDispatchModel.LRNO));
            //parameters.Add(new SqlParameter("@Fromdate", objDispatchModel.FromDate));
            //parameters.Add(new SqlParameter("@Todate", objDispatchModel.ToDate));
            DataSet dataSet = ExecuteCommand(_Filter, parameters);
            DataTable dtBranch = new DataTable();
            objDispatchGridModel = dataSet.Tables[0].ToCollection<LRInvoiceDet>();
            return objDispatchGridModel;
        }
      



        const string _Insert = "LRInvoiceInsert";
        public List<LRInvoiceDet> Insert(LRInvoiceGrid objLRInvoiceGrid)
        {
            List<LRInvoiceDet> objLR = new List<LRInvoiceDet>();
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paramsLRPrintSno = new SqlParameter("@LRPrintSno", objLRInvoiceGrid.objLRInvoice.LRPrintSno);
            paramsLRPrintSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsLRPrintSno);

            SqlParameter paramsLrSno = new SqlParameter("@LRSno", objLRInvoiceGrid.objLRInvoice.LrSno);
            paramsLrSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsLrSno);

            SqlParameter paramsIPNumber = new SqlParameter("@IPNumber", objLRInvoiceGrid.objLRInvoice.IPNumber);
            paramsIPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsIPNumber);

            SqlParameter paramsCreDate = new SqlParameter("@CreDate", objLRInvoiceGrid.objLRInvoice.CreDate);
            paramsCreDate.SqlDbType = SqlDbType.Date;
            sqlparams.Add(paramsCreDate);

            SqlParameter paramssts = new SqlParameter("@sts", objLRInvoiceGrid.objLRInvoice.sts);
            paramssts.SqlDbType = SqlDbType.Bit;
            sqlparams.Add(paramssts);
       


            SqlParameter paramLRInvoice = new SqlParameter();
            paramLRInvoice.ParameterName = "@LRInvoicegrid";
            paramLRInvoice.SqlDbType = SqlDbType.Structured;
            paramLRInvoice.Value = objLRInvoiceGrid.objLRInvoiceDet.ToDataTable<LRInvoiceDet>();
            paramLRInvoice.Direction = ParameterDirection.Input;
            sqlparams.Add(paramLRInvoice);

            DataSet ds = ExecuteCommand(_Insert, sqlparams);
            objLR = ds.Tables[0].ToCustomList<LRInvoiceDet>();
            return objLR;

        }
    }
}



