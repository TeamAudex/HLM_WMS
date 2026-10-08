using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Masters;
using System.Data.SqlClient;
using System.Data;
using Repository;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using POMS.Entity;

namespace Repository.Masters
{
   public class CountryMasRepository : RepositoryBaseNew
    {
        const string _CountryInsert = "USP_COUNTRY_INSERT";
        const string _Country_Search = "USP_COUNTRY_SEARCH";
        const string Country_Edit = "USP_COUNTRY_EDIT";
        public string CountryInsert(CountryMaster Obj)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter CountrySno = new SqlParameter("@CountrySno", Obj.CountrySno);
            CountrySno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(CountrySno);

            SqlParameter CountryName = new SqlParameter("@CountryName", Obj.CountryName);
            CountryName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(CountryName);

            SqlParameter CountryCode = new SqlParameter("@CountryCode", Obj.CountryCode);
            CountryCode.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(CountryCode);

            SqlParameter ActionName = new SqlParameter("@ActionName", Obj.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(ActionName);

            SqlParameter IPNumber = new SqlParameter("@IPNumber", Obj.IPNumber);
            IPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(IPNumber);


            SqlParameter CreOpr = new SqlParameter("@Creopr", Obj.CreOpr);
            CreOpr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(CreOpr);

            SqlParameter Sts = new SqlParameter("@Sts", Obj.Sts);
            Sts.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(Sts);

            DataSet ds = MasterExecuteCommand(_CountryInsert, sqlParameters);
            string Result = ds.Tables[0].Rows[0][0].ToString();
            return Result;
        }
        public Tuple<List<CountryMaster>, int> CountrySearch(PageRequest pageRequest)
        {
            List<CountryMaster> objCountry = new List<CountryMaster>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@UserSno", pageRequest.UserSno));
                    parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                    parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                    parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                    parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                    parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                    parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    parameters.Add(new SqlParameter("@TrnType", pageRequest.TrnType));
                    DataSet dataSet = MasterExecuteCommand(_Country_Search, parameters, ref recordCount);

                    objCountry = dataSet.Tables[0].ToCollection<CountryMaster>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<CountryMaster>, int>(objCountry, recordCount);
        }
        public List<CountryMaster> CountryEdit(int Sno)
        {
            List<CountryMaster> Country = new List<CountryMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CountrySno", Sno));
            DataSet dataSet = MasterExecuteCommand(Country_Edit, parameters);
            Country = dataSet.Tables[0].ToCustomList<CountryMaster>();
            return Country;
        }
    }
}
