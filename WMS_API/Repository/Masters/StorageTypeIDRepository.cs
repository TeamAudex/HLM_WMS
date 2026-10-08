using Entity.Masters;
using Librarys;
using Librarys.Extenders;
using POM.Repository;
using POMS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Masters
{
    public class StorageTypeIDRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_StorageTypeID_Insert";
        const string _Search = "USP_StorageTypeID_Search";
        const string _Edit = "USP_StorageTypeID_Edit";

        public StorageTypeIDResult Insert(StorageTypeIDList objStorageTypeIDList)
        {
            StorageTypeIDResult ObjResult = new StorageTypeIDResult();
            List<SqlParameter> parameter = new List<SqlParameter>();

            SqlParameter paramStorageTypeIDSno = new SqlParameter("@StorageTypeIDSno", objStorageTypeIDList.StorageTypeID.StorageTypeIDSno);
            paramStorageTypeIDSno.SqlDbType = SqlDbType.Int;
            parameter.Add(paramStorageTypeIDSno);

            SqlParameter paramWarehouseSno = new SqlParameter("@WarehouseSno", objStorageTypeIDList.StorageTypeID.WarehouseSno);
            paramWarehouseSno.SqlDbType = SqlDbType.Int;
            parameter.Add(paramWarehouseSno);

            SqlParameter paramStorageTypeSno = new SqlParameter("@StorageTypeSno", objStorageTypeIDList.StorageTypeID.StorageTypeSno);
            paramStorageTypeSno.SqlDbType = SqlDbType.Int;
            parameter.Add(paramStorageTypeSno);
            
            SqlParameter paramFileUpload = new SqlParameter("@FileUpload", objStorageTypeIDList.StorageTypeID.FileUpload);
            paramFileUpload.SqlDbType = SqlDbType.VarChar;
            parameter.Add(paramFileUpload);
            
            SqlParameter paraCreOpr = new SqlParameter("@CreOpr", objStorageTypeIDList.StorageTypeID.CreOpr);
            paraCreOpr.SqlDbType = SqlDbType.Int;
            parameter.Add(paraCreOpr);

            SqlParameter paramsIPNumber = new SqlParameter("@IPNumber", objStorageTypeIDList.StorageTypeID.IPNumber);
            paramsIPNumber.SqlDbType = SqlDbType.VarChar;
            parameter.Add(paramsIPNumber);

            SqlParameter paraActionName = new SqlParameter("@ActionName", objStorageTypeIDList.StorageTypeID.ActionName);
            paraActionName.SqlDbType = SqlDbType.VarChar;
            parameter.Add(paraActionName);

            SqlParameter paramsSts = new SqlParameter("@Sts", objStorageTypeIDList.StorageTypeID.Sts);
            paramsSts.SqlDbType = SqlDbType.Bit;
            parameter.Add(paramsSts);

            SqlParameter paraStorageIDType = new SqlParameter("@StorageIDType", objStorageTypeIDList.StorageTypeID.StorageIDType);
            paraStorageIDType.SqlDbType = SqlDbType.VarChar;
            parameter.Add(paraStorageIDType);

            SqlParameter paraPrefix = new SqlParameter("@Prefix", objStorageTypeIDList.StorageTypeID.Prefix);
            paraPrefix.SqlDbType = SqlDbType.VarChar;
            parameter.Add(paraPrefix);

            SqlParameter paraSuffix = new SqlParameter("@Suffix", objStorageTypeIDList.StorageTypeID.Suffix);
            paraSuffix.SqlDbType = SqlDbType.VarChar;
            parameter.Add(paraSuffix);

            SqlParameter paraStartPalletIDNo = new SqlParameter("@StartPalletIDNo", objStorageTypeIDList.StorageTypeID.StartPalletIDNo);
            paraStartPalletIDNo.SqlDbType = SqlDbType.Int;
            parameter.Add(paraStartPalletIDNo);

            SqlParameter paraEndPalletIDNo = new SqlParameter("@EndPalletIDNo", objStorageTypeIDList.StorageTypeID.EndPalletIDNo);
            paraEndPalletIDNo.SqlDbType = SqlDbType.Int;
            parameter.Add(paraEndPalletIDNo);

            SqlParameter paraNoofUnits = new SqlParameter("@NoofUnits", objStorageTypeIDList.StorageTypeID.NoofUnits);
            paraNoofUnits.SqlDbType = SqlDbType.Int;
            parameter.Add(paraNoofUnits);

            DataTable objDet = new DataTable();
            objDet.Columns.Add("StorageTypeIDDetSno");
            objDet.Columns.Add("StorageTypeIDSno");
            objDet.Columns.Add("StorageIDSno");
            objDet.Columns.Add("StorageID");
            objDet.Columns.Add("Sts");

            foreach (StorageTypeIDDet obj in objStorageTypeIDList.StorageTypeIDDet)
            {
                objDet.Rows.Add(obj.StorageTypeIDDetSno, obj.StorageTypeIDSno, obj.StorageIDSno, obj.StorageID, obj.Sts);
            }

            SqlParameter objSqlParamForType_1 = new SqlParameter();
            objSqlParamForType_1.ParameterName = "@StorageTypeIDDet";
            objSqlParamForType_1.SqlDbType = SqlDbType.Structured;
            objSqlParamForType_1.Value = objDet;
            objSqlParamForType_1.Direction = ParameterDirection.Input;
            parameter.Add(objSqlParamForType_1);

            try
            {
                DataSet ds = ExecuteCommand(_Insert, parameter);
                ObjResult.Result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return ObjResult;
        }

        public Tuple<List<StorageTypeIDSearch>, int> Search(PageRequest pageRequest)
        {
            List<StorageTypeIDSearch> objStorageTypeID = new List<StorageTypeIDSearch>();
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
                    parameters.Add(new SqlParameter("@TrnType", pageRequest.TrnType));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);

                    objStorageTypeID = dataSet.Tables[0].ToCollection<StorageTypeIDSearch>();
                }
                catch (Exception ex) { }
            }
            return new Tuple<List<StorageTypeIDSearch>, int>(objStorageTypeID, recordCount);
        }

        public StorageTypeIDList Edit(int StorageTypeIDSno)
        {
            StorageTypeIDList objStorageTypeIDList = new StorageTypeIDList();
            List<SqlParameter> objparams = new List<SqlParameter>();

            SqlParameter paramStorageTypeIDSno = new SqlParameter("@StorageTypeIDSno", StorageTypeIDSno);
            paramStorageTypeIDSno.SqlDbType = SqlDbType.Int;
            objparams.Add(paramStorageTypeIDSno);

            try
            {
                DataSet ds = MasterExecuteCommand(_Edit, objparams);
                objStorageTypeIDList.StorageTypeID = ds.Tables[0].ToCollection<StorageTypeID>().FirstOrDefault();
                objStorageTypeIDList.StorageTypeIDDet = ds.Tables[1].ToCustomList<StorageTypeIDDet>();
            }
            catch(Exception ex)
            {

            }
            return objStorageTypeIDList;
        }
    }
}
