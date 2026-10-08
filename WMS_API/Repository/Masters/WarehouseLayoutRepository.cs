using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Librarys.Extenders;
using Librarys;
using Entity;
using POM.Repository;
using POMS.Entity;

namespace Repository
{
    public class WarehouseLayoutRepository : RepositoryBaseNew
    {

        const string _Insert = "USP_WarehouseLayout_Insert";
        public WarehouseLayoutResult Insert(WarehouseLayoutDetList objWarehouseLayoutDetList)
        {
            WarehouseLayoutResult ObjResult = new WarehouseLayoutResult();
            List<SqlParameter> objParams = new List<SqlParameter>();


            SqlParameter paraWarehouseLayoutSno = new SqlParameter("@WarehouseLayoutSno", objWarehouseLayoutDetList.objWarehouseLayout.WarehouseLayoutSno);
            paraWarehouseLayoutSno.SqlDbType = SqlDbType.Int;
            objParams.Add(paraWarehouseLayoutSno);

            SqlParameter objWarehouseSno = new SqlParameter("@WarehouseSno", objWarehouseLayoutDetList.objWarehouseLayout.WarehouseSno);
            objWarehouseSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objWarehouseSno);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", objWarehouseLayoutDetList.objWarehouseLayout.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(objCreOpr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objWarehouseLayoutDetList.objWarehouseLayout.IpNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objWarehouseLayoutDetList.objWarehouseLayout.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ActionName);

            SqlParameter ReqLog = new SqlParameter("@ReqLog", objWarehouseLayoutDetList.objWarehouseLayout.ReqLog);
            ReqLog.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ReqLog);

            SqlParameter objsts = new SqlParameter("@Sts", objWarehouseLayoutDetList.objWarehouseLayout.Sts);
            objsts.SqlDbType = SqlDbType.Bit;
            objParams.Add(objsts);

            DataTable ArrWarehouseLayoutRow = new DataTable();

            ArrWarehouseLayoutRow.Columns.Add("WH_Row_Sno");
            ArrWarehouseLayoutRow.Columns.Add("WarehouseSno");
            ArrWarehouseLayoutRow.Columns.Add("Rows");
            ArrWarehouseLayoutRow.Columns.Add("Bay");
            ArrWarehouseLayoutRow.Columns.Add("RackLevel");
            ArrWarehouseLayoutRow.Columns.Add("Sts");

            foreach (WarehouseLayoutDetOne objDet in objWarehouseLayoutDetList.ObjWarehouseLayoutDetOne)
            {
                ArrWarehouseLayoutRow.Rows.Add(objDet.WH_ROW_SNO, objDet.WarehouseSno, objDet.Rows, objDet.Bay, objDet.RackLevels, objDet.Sts);
            }

            SqlParameter WhLayoutRow = new SqlParameter();
            WhLayoutRow.ParameterName = "@WarehouseLayoutRow";
            WhLayoutRow.SqlDbType = SqlDbType.Structured;
            WhLayoutRow.Value = ArrWarehouseLayoutRow;
            WhLayoutRow.Direction = ParameterDirection.Input;
            objParams.Add(WhLayoutRow);

            DataTable ArrWarehouseLayoutColumn = new DataTable();

            ArrWarehouseLayoutColumn.Columns.Add("WH_Column_Sno");
            ArrWarehouseLayoutColumn.Columns.Add("WH_Row_Sno");
            ArrWarehouseLayoutColumn.Columns.Add("WarehouseSno");
            ArrWarehouseLayoutColumn.Columns.Add("Columns");
            ArrWarehouseLayoutColumn.Columns.Add("Aisle");
            ArrWarehouseLayoutColumn.Columns.Add("Rows");
            ArrWarehouseLayoutColumn.Columns.Add("Sts");

            foreach (WarehouseLayoutDetOne objDet in objWarehouseLayoutDetList.ObjWarehouseLayoutDetOne)
            {
                foreach (WarehouseLayoutDetTwo ObjDetColumn in objDet.WarehouseLayoutDetColumns)
                {
                    ArrWarehouseLayoutColumn.Rows.Add(ObjDetColumn.WH_COLUMN_SNO, ObjDetColumn.WH_ROW_SNO, ObjDetColumn.WarehouseSno, ObjDetColumn.Columns, ObjDetColumn.Aisle, objDet.Rows, ObjDetColumn.Sts);
                }
            }

            SqlParameter WhLayoutcol = new SqlParameter();
            WhLayoutcol.ParameterName = "@WarehouseLayoutColumn";
            WhLayoutcol.SqlDbType = SqlDbType.Structured;
            WhLayoutcol.Value = ArrWarehouseLayoutColumn;
            WhLayoutcol.Direction = ParameterDirection.Input;
            objParams.Add(WhLayoutcol);

            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, objParams);
                ObjResult = ds.Tables[0].ToCustomList<WarehouseLayoutResult>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return ObjResult;

        }

        const string _Search = "USP_WarehouseLayout_Search";

        public Tuple<List<WarehouseLayout>, int> Search(PageRequest pageRequest)
        {
            List<WarehouseLayout> SearchList = new List<WarehouseLayout>();
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
                SearchList = dataSet.Tables[0].ToCollection<WarehouseLayout>();
            }
            return new Tuple<List<WarehouseLayout>, int>(SearchList, recordCount);

        }

        const string _Edit = "USP_WarehouseLayout_Edit";
        public WarehouseLayoutDetList Edit(int WarehouseLayoutSno)
        {
            SqlParameter paramActionID = new SqlParameter("@WarehouseLayoutSno", WarehouseLayoutSno);
            SqlCommand sqlCmd = new SqlCommand(_Edit);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            WarehouseLayoutDetList objWarehouseLayoutMaster = new WarehouseLayoutDetList();

            objWarehouseLayoutMaster.objWarehouseLayout = new WarehouseLayout();
            objWarehouseLayoutMaster.ObjWarehouseLayoutDetOne = new List<WarehouseLayoutDetOne>();
            objWarehouseLayoutMaster.ObjWarehouseLayoutDetTwo = new List<WarehouseLayoutDetTwo>();


            DataSet ds = new DataSet();
            DataTable ArrWarehouseLayout = new DataTable();
            DataTable ArrWarehouseLayoutRow = new DataTable();
            DataTable ArrWarehouseLayoutColumn = new DataTable();

            ds.Tables.Add(ArrWarehouseLayout);
            ds.Tables.Add(ArrWarehouseLayoutRow);
            ds.Tables.Add(ArrWarehouseLayoutColumn);

            try
            {
                ds.Load(dataReader, LoadOption.OverwriteChanges, ArrWarehouseLayout, ArrWarehouseLayoutRow, ArrWarehouseLayoutColumn);
                objWarehouseLayoutMaster.objWarehouseLayout = ds.Tables[0].ToCustomList<WarehouseLayout>().FirstOrDefault();
                objWarehouseLayoutMaster.ObjWarehouseLayoutDetOne = ds.Tables[1].ToCollection<WarehouseLayoutDetOne>();

                List<WarehouseLayoutDetTwo> ArrColumns = new List<WarehouseLayoutDetTwo>();
                ArrColumns = ds.Tables[2].ToCollection<WarehouseLayoutDetTwo>();

                if (ArrColumns.Count > 0)
                {
                    foreach (WarehouseLayoutDetOne objDet in objWarehouseLayoutMaster.ObjWarehouseLayoutDetOne)
                    {
                        objDet.WarehouseLayoutDetColumns = ArrColumns.Where(P => P.WH_ROW_SNO == objDet.WH_ROW_SNO).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return objWarehouseLayoutMaster;
        }
    }
}