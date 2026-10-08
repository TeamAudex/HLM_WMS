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
     public  class DispatchRepository : RepositoryBaseNew
    {
        const string _Fetch = "USP_DISPATCH_FETCH";
        const string _Insert = "USP_DISPATCH_INSERT";
        const string _Edit = "USP_DISPATCH_EDIT";
        const string _Search = "USP_DISPATCH_SEARCH";
        public List<DispatchDet> Fetch(Dispatch objDispatch)
        {

            List<DispatchDet> objDispatchDet = new List<DispatchDet>();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objDispatch.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

            SqlParameter FromDate = new SqlParameter("@FromDate", objDispatch.FromDate);
            FromDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter("@ToDate", objDispatch.ToDate);
            ToDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ToDate);

            SqlParameter StockTypeSno = new SqlParameter("@StockTypeSno", objDispatch.StockTypeSno);
            StockTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(StockTypeSno);

            SqlParameter TxtIssueOrderSno = new SqlParameter("@TxtIssueOrderSno", objDispatch.TxtIssueOrderSno);
            TxtIssueOrderSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtIssueOrderSno);

     


            DataSet ds = MasterExecuteCommand(_Fetch, sqlParameters);
            objDispatchDet = ds.Tables[0].ToCollection<DispatchDet>();

            return objDispatchDet;


        }

        public DispatchResponse Insert(DispatchList objDispatchList)
        {

            DispatchResponse objResp = new DispatchResponse();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter DispatchSno = new SqlParameter("@DispatchSno", objDispatchList.objDispatch.DispatchSno);
            DispatchSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(DispatchSno);

            SqlParameter DispatchDate = new SqlParameter("@DispatchDate", objDispatchList.objDispatch.DispatchDate);
            DispatchDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(DispatchDate);

            //SqlParameter FromDate = new SqlParameter("@FromDate", objDispatchList.objDispatch.FromDate);
            //FromDate.SqlDbType = SqlDbType.VarChar;
            //sqlParameters.Add(FromDate);

            //SqlParameter ToDate = new SqlParameter("@ToDate", objDispatchList.objDispatch.ToDate);
            //ToDate.SqlDbType = SqlDbType.VarChar;
            //sqlParameters.Add(ToDate);


            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objDispatchList.objDispatch.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

            SqlParameter StockTypeSno = new SqlParameter("@StockTypeSno", objDispatchList.objDispatch.StockTypeSno);
            StockTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(StockTypeSno);


            SqlParameter paramCreopr = new SqlParameter("@Creopr", objDispatchList.objDispatch.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objDispatchList.objDispatch.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);

            SqlParameter objFloorDetails = new SqlParameter();
            objFloorDetails.ParameterName = "@DispatchDetails";
            objFloorDetails.SqlDbType = SqlDbType.Structured;
            objFloorDetails.Value = objDispatchList.objDispatchDet.ToDataTable<DispatchDet>();
            objFloorDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objFloorDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);


            //string result = string.Empty;


            //result = ds.Tables[0].Rows[0][0].ToString();
            objResp = ds.Tables[0].ToCustomList<DispatchResponse>().FirstOrDefault();




            return objResp;


        }

        public DispatchList Edit(int DispatchSno)
        {
            DispatchList objDispatchList = new DispatchList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@DispatchSno", DispatchSno));

            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            objDispatchList.objDispatch = ds.Tables[0].ToCustomList<Dispatch>().FirstOrDefault();
            objDispatchList.objDispatchDet = ds.Tables[1].ToCustomList<DispatchDet>();
            return objDispatchList;
        }

        public Tuple<List<Dispatch>, int> Search(PageRequest pageRequest)
        {
            List<Dispatch> SearchList = new List<Dispatch>();
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
                SearchList = dataSet.Tables[0].ToCollection<Dispatch>();
            }
            return new Tuple<List<Dispatch>, int>(SearchList, recordCount);

        }
    }
}
