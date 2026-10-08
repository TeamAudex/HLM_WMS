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
    public  class SystematicPickListRepository : RepositoryBaseNew
    {
        const string _Fetch = "FetchSystematicPickList";
        const string _Insert = "USP_SYSTEMATIC_PICKLIST_INSERT";
        const string _Search = "USP_SYSTEMATIC_PICKLIST_SEARCH";
        const string _Edit = "USP_SYSTEMATIC_PICKLIST_EDIT";
        const string _STInsert = "USP_SYSTEMATIC_PICKLIST_ST_INSERT";
        public PickListDetails Fetch(PickList objPickList)
        {

            PickListDetails objPickListDetails = new PickListDetails();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objPickList.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(WarehouseSno);

            SqlParameter FromDate = new SqlParameter("@FromDate", objPickList.FromDate);
            FromDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter("@ToDate", objPickList.ToDate);
            ToDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ToDate);

            SqlParameter TransactionTypeSno = new SqlParameter("@TransactionTypeSno", objPickList.TransactionTypeSno);
            TransactionTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(TransactionTypeSno);

            SqlParameter StoragelocationSno = new SqlParameter("@StoragelocationSno", objPickList.StoragelocationSno);
            StoragelocationSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(StoragelocationSno);

            SqlParameter StockTypeSno = new SqlParameter("@StockTypeSno", objPickList.StockTypeSno);
            StockTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(StockTypeSno);

            SqlParameter TxtIssueOrderSno = new SqlParameter("@TxtIssueOrderSno", objPickList.TxtIssueOrderSno);
            TxtIssueOrderSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtIssueOrderSno);

            SqlParameter TxtBatchNo = new SqlParameter("@TxtBatchNo", objPickList.TxtBatchNo);
            TxtBatchNo.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtBatchNo);

            SqlParameter objNoofOrders = new SqlParameter("@NoofOrders", objPickList.NoofOrders);
            objNoofOrders.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(objNoofOrders);


            DataSet ds = MasterExecuteCommand(_Fetch, sqlParameters);
            //  objPickListDet = ds.Tables[0].ToCollection<PickListDet>();
            objPickListDetails.objPickListDet = ds.Tables[0].ToCustomList<PickListDet>();
            objPickListDetails.objPickListOrder = ds.Tables[1].ToCustomList<PickListOrder>().FirstOrDefault();
          
          


            return objPickListDetails;


        }

        public PickListResponse Insert(PickListDetails objPickListDetails)
        {

            PickListResponse objResp = new PickListResponse();
            objResp.objPickListDet = new List<PickListDet>();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter PickListSno = new SqlParameter("@PickListSno", objPickListDetails.objPickList.PickListSno);
            PickListSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(PickListSno);

            SqlParameter PickListDate = new SqlParameter("@PickListDate", objPickListDetails.objPickList.PickListDate);
            PickListDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(PickListDate);

            SqlParameter FromDate = new SqlParameter("@FromDate", objPickListDetails.objPickList.FromDate);
            FromDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter("@ToDate", objPickListDetails.objPickList.ToDate);
            ToDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ToDate);


            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objPickListDetails.objPickList.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(WarehouseSno);

            SqlParameter EmployeeSno = new SqlParameter("@EmployeeSno", objPickListDetails.objPickList.EmployeeSno);
            EmployeeSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(EmployeeSno);

            SqlParameter VirtualLocationSts = new SqlParameter("@VirtualLocationSts", objPickListDetails.objPickList.VirtualLocationSts);
            VirtualLocationSts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(VirtualLocationSts);

            SqlParameter VirtualLocSno = new SqlParameter("@VirtualLocSno", objPickListDetails.objPickList.VirtualLocSno);
            EmployeeSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(VirtualLocSno);

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objPickListDetails.objPickList.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objPickListDetails.objPickList.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);


            SqlParameter objNoofOrders = new SqlParameter("@NoofOrders", objPickListDetails.objPickList.NoofOrders);
            objNoofOrders.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(objNoofOrders);

            SqlParameter objFloorDetails = new SqlParameter();
            objFloorDetails.ParameterName = "@PickListDetails";
            objFloorDetails.SqlDbType = SqlDbType.Structured;
            objFloorDetails.Value = objPickListDetails.objPickListDet.ToDataTable<PickListDet>();
            objFloorDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objFloorDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);


            //string result = string.Empty;


            //result = ds.Tables[0].Rows[0][0].ToString();
            objResp = ds.Tables[0].ToCustomList<PickListResponse>().FirstOrDefault();
            objResp.objPickListDet = ds.Tables[1].ToCustomList<PickListDet>();
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    objResp.objPickListDet = ds.Tables[1].ToCustomList<PickListDet>();
            //}

            return objResp;


        }

        public PickListResponse STInsert(PickListDetails objPickListDetails)
        {

            PickListResponse objResp = new PickListResponse();
            objResp.objPickListDet = new List<PickListDet>();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter PickListSno = new SqlParameter("@ISTSno", objPickListDetails.objPickList.PickListSno);
            PickListSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(PickListSno);

            SqlParameter PickListDate = new SqlParameter("@TransferDate", objPickListDetails.objPickList.PickListDate);
            PickListDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(PickListDate);


            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objPickListDetails.objPickList.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(WarehouseSno);

         

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objPickListDetails.objPickList.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objPickListDetails.objPickList.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);



            SqlParameter objFloorDetails = new SqlParameter();
            objFloorDetails.ParameterName = "@PickListDetails";
            objFloorDetails.SqlDbType = SqlDbType.Structured;
            objFloorDetails.Value = objPickListDetails.objPickListSTDet.ToDataTable<PickListSTDet>();
            objFloorDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objFloorDetails);

            DataSet ds = MasterExecuteCommand(_STInsert, sqlParameters);


            //string result = string.Empty;


            //result = ds.Tables[0].Rows[0][0].ToString();
            objResp = ds.Tables[0].ToCustomList<PickListResponse>().FirstOrDefault();
         //   objResp.objPickListDet = ds.Tables[1].ToCustomList<PickListDet>();
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    objResp.objPickListDet = ds.Tables[1].ToCustomList<PickListDet>();
            //}

            return objResp;


        }

        public PickListDetails Edit(int PickListSno)
        {
            PickListDetails objPickListDetails = new PickListDetails();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@PickListSno", PickListSno));

            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            objPickListDetails.objPickList = ds.Tables[0].ToCustomList<PickList>().FirstOrDefault();
            objPickListDetails.objPickListDet = ds.Tables[1].ToCustomList<PickListDet>();
            return objPickListDetails;
        }

        public Tuple<List<PickList>, int> Search(PageRequest pageRequest)
        {
            List<PickList> SearchList = new List<PickList>();
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
                SearchList = dataSet.Tables[0].ToCollection<PickList>();
            }
            return new Tuple<List<PickList>, int>(SearchList, recordCount);
        }

        const string _PickListPickerSearch = "USP_SYSTEMATIC_PICKLIST_PICKER_SEARCH";
        public Tuple<List<PickListPickerSearch>, int> PickListPickerSearch(PageRequest pageRequest)
        {
            List<PickListPickerSearch> SearchList = new List<PickListPickerSearch>();
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
                DataSet dataSet = MasterExecuteCommand(_PickListPickerSearch, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                SearchList = dataSet.Tables[0].ToCollection<PickListPickerSearch>();
            }
            return new Tuple<List<PickListPickerSearch>, int>(SearchList, recordCount);
        }
    }
}
