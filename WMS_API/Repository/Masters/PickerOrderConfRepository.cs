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
    public class PickerOrderConfRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_PickerOrderConf_Insert";
        const string _Search = "USP_PickerOrderConf_Search";
        const string _Edit = "USP_PickerOrderConf_Edit";
        const string _Fetch = "USP_PickerOrderConf_Fetch";
        public string Insert(PickerOrderConf ObjPickerOrderConf)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            string Result = "";
            SqlParameter paramPickerordercountsno = new SqlParameter("@Pickerordercountsno", ObjPickerOrderConf.Pickerordercountsno);
            paramPickerordercountsno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramPickerordercountsno);

            SqlParameter paramWarehouseSno = new SqlParameter("@WarehouseSno", ObjPickerOrderConf.WarehouseSno);
            paramWarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramWarehouseSno);

            SqlParameter paramPickerCount = new SqlParameter("@PickerCount", ObjPickerOrderConf.PickerCount);
            paramPickerCount.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramPickerCount);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", ObjPickerOrderConf.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(objCreOpr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", ObjPickerOrderConf.IpNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", ObjPickerOrderConf.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ActionName);

            SqlParameter ReqLog = new SqlParameter("@ReqLog", ObjPickerOrderConf.ReqLog);
            ReqLog.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ReqLog);

            SqlParameter objsts = new SqlParameter("@Sts", ObjPickerOrderConf.Sts);
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
        public Tuple<List<PickerOrderConf>, int> Search(PageRequest pageRequest)
        {
            List<PickerOrderConf> objRole = new List<PickerOrderConf>();
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

                    objRole = dataSet.Tables[0].ToCollection<PickerOrderConf>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<PickerOrderConf>, int>(objRole, recordCount);
        }
        public PickerOrderConf Edit(int Pickerordercountsno)
        {
            PickerOrderConf PickerOrderEdit = new PickerOrderConf();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Pickerordercountsno", Pickerordercountsno));
            DataSet dataSet = MasterExecuteCommand(_Edit, parameters);
            PickerOrderEdit = dataSet.Tables[0].ToCollection<PickerOrderConf>().FirstOrDefault();
            return PickerOrderEdit;
        }
        public PickerOrderConf Fetch(int WarehouseSno)
        {
            PickerOrderConf Fetch = new PickerOrderConf();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@WarehouseSno", WarehouseSno));
            DataSet dataSet = MasterExecuteCommand(_Fetch, parameters);
            Fetch = dataSet.Tables[0].ToCollection<PickerOrderConf>().FirstOrDefault();
            return Fetch;
        }

    }

    }

