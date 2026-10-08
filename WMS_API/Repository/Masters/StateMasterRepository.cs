
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POMS.Entity;
using POM.Repository;
using Librarys;
using Librarys.Extenders;


namespace POM.Repository
{
    public class StateMasterRepository:RepositoryBaseNew
    {
        const string State_Insert = "USP_INSERT_STATE_MASTER";
        const string State_Search = "USP_SEARCH_STATE_MASTER";
        const string State_Edit = "USP_EDIT_STATE_MASTER";
        const string State_AutoComplete = "USP_StateMaster_AutoComplete";
        public string StateInsert(StateMaster StateObj)
        {
            List<SqlParameter> sqlparameters = new List<SqlParameter>();

            SqlParameter StateSno = new SqlParameter("@StateSno", StateObj.StateSno);
            StateSno.SqlDbType = SqlDbType.Int;
            sqlparameters.Add(StateSno);

            SqlParameter CountryName = new SqlParameter("@CountrySno", StateObj.CountrySno);
            CountryName.SqlDbType = SqlDbType.Int;
            sqlparameters.Add(CountryName);

            SqlParameter StateName = new SqlParameter("@StateName", StateObj.StateName);
            StateName.SqlDbType = SqlDbType.NVarChar;
            sqlparameters.Add(StateName);

            SqlParameter StateCode = new SqlParameter("@StateCode", StateObj.StateCode);
            StateCode.SqlDbType = SqlDbType.NVarChar;
            sqlparameters.Add(StateCode);

            SqlParameter Sts = new SqlParameter("@Sts", StateObj.Sts);
            Sts.SqlDbType = SqlDbType.NVarChar;
            sqlparameters.Add(Sts);


            SqlParameter ActionName = new SqlParameter("@ActionName", StateObj.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            sqlparameters.Add(ActionName);


            SqlParameter IPNumber = new SqlParameter("@IPNumber", StateObj.IPNumber);
            IPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlparameters.Add(IPNumber);


            SqlParameter CreOpr = new SqlParameter("@CreOpr", StateObj.CreOpr);
            CreOpr.SqlDbType = SqlDbType.NVarChar;
            sqlparameters.Add(CreOpr);

            DataSet ds = MasterExecuteCommand(State_Insert, sqlparameters);
            string Result = ds.Tables[0].Rows[0][0].ToString();
            return Result;
        }
        

        public Tuple<List<StateMaster>, int> StateSearch(PageRequest pageRequest)
        {
            List<StateMaster> objStates = new List<StateMaster>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                    parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                    parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                    parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                    parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                    parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(State_Search, parameters, ref recordCount);

                    objStates = dataSet.Tables[0].ToCollection<StateMaster>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<StateMaster>, int>(objStates, recordCount);
        }
        public List<StateMaster> StateEdit(int Sno)
        {
            List<StateMaster> Country = new List<StateMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StateSno", Sno));
            DataSet dataSet = MasterExecuteCommand(State_Edit, parameters);
            Country = dataSet.Tables[0].ToCustomList<StateMaster>();
            return Country;
        }
        public List<StateMaster> StateMasterAutoComplete(string TypeText)
        {
            List<StateMaster> Obj = new List<StateMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", TypeText));
            DataSet dataset = MasterExecuteCommand(State_AutoComplete,parameters);
            DataTable DT = new DataTable();
            Obj = dataset.Tables[0].ToCollection<StateMaster>();
            return Obj;
        }
    }
}
