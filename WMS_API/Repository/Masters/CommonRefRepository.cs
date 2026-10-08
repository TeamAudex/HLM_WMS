using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using POM.Repository;
using System.Data.SqlClient;
using System.Data;
using Librarys;
using Librarys.Extenders;

namespace POMS.Repository
{
    public class CommonRefRepository : RepositoryBaseNew
    {
        const string _Insert= "USP_COMMONREF_INSERT";
        
        public string ComRefInsert(CommonRef objcomref)
        {
            List<SqlParameter> objparms = new List<SqlParameter>();

            SqlParameter sqlRefID = new SqlParameter("@RefID", objcomref.RefID);
            sqlRefID.SqlDbType = SqlDbType.Int;
            objparms.Add(sqlRefID);

            SqlParameter sqlRefDesc = new SqlParameter("@RefDesc", objcomref.RefDesc);
            sqlRefDesc.SqlDbType = SqlDbType.NVarChar;
            objparms.Add(sqlRefDesc);

            SqlParameter sqlRefCode = new SqlParameter("@RefCode", objcomref.RefCode);
            sqlRefCode.SqlDbType = SqlDbType.NVarChar;
            objparms.Add(sqlRefCode);

            SqlParameter sqlCreopr = new SqlParameter("@Creopr", objcomref.Creopr);
            sqlCreopr.SqlDbType = SqlDbType.Int;
            objparms.Add(sqlCreopr);

            SqlParameter sqlCredatedDate = new SqlParameter("@CredatedDate", objcomref.CredatedDate);
            sqlCredatedDate.SqlDbType = SqlDbType.DateTime;
            objparms.Add(sqlCredatedDate);

            SqlParameter sqlIpNumber = new SqlParameter("@IpNumber", objcomref.IpNumber);
            sqlIpNumber.SqlDbType = SqlDbType.NVarChar;
            objparms.Add(sqlIpNumber);

            SqlParameter sqlSts = new SqlParameter("@Sts", objcomref.Sts);
            sqlSts.SqlDbType = SqlDbType.Bit;
            objparms.Add(sqlSts);

            DataSet DS = MasterExecuteCommand(_Insert, objparms);
            string obj = DS.Tables[0].Rows[0][0].ToString();
            return obj;

        }
        const string _Edit = "USP_COMMONREF_EDIT";
        public List<CommonRef> ComRefEdit(int RefID)
        {
            List<CommonRef> obj = new List<CommonRef>();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            SqlParameter sqlRefID = new SqlParameter("@RefID", RefID);
            sqlRefID.SqlDbType = SqlDbType.Int;
            sqlparams.Add(sqlRefID);
            DataSet DS = MasterExecuteCommand(_Edit, sqlparams);
            obj = DS.Tables[0].ToCollection<CommonRef>();
            return obj;
        }

        const string _Search = "USP_COMMONREF_SEARCH";

        public Tuple<List<CommonRef>, int> ComRefSearch(PageRequest pageRequest)
        {
            List<CommonRef> objRole = new List<CommonRef>();
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
                    DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);

                    objRole = dataSet.Tables[0].ToCollection<CommonRef>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<CommonRef>, int>(objRole, recordCount);
        }
    }
}
