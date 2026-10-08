using System;
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

namespace POMS.Repository.Masters
{
    public class CommonMasterRepository : RepositoryBaseNew
    {
        const string _CommonMaster_Insert = "USP_INSERT_COMMON_MASTER";
        const string _CommonMaster_Search = "USP_GET_COMMON_MASTER";
        const string CommonMaster_Edit = "USP_GET_COMMON_MASTER_DET";
        public string InsertCommonMaster(CommonMaster objCommonMaster)
        {            
            
            List<SqlParameter> listObjSqlParameter = new List<SqlParameter>();

            SqlParameter objSqlParameterCOMMONSNO = new SqlParameter("@COMMONSNO", objCommonMaster.COMMONSNO);
            objSqlParameterCOMMONSNO.SqlDbType = SqlDbType.Int;
            //objSqlParameter.Direction=ParameterDirection.InputOutput()
            listObjSqlParameter.Add(objSqlParameterCOMMONSNO);

            SqlParameter objSqlParameterRefID = new SqlParameter("@RefID", objCommonMaster.RefID);
            objSqlParameterRefID.SqlDbType = SqlDbType.Int;
            listObjSqlParameter.Add(objSqlParameterRefID);

            SqlParameter objSqlParameterCOMDESC = new SqlParameter("@COMDESC",objCommonMaster.COMDESC);
            objSqlParameterCOMDESC.SqlDbType = SqlDbType.NVarChar;
            listObjSqlParameter.Add(objSqlParameterCOMDESC);

            SqlParameter objSqlParameterCodeValue = new SqlParameter("@CodeValue", objCommonMaster.CodeVal);
            objSqlParameterCodeValue.SqlDbType = SqlDbType.Float;
            listObjSqlParameter.Add(objSqlParameterCodeValue);

            SqlParameter objSqlParameterCodeFlag = new SqlParameter("@CodeFlag", objCommonMaster.CodeFlag);
            objSqlParameterCodeFlag.SqlDbType = SqlDbType.NVarChar;
            listObjSqlParameter.Add(objSqlParameterCodeFlag);

            SqlParameter objSqlParameterSts = new SqlParameter("@Sts", objCommonMaster.Sts);
            objSqlParameterSts.SqlDbType = SqlDbType.Bit;
            listObjSqlParameter.Add(objSqlParameterSts);

            DataSet ds = MasterExecuteCommand(_CommonMaster_Insert, listObjSqlParameter);
            string result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public List<CommonMaster> CommonMasterType(string TypeText)
        {
            const string _get_Branch_autocomplete = "Usp_Get_CommonMaster_Type";
            List<CommonMaster> bra = new List<CommonMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TypeText", TypeText));
            DataSet dataSet = MasterExecuteCommand(_get_Branch_autocomplete, parameters);
            DataTable dtBranch = new DataTable();
            bra = dataSet.Tables[0].ToCollection<CommonMaster>();
            return bra;
        }
        //public List<CommonMaster> CommonMaster_Search(PageRequest pageRequest)
        //{
        //    List<CommonMaster> objCommonMaster = new List<CommonMaster>();
        //    int recordCount = 0;
        //    if (pageRequest != null)
        //    {
        //        List<SqlParameter> parameters = new List<SqlParameter>();
        //        parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
        //        parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
        //        parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
        //        parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
        //        parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
        //        parameters.Add(new SqlParameter("@Query", pageRequest.Query));
        //        parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
        //        DataSet dataSet = MasterExecuteCommand(_CommonMaster_Search, parameters, ref recordCount);
        //        DataRowCollection rows = dataSet.Tables[0].Rows;
        //        objCommonMaster = dataSet.Tables[0].ToCollection<CommonMaster>();
        //    }
        //    return objCommonMaster;
        //}

        public Tuple<List<CommonMaster>, int> CommonMaster_Search(PageRequest pageRequest)
        {
            List<CommonMaster> objRole = new List<CommonMaster>();
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
                    DataSet dataSet = MasterExecuteCommand(_CommonMaster_Search, parameters, ref recordCount);

                    objRole = dataSet.Tables[0].ToCollection<CommonMaster>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<CommonMaster>, int>(objRole, recordCount);
        }
        public List<CommonMaster> CommonMasterEdit(int COMMONSNO)
        {
            List<CommonMaster> Country = new List<CommonMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CommonSno", COMMONSNO));
            DataSet dataSet = MasterExecuteCommand(CommonMaster_Edit, parameters);
            Country = dataSet.Tables[0].ToCustomList<CommonMaster>();
            return Country;
        }
    }
}
