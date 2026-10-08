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
   public class ISTRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_ST_INSERT";
        const string _Edit = "USP_ST_EDIT";
        const string _Search = "USP_ST_SEARCH";
        const string _DropDown = "ISTDropdown";
        public List<MovementTypeDD> DropDown()
        {
            List<MovementTypeDD> objSTDD = new List<MovementTypeDD>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet dataSet = MasterExecuteCommand(_DropDown, parameters);
            DataTable dtBranch = new DataTable();
            objSTDD = dataSet.Tables[0].ToCollection<MovementTypeDD>();

            return objSTDD;
        }
        public STResponse Insert(STList objISTList)
        {
            STResponse objResp = new STResponse();


            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter ISTSno = new SqlParameter("@ISTSno", objISTList.objIST.InternalStockTransferSno);
            ISTSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(ISTSno);

            SqlParameter TransferDate = new SqlParameter("@TransferDate", objISTList.objIST.TransferDate);
            TransferDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TransferDate);


            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objISTList.objIST.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

            SqlParameter MovementTypeSno = new SqlParameter("@MovementTypeSno", objISTList.objIST.MovementTypeSno);
            MovementTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(MovementTypeSno);

            SqlParameter TypeofStockSno = new SqlParameter("@TypeofStockSno", objISTList.objIST.TypeofStockSno);
            TypeofStockSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(TypeofStockSno);

            SqlParameter EmployeeSno = new SqlParameter("@EmployeeSno", objISTList.objIST.EmployeeSno);
            EmployeeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(EmployeeSno);


            SqlParameter Remarks = new SqlParameter("@Remarks", objISTList.objIST.Remarks);
            Remarks.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(Remarks);

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objISTList.objIST.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objISTList.objIST.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);

            SqlParameter objISTDetails = new SqlParameter();
            objISTDetails.ParameterName = "@ISTDetails";
            objISTDetails.SqlDbType = SqlDbType.Structured;
            objISTDetails.Value = objISTList.objISTDet.ToDataTable<ISTDet>();
            objISTDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objISTDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);


            //string result = string.Empty;


            //result = ds.Tables[0].Rows[0][0].ToString();

            objResp = ds.Tables[0].ToCustomList<STResponse>().FirstOrDefault();


            return objResp;


        }

        public STList Edit(int ISTSno)
        {
            STList objISTList = new STList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@ISTSno", ISTSno));

            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            objISTList.objIST = ds.Tables[0].ToCustomList<IST>().FirstOrDefault();
            objISTList.objISTDet = ds.Tables[1].ToCustomList<ISTDet>();
            return objISTList;
        }

        public Tuple<List<IST>, int> Search(PageRequest pageRequest)
        {
            List<IST> SearchList = new List<IST>();
            int recordCount = 0;
            if (pageRequest != null)
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
                DataRowCollection rows = dataSet.Tables[0].Rows;
                SearchList = dataSet.Tables[0].ToCollection<IST>();
            }
            return new Tuple<List<IST>, int>(SearchList, recordCount);

        }
    }
}
