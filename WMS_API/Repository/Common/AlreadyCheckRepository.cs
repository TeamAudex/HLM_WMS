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
    public class AlreadyCheckRepository:RepositoryBaseNew
    {
        public string AlreadyexistOne(string Condition,string Condition1)
        {
            string result = "0";
            string _USP_Already_check = "USP_MASTER_CHECK";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CONDITION", Condition));
            parameters.Add(new SqlParameter("@CONDITION_ONE", Condition1));
            DataSet dataSet = ExecuteCommand(_USP_Already_check, parameters);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                result = dataSet.Tables[0].Rows[0][0].ToString();
            }

            return result;
        }
        public string AlreadyexistTwo(string Condition, string Condition1, string Condition2)
        {
            string result = "0";
            string _USP_Already_check = "USP_MASTER_CHECK";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CONDITION", Condition));
            parameters.Add(new SqlParameter("@CONDITION_ONE", Condition1));
            parameters.Add(new SqlParameter("@CONDITION_TWO", Condition2));
            DataSet dataSet = ExecuteCommand(_USP_Already_check, parameters);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                result = dataSet.Tables[0].Rows[0][0].ToString();
            }
            return result;
        }
        public string AlreadyexistThree(string Condition, string Condition1, string Condition2, string Condition3)
        {
            string result = "0";
            string _USP_Already_check = "USP_MASTER_CHECK";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CONDITION", Condition));
            parameters.Add(new SqlParameter("@CONDITION_ONE", Condition1));
            parameters.Add(new SqlParameter("@CONDITION_TWO", Condition2)); 
            parameters.Add(new SqlParameter("@CONDITION_THREE", Condition3));
            DataSet dataSet = ExecuteCommand(_USP_Already_check, parameters);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                result = dataSet.Tables[0].Rows[0][0].ToString();
            }
            return result;
        }
        public string AlreadyexistFive(string Condition, string Condition1, string Condition2, string Condition3, string Condition4, string Condition5)
        {
            string result = "0";
            string _USP_Already_check = "USP_MASTER_CHECK";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CONDITION", Condition));
            parameters.Add(new SqlParameter("@CONDITION_ONE", Condition1));
            parameters.Add(new SqlParameter("@CONDITION_TWO", Condition2));
            parameters.Add(new SqlParameter("@CONDITION_THREE", Condition3));
            parameters.Add(new SqlParameter("@CONDITION_FOUR", Condition4));
            parameters.Add(new SqlParameter("@CONDITION_FIVE", Condition5));
            DataSet dataSet = ExecuteCommand(_USP_Already_check, parameters);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                result = dataSet.Tables[0].Rows[0][0].ToString();
            }
            return result;
        }


    }
}
