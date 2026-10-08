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
    public class OrderLifeCycleRepository : RepositoryBaseNew
    {
        string _OrdLifeCycleSearch = "ORDERLIFECYCLERRT";

        public Tuple<List<OrderLifeCycleGrid>, int> Search(OrderLifeCycleRequest Request)
        {
            List<OrderLifeCycleGrid> OrderLifeCycle = new List<OrderLifeCycleGrid>();
            int recordCount = 0;
            if (Request != null)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@PageSize", Request.PageSize));
                    parameters.Add(new SqlParameter("@PageNumber", Request.PageNumber));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    parameters.Add(new SqlParameter("@UserSno", Request.UserSno));
                    parameters.Add(new SqlParameter("@CompanySno", Request.CompanySno));
                    parameters.Add(new SqlParameter("@BranchSno", Request.BranchSno));
                    parameters.Add(new SqlParameter("@SBUSno", Request.SBUSno));
                    parameters.Add(new SqlParameter("@OrderSno", Request.OrderSno));
                    parameters.Add(new SqlParameter("@OrderFromDate", Request.OrderFromDate));
                    parameters.Add(new SqlParameter("@OrderToDate", Request.OrderToDate));
                    parameters.Add(new SqlParameter("@CustomerSno", Request.CustomerSno));
                    parameters.Add(new SqlParameter("@InvoiceSno", Request.InvoiceSno));
                    parameters.Add(new SqlParameter("@InvoiceFromDate", Request.InvoiceFromDate));
                    parameters.Add(new SqlParameter("@InvoiceToDate", Request.InvoiceToDate));
                    parameters.Add(new SqlParameter("@InvoiceFromValue", Request.InvoiceFromValue));
                    parameters.Add(new SqlParameter("@InvoiceToValue", Request.InvoiceToValue));
                    parameters.Add(new SqlParameter("@CommoditySno", Request.CommoditySno));
                    parameters.Add(new SqlParameter("@ApprovedBySno", Request.ApprovedBySno));
                    parameters.Add(new SqlParameter("@ApprovedStatus", Request.ApprovedStatus));
                    parameters.Add(new SqlParameter("@ApproveFromDate", Request.ApproveFromDate));
                    parameters.Add(new SqlParameter("@ApproveToDate", Request.ApproveToDate));
                    parameters.Add(new SqlParameter("@TripFromDate", Request.TripFromDate));
                    parameters.Add(new SqlParameter("@TripToDate", Request.TripToDate));
                    parameters.Add(new SqlParameter("@LRFromDate", Request.LRFromDate));
                    parameters.Add(new SqlParameter("@LRToDate", Request.LRToDate));
                    parameters.Add(new SqlParameter("@LSPSno", Request.LSPSno));
                    parameters.Add(new SqlParameter("@PODSno", Request.PODSno));
                    parameters.Add(new SqlParameter("@PODFromDate", Request.PODFromDate));
                    parameters.Add(new SqlParameter("@PODToDate", Request.PODToDate));
                    parameters.Add(new SqlParameter("@PODDelivery", Request.PODDelivery));
                    parameters.Add(new SqlParameter("@DisputeForPOD", Request.DisputeForPOD));
                    parameters.Add(new SqlParameter("@DisputeForBill", Request.DisputeForBill));
                    parameters.Add(new SqlParameter("@Trntype", Request.TrnType));
                    DataSet dataSet = ExecuteCommand(_OrdLifeCycleSearch, parameters, ref recordCount);
                    OrderLifeCycle = dataSet.Tables[0].ToCollection<OrderLifeCycleGrid>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<OrderLifeCycleGrid>, int>(OrderLifeCycle, recordCount);
        }
    }
}
