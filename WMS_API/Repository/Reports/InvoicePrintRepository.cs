using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

using POMS.Entity;
using System.Data.SqlClient;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using System.Data;

namespace POMS.Repository
{
   public class InvoicePrintRepository: RepositoryBaseNew
    {
        public List<Lrgrid> Dispatch_Filter(LrInvoice objDispatchModel)
        {
            const string _Filter = "Invoicesearch";
            
            List<Lrgrid> objDispatchGridModel = new List<Lrgrid>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@LRSno", objDispatchModel.LRNO));
            parameters.Add(new SqlParameter("@BranchSno", objDispatchModel.BranchSno));
            parameters.Add(new SqlParameter("@orderSno", objDispatchModel.orderSno));
            parameters.Add(new SqlParameter("@BikerSno", objDispatchModel.BikerSno));
            parameters.Add(new SqlParameter("@Fromdate", objDispatchModel.FromDate));
            parameters.Add(new SqlParameter("@Todate", objDispatchModel.ToDate));
            DataSet dataSet = ExecuteCommand(_Filter, parameters);
            DataTable dtBranch = new DataTable();
            objDispatchGridModel = dataSet.Tables[0].ToCollection<Lrgrid>();
            return objDispatchGridModel;
        }


        public List<Lrgrid> Downloaded(LrInvoice objDispatchModel)
        {
            const string _Filter = "DownloadedInvoicesearch";
            string DownloadPath = System.Configuration.ConfigurationManager.ConnectionStrings["DownloadPath"].ConnectionString; 
            List<Lrgrid> objDispatchGridModel = new List<Lrgrid>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@VendorMasterSno", objDispatchModel.VendorMasterSno));
            parameters.Add(new SqlParameter("@BranchSno", objDispatchModel.BranchSno));
            parameters.Add(new SqlParameter("@orderSno", objDispatchModel.orderSno));
            parameters.Add(new SqlParameter("@BusinessUnitSno", objDispatchModel.BusinessUnitSno));
            parameters.Add(new SqlParameter("@Fromdate", objDispatchModel.FromDate));
            parameters.Add(new SqlParameter("@Todate", objDispatchModel.ToDate));
            parameters.Add(new SqlParameter("@DownloadPath", DownloadPath));
            DataSet dataSet = ExecuteCommand(_Filter, parameters);
            DataTable dtBranch = new DataTable();
            objDispatchGridModel = dataSet.Tables[0].ToCollection<Lrgrid>();
            return objDispatchGridModel;
        }




        const string _LR_Insert = "InvoiceInsert";

        //public List<HSNMaster> HSNInsert(HSNMaster objhsnclass)
        //{
        //    List<HSNMaster> ObjHSN = new List<HSNMaster>();

        public List<Lrgrid> LRInsert(objLr objobjLr)
        {
            List<Lrgrid> ObjHSN = new List<Lrgrid>();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            // objobjLr.objdet = new List<Lrgridtable>();

            SqlParameter paramsorderSno = new SqlParameter("@InvoicePrintSno", objobjLr.objLrdDiv.orderSno);
            paramsorderSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsorderSno);

            //SqlParameter paramsIPNumber = new SqlParameter("@IPNumber", objobjLr.objLrdDiv.IPNumber);
            //paramsIPNumber.SqlDbType = SqlDbType.Int;
            //sqlparams.Add(paramsIPNumber);

            SqlParameter paramsIPNumber = new SqlParameter("@IPNumber", objobjLr.objLrdDiv.IPNumber);
            paramsIPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsIPNumber);



            SqlParameter paramsCreDate = new SqlParameter("@CreDate", objobjLr.objLrdDiv.CreDate);
            paramsCreDate.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsCreDate);

            SqlParameter paramsSts = new SqlParameter("@sts", objobjLr.objLrdDiv.Sts);
            paramsSts.SqlDbType = SqlDbType.Bit;
            sqlparams.Add(paramsSts);

            //foreach (Lrgrid item in objobjLr.objLrDDEt)
            //{
            //    Lrgridtable ee = new Lrgridtable();
            //    ee.LRSno = Convert.ToInt16(item.orderSno);

            //    objobjLr.objdet.Add(ee);
            //}


            SqlParameter paramPDLRDetails = new SqlParameter();
            paramPDLRDetails.ParameterName = "@InvoiceGrid";
            paramPDLRDetails.SqlDbType = SqlDbType.Structured;
           
            paramPDLRDetails.Value = objobjLr.objLrDDEt.ToDataTable<Lrgrid>();
            paramPDLRDetails.Direction = ParameterDirection.Input;
          
            sqlparams.Add(paramPDLRDetails);

            DataSet ds = ExecuteCommand(_LR_Insert, sqlparams);
            //printSno, Message_TExtx
            //string Result = ds.Tables[0].Rows[0][0].ToString();
            //return Result;

            ObjHSN = ds.Tables[0].ToCustomList<Lrgrid>();
            return ObjHSN;

        }
    }
}
