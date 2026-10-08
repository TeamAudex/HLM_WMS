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
   public class UpdateExpiryDateRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_UpdateExpiryDate_Insert";
        const string _Search = "USP_UpdateExpiryDate_Search";

        public string Insert(UpdateExpiryDate ObjUpdateExpiryDate)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            string Result = "";
            SqlParameter paramUpdateExpiryDateSno = new SqlParameter("@UpdateExpiryDateSno", ObjUpdateExpiryDate.UpdateExpiryDateSno);
            paramUpdateExpiryDateSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramUpdateExpiryDateSno);

            SqlParameter paramWarehouseSno = new SqlParameter("@WarehouseSno", ObjUpdateExpiryDate.WarehouseSno);
            paramWarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramWarehouseSno);

            SqlParameter paraEntryDat = new SqlParameter("@EntryDat", ObjUpdateExpiryDate.EntryDat);
            paraEntryDat.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paraEntryDat);

            SqlParameter paramitembatchNoSno = new SqlParameter("@itembatchNoSno", ObjUpdateExpiryDate.itembatchNoSno);
            paramitembatchNoSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramitembatchNoSno);

            SqlParameter parambatchNo = new SqlParameter("@batchNo", ObjUpdateExpiryDate.batchNo);
            parambatchNo.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(parambatchNo);

            SqlParameter paraExpiryDate = new SqlParameter("@ExpiryDate", ObjUpdateExpiryDate.ExpiryDate);
            paraExpiryDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paraExpiryDate);

            SqlParameter paraNewExpiryDate = new SqlParameter("@NewExpiryDate", ObjUpdateExpiryDate.NewExpiryDate);
            paraNewExpiryDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paraNewExpiryDate);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", ObjUpdateExpiryDate.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(objCreOpr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", ObjUpdateExpiryDate.IpNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", ObjUpdateExpiryDate.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ActionName);

            SqlParameter ReqLog = new SqlParameter("@ReqLog", ObjUpdateExpiryDate.ReqLog);
            ReqLog.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ReqLog);

            SqlParameter objsts = new SqlParameter("@Sts", ObjUpdateExpiryDate.Sts);
            objsts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(objsts);

            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);
                Result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

            }
            return Result;
        }

        public Tuple<List<UpdateExpiryDate>, int> Search(PageRequest pageRequest)
        {
            List<UpdateExpiryDate> objRole = new List<UpdateExpiryDate>();
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
                    parameters.Add(new SqlParameter("@UserSno", pageRequest.UserSno));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);

                    objRole = dataSet.Tables[0].ToCollection<UpdateExpiryDate>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<UpdateExpiryDate>, int>(objRole, recordCount);
        }

       
    }
}
