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
using Entity.Reports;
using System.IO;
using System.Net;
using System.Net.Security;
using POMS.Repository;
using Newtonsoft.Json;

namespace Repository.Reports
{
    public class PickListPrintRepository : RepositoryBaseNew
    {
        const string _Fetch = "USP_PICKLIST_PRINT_FETCH";
        public List<PickListPrintDet> Fetch(PickListPrint objPickList)
        {

            List<PickListPrintDet> objPickListDetails = new List<PickListPrintDet>();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objPickList.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

            SqlParameter PickListDate = new SqlParameter("@PickListDate", objPickList.PickListDate);
            PickListDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(PickListDate);

            SqlParameter FromDate = new SqlParameter("@FromDate", objPickList.FromDate);
            FromDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter("@ToDate", objPickList.ToDate);
            ToDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ToDate);

      

            SqlParameter TxtIssueOrderSno = new SqlParameter("@TxtIssueOrderSno", objPickList.TxtIssueOrderSno);
            TxtIssueOrderSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtIssueOrderSno);

            SqlParameter TxtPickerSno = new SqlParameter("@TxtPickerSno", objPickList.TxtPickerSno);
            TxtPickerSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtPickerSno);

            SqlParameter TxtPLSno = new SqlParameter("@TxtPLSno", objPickList.TxtPLSno);
            TxtPLSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtPLSno);


            DataSet ds = MasterExecuteCommand(_Fetch, sqlParameters);
            //  objPickListDet = ds.Tables[0].ToCollection<PickListDet>();
          
            objPickListDetails = ds.Tables[0].ToCustomList<PickListPrintDet>();


            return objPickListDetails;


        }
    }
}
