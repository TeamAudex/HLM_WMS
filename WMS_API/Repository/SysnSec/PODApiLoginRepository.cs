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
    public class PODApiLoginRepository: RepositoryBaseNew
    {
        public List<Employee> LoginGet(string UserName, string Password)
        {
            string _USP_LOGIN = "LOGINPOD";
            List<Employee> _Employee = new List<Employee>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserName", UserName));
            parameters.Add(new SqlParameter("@Password", Password));
            DataSet dataSet = ExecuteCommand(_USP_LOGIN, parameters);
            DataRowCollection rows = dataSet.Tables[0].Rows;
            _Employee = dataSet.Tables[0].ToCollection<Employee>();
            return _Employee;
        }
    }
}
