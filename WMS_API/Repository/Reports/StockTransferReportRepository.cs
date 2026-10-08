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

namespace Repository.Reports
{
   public class StockTransferReportRepository : RepositoryBaseNew
    {
        const string _DropDown = "STReportDropdown";
        public List<StockTransferDD> DropDown()
        {
            List<StockTransferDD> objSTDD = new List<StockTransferDD>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet dataSet = MasterExecuteCommand(_DropDown, parameters);
            DataTable dtBranch = new DataTable();
            objSTDD = dataSet.Tables[0].ToCollection<StockTransferDD>();
            
            return objSTDD;
        }
    }
}
