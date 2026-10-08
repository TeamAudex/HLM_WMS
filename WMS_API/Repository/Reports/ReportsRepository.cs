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
    public class ReportsRepository :  RepositoryBaseNew
    {
        public List<ReportsClass> AutoComplete(string SP, int UserSno, string TypeValue, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "")
        {
            List<ReportsClass> Obj = new List<ReportsClass>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@TypeValue", TypeValue));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            parameters.Add(new SqlParameter("@Condition2", Condition2));
            parameters.Add(new SqlParameter("@Condition3", Condition3));
            parameters.Add(new SqlParameter("@Condition4", Condition4));
            parameters.Add(new SqlParameter("@Condition5", Condition5));
            parameters.Add(new SqlParameter("@Condition6", Condition6));
            DataSet dataset = MasterExecuteCommand(SP, parameters);

            //DataTable DT = new DataTable();
            Obj = dataset.Tables[0].ToCollection<ReportsClass>();
            return Obj;
        }
        public List<ReportsClass> AutoCompleteIST(string SP, int UserSno, string TypeValue, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "",string Condition7="")
        {
            List<ReportsClass> Obj = new List<ReportsClass>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@TypeValue", TypeValue));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            parameters.Add(new SqlParameter("@Condition2", Condition2));
            parameters.Add(new SqlParameter("@Condition3", Condition3));
            parameters.Add(new SqlParameter("@Condition4", Condition4));
            parameters.Add(new SqlParameter("@Condition5", Condition5));
            parameters.Add(new SqlParameter("@Condition6", Condition6));
            parameters.Add(new SqlParameter("@Condition7", Condition7));
            DataSet dataset = MasterExecuteCommand(SP, parameters);

            //DataTable DT = new DataTable();
            Obj = dataset.Tables[0].ToCollection<ReportsClass>();
            return Obj;
        }

        const string _DropDownOrder = "DDFileType";
        public DropDownList DropDownFetch()
        {
            DropDownList DD = new DropDownList();
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet dataSet = MasterExecuteCommand(_DropDownOrder, parameters);
            DataTable dtBranch = new DataTable();
            DD.DropDown = dataSet.Tables[0].ToCollection<DropDownFile>();
            return DD;
        }

        public DropDownList DropDownFetchData(string SP)
        {
            DropDownList DD = new DropDownList();
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet dataSet = MasterExecuteCommand(SP, parameters);
            DataTable dtBranch = new DataTable();
            DD.DropDown = dataSet.Tables[0].ToCollection<DropDownFile>();
            return DD;
        }


        public List<List<Reports1>> DropDowns(string SP, int UserSno, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "")
        {
            List<List<Reports1>> dds = new List<List<Reports1>>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            parameters.Add(new SqlParameter("@Condition2", Condition2));
            parameters.Add(new SqlParameter("@Condition3", Condition3));
            parameters.Add(new SqlParameter("@Condition4", Condition4));
            parameters.Add(new SqlParameter("@Condition5", Condition5));
            parameters.Add(new SqlParameter("@Condition6", Condition6));
            DataSet dataSet = MasterExecuteCommand(SP, parameters);
            int i = 0;
            foreach (DataTable dt in dataSet.Tables)
            {
                dds.Add(dt.ToCollection<Reports1>());
            }
            return dds;
        }

        public string GetPGIResend(int IssueOrderErrorConfSno, int UserSno, string IPNumber)
        {
            string result = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IssueOrderErrorConfSno", IssueOrderErrorConfSno));
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@IPNumber", IPNumber));
            DataSet ds = ExecuteCommand("USP_PGI_Confirmation_Resend", parameters);
            result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public string CycleCountConfirmResend(int CycleCountErrorConfSno, int UserSno, string IPNumber)
        {
            string result = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CycleCountErrorConfSno", CycleCountErrorConfSno));
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@IPNumber", IPNumber));
            DataSet ds = ExecuteCommand("USP_CycleCount_Confirmation_Resend", parameters);
            result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }
        public string StockDisposeResend(int StockDisposeErrorConfSno, int UserSno, string IPNumber)
        {
            string result = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StockDisposeErrorConfSno", StockDisposeErrorConfSno));
            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@IPNumber", IPNumber));
            DataSet ds = ExecuteCommand("USP_StockDispose_Confirmation_Resend", parameters);
            result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }


    }
}
