using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using POMS.Entity;
using POMS.Entity.Masters;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using System.Data;
using Entity.Operations;

namespace Repository.Operations
{
   public class StockDisposeDispatchRepository : RepositoryBaseNew
    {
        const string _Edit = "USP_STOCK_DISPOSAL_DISPATCH_EDIT";
        const string _Insert = "USP_STOCK_DISPOSAL_DISPATCH_INSERT";
        const string _Search = "USP_STOCK_DISPOSAL_DISPATCH_SEARCH";
        const string _Print = "USP_STOCK_DISPOSAL_DISPATCH_PRINT";
        public StockDisposeResponse Insert(StockDisposeDetails objStockDisposeDetails)
        {

            StockDisposeResponse objResp = new StockDisposeResponse();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter StockDisposeSno = new SqlParameter("@StockDisposeSno", objStockDisposeDetails.objStockDispose.StockDisposeSno);
            StockDisposeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(StockDisposeSno);

            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objStockDisposeDetails.objStockDispose.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

            SqlParameter DispatchDate = new SqlParameter("@DispatchDate", objStockDisposeDetails.objStockDispose.DispatchDate);
            DispatchDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(DispatchDate);

            SqlParameter InvoiceNo = new SqlParameter("@InvoiceNo", objStockDisposeDetails.objStockDispose.InvoiceNo);
            InvoiceNo.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(InvoiceNo);

            SqlParameter InvoiceDate = new SqlParameter("@InvoiceDate", objStockDisposeDetails.objStockDispose.InvoiceDate);
            InvoiceDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(InvoiceDate);

            SqlParameter Remarks = new SqlParameter("@Remarks", objStockDisposeDetails.objStockDispose.Remarks);
            Remarks.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(Remarks);

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objStockDisposeDetails.objStockDispose.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objStockDisposeDetails.objStockDispose.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);



            SqlParameter objFloorDetails = new SqlParameter();
            objFloorDetails.ParameterName = "@StockDisposeDetails";
            objFloorDetails.SqlDbType = SqlDbType.Structured;
            objFloorDetails.Value = objStockDisposeDetails.objStockDisposeDet.ToDataTable<StockDisposeDet>();
            objFloorDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objFloorDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);



            objResp = ds.Tables[0].ToCustomList<StockDisposeResponse>().FirstOrDefault();



            return objResp;


        }

        public Tuple<List<StockDispose>, int> Search(PageRequest pageRequest)
        {
            List<StockDispose> SearchList = new List<StockDispose>();
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
                SearchList = dataSet.Tables[0].ToCollection<StockDispose>();
            }
            return new Tuple<List<StockDispose>, int>(SearchList, recordCount);

        }

        public StockDisposeDetails Edit(int StockDisposeSno)
        {
            StockDisposeDetails objStockDisposeDetails = new StockDisposeDetails();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@StockDisposeSno", StockDisposeSno));

            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            objStockDisposeDetails.objStockDispose = ds.Tables[0].ToCustomList<StockDispose>().FirstOrDefault();
            objStockDisposeDetails.objStockDisposeDet = ds.Tables[1].ToCustomList<StockDisposeDet>();
            return objStockDisposeDetails;
        }

   

        public DataSet Print(int StockDisposeDispatchSno)
        {
            DataSet ds = new DataSet();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            SqlParameter ParmCycleCountSno = new SqlParameter("@StockDisposeDispatchSno", StockDisposeDispatchSno);
            ParmCycleCountSno.SqlDbType = SqlDbType.Int;
            Sqlparams.Add(ParmCycleCountSno);

            try
            {
                ds = MasterExecuteCommand(_Print, Sqlparams);

            }
            catch (Exception ex)
            {

            }
            return ds;
        }
    }
}
