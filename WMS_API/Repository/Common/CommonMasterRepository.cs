using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POMS.Entity;
using POM.Repository;
using Librarys.Extenders;
using Librarys;

namespace POMS.Repository
{
    public class CommonRepository : RepositoryBaseNew
    {
        //public List<CommonMasterAuto> CommonMaster(string param1, string param2)
        //{
        //    const string _Usp_common_Master_Auto_complete = "Usp_common_Master_Auto_complete";
        //    List<CommonMasterAuto> _CommonMaster = new List<CommonMasterAuto>();
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@condition", param1));
        //    parameters.Add(new SqlParameter("@condition1", param2));
        //    DataSet dataSet = ExecuteCommand(_Usp_common_Master_Auto_complete, parameters);
        //    DataTable dtBranch = new DataTable();
        //    _CommonMaster = dataSet.Tables[0].ToCollection<CommonMasterAuto>();
        //    return _CommonMaster;
        //}


        public List<CommonMasterAuto> AutoComplete(string SP, int UserSno, string TypeValue, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "")
        {
            List<CommonMasterAuto> Obj = new List<CommonMasterAuto>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@TypeValue", TypeValue));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            parameters.Add(new SqlParameter("@Condition2", Condition2));
            parameters.Add(new SqlParameter("@Condition3", Condition3));
            parameters.Add(new SqlParameter("@Condition4", Condition4));
            parameters.Add(new SqlParameter("@Condition5", Condition5));
            parameters.Add(new SqlParameter("@Condition6", Condition6));
            DataSet dataset = ExecuteCommand(SP, parameters);

            //DataTable DT = new DataTable();
            Obj = dataset.Tables[0].ToCollection<CommonMasterAuto>();
            return Obj;
        }

        public CommondropdownList1 DropDown1(string SP)
        {
            CommondropdownList1 objdrop = new CommondropdownList1();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = ExecuteCommand(SP, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objCommonMasterAuto = ds.Tables[0].ToCollection<CommonMasterAuto>();
            objdrop.objOwnnership = ds.Tables[1].ToCollection<CommonMasterAuto>();
            return objdrop;
        }

        public CommondropdownList1 DropDownSalesReport(string SP, int UserSno)
        {
            CommondropdownList1 objDropDown = new CommondropdownList1();

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParams.Add(new SqlParameter("@UserSno", UserSno));

            DataSet ds = ExecuteCommand(SP, SqlParams);
            objDropDown.objCommonMasterAuto = ds.Tables[0].ToCollection<CommonMasterAuto>();
            return objDropDown;
        }

        public CommonMasterAuto GetServerDateTime()
        {
            CommonMasterAuto objdate = new CommonMasterAuto();          
            DataSet ds = ExecuteCommand("GetServerDateTime",new List<SqlParameter>());
            objdate = ds.Tables[0].ToCollection<CommonMasterAuto>().FirstOrDefault();
            return objdate;
        }
    }
}
