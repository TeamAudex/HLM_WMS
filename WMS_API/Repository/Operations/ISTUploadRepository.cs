using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using POMS.Entity;
using POMS.Entity.Masters;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using System.Data;
using Entity.Operations;
using System.IO;
using System.Net;
using System.Net.Security;
using POMS.Repository;
using Newtonsoft.Json;

namespace Repository.Operations
{
    public class ISTUploadRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_IST_UPLOAD_INSERT";
        public STResponse Insert(ISTUploadList objISTList)
        {
            STResponse objResp = new STResponse();


            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter ISTSno = new SqlParameter("@ISTSno", objISTList.objISTUpload.InternalStockTransferSno);
            ISTSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(ISTSno);

            SqlParameter TransferDate = new SqlParameter("@TransferDate", objISTList.objISTUpload.TransferDate);
            TransferDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TransferDate);


            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objISTList.objISTUpload.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

            SqlParameter MovementTypeSno = new SqlParameter("@MovementTypeSno", objISTList.objISTUpload.MovementTypeSno);
            MovementTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(MovementTypeSno);

            SqlParameter TypeofStockSno = new SqlParameter("@TypeofStockSno", objISTList.objISTUpload.TypeofStockSno);
            TypeofStockSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(TypeofStockSno);

            SqlParameter EmployeeSno = new SqlParameter("@EmployeeSno", objISTList.objISTUpload.EmployeeSno);
            EmployeeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(EmployeeSno);


            SqlParameter Remarks = new SqlParameter("@Remarks", objISTList.objISTUpload.Remarks);
            Remarks.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(Remarks);

            SqlParameter UploadFileName = new SqlParameter("@ExcelFileName", objISTList.objISTUpload.UploadFileName);
            UploadFileName.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(UploadFileName);

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objISTList.objISTUpload.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objISTList.objISTUpload.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);

            SqlParameter objISTDetails = new SqlParameter();
            objISTDetails.ParameterName = "@ISTUploadDetails";
            objISTDetails.SqlDbType = SqlDbType.Structured;
            objISTDetails.Value = objISTList.objISTUploadDetails.ToDataTable<ISTUploadDetails>();
            objISTDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objISTDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);


            //string result = string.Empty;


            //result = ds.Tables[0].Rows[0][0].ToString();

            objResp = ds.Tables[0].ToCustomList<STResponse>().FirstOrDefault();


            return objResp;


        }
    }
}
