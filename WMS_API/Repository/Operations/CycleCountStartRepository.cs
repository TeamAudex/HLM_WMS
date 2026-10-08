using Entity.Operations;
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

namespace Repository.Operations
{
   public class CycleCountStartRepository : RepositoryBaseNew
    {
        const string _StartDate = "USP_CCStartDate";
        const string _Search = "USP_SEARCH_CCPhysical";
        const string _Insert = "USP_Insert_CCPhysical";
        const string _Edit = "USP_CycleCount_Edit";
        const string _PDF = "USP_CCPHYSICAL_PDF";
        public string Insert(CycleCountStart objItemPriceList)
        {
            List<SqlParameter> SQLparameter = new List<SqlParameter>();

            SqlParameter CreOpr = new SqlParameter("@Creopr", objItemPriceList.Creopr);
            CreOpr.SqlDbType = SqlDbType.Int;
            SQLparameter.Add(CreOpr);

            SqlParameter CCphysicalSno = new SqlParameter("@CCphysicalSno", objItemPriceList.CCphysicalSno);
            CCphysicalSno.SqlDbType = SqlDbType.Int;
            SQLparameter.Add(CCphysicalSno);

            SqlParameter CycleCountSno = new SqlParameter("@CycleCountSno", objItemPriceList.CycleCountSno);
            CycleCountSno.SqlDbType = SqlDbType.Int;
            SQLparameter.Add(CycleCountSno);

            SqlParameter IPNumber = new SqlParameter("@IPNumber", objItemPriceList.IPNumber);
            IPNumber.SqlDbType = SqlDbType.NVarChar;
            SQLparameter.Add(IPNumber);

            //SqlParameter ownershipsno = new SqlParameter("@ownershipsno", objItemPriceList.ownershipsno);
            //ownershipsno.SqlDbType = SqlDbType.NVarChar;
            //SQLparameter.Add(ownershipsno);

            SqlParameter DocumentFilename = new SqlParameter("@DocumentFilename", objItemPriceList.DocumentFilename);
            DocumentFilename.SqlDbType = SqlDbType.NVarChar;
            SQLparameter.Add(DocumentFilename);

            DataTable objDet = new DataTable();
            objDet.Columns.Add("SubZoneSno");
            objDet.Columns.Add("RackLocationSno");
            objDet.Columns.Add("PalletSno");
            objDet.Columns.Add("ItemNameSno");
            objDet.Columns.Add("PackageSno");
            objDet.Columns.Add("BatchNo");
            objDet.Columns.Add("Qty");
            objDet.Columns.Add("StorageLocationsno");

            foreach (CycleCountInsert obj in objItemPriceList.CycleCountInsert)
            {
                objDet.Rows.Add(obj.SubZoneSno, obj.RackLocationSno, obj.PalletSno, obj.ItemNameSno, obj.PackageSno, obj.BatchNo, obj.Qty, obj.StorageLocationsno);
            }

            SqlParameter SQLparameternDet = new SqlParameter();
            SQLparameternDet.ParameterName = "@UploadDetails";
            SQLparameternDet.SqlDbType = SqlDbType.Structured;
            SQLparameternDet.Value = objDet;
            SQLparameternDet.Direction = ParameterDirection.Input;
            SQLparameter.Add(SQLparameternDet);
          
            string Result1 = "";
            try
            {
                DataSet ds = ExecuteCommand(_Insert, SQLparameter);
                Result1 = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Result1 = ex.Message.ToString();
            }
            return Result1;
        }

       
        public string Edit(int CycleCountSno)
        {
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paramCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            paramCycleCountSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramCycleCountSno);

            DataSet ds = MasterExecuteCommand(_Edit, sqlparams);
            string Result = ds.Tables[0].Rows[0][0].ToString();

            return Result;
        }

        public string Edit1(int CycleCountSno)
        {
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paramCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            paramCycleCountSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramCycleCountSno);

            DataSet ds = MasterExecuteCommand(_Edit, sqlparams);
            string Result = ds.Tables[0].Rows[0][1].ToString();

            return Result;
        }
        public string StartDate(int CycleCountSno)
        {

            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paramCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            paramCycleCountSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramCycleCountSno);

            DataSet DS = MasterExecuteCommand(_StartDate, sqlparams);
            string result = DS.Tables[0].Rows[0][0].ToString();
            return result;
        }
      


        public List<CycleCountExcel> GetCycleExcel(int CycleCountSno)
        {
            List<CycleCountExcel> objRes = new List<CycleCountExcel>();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            SqlParameter ParmCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            ParmCycleCountSno.SqlDbType = SqlDbType.Int;
            Sqlparams.Add(ParmCycleCountSno);

            try
            {
                DataSet ds = MasterExecuteCommand("USP_CCPHYSICAL_EXCEL", Sqlparams);
               
                objRes = ds.Tables[1].ToCollection<CycleCountExcel>();
            }
            catch (Exception ex)
            {

            }
            return objRes;
        }

        public Tuple<List<CycleCountStart>, int> Search(PageRequest pageRequest)
        {
            List<CycleCountStart> objStorageTypeID = new List<CycleCountStart>();
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

                    objStorageTypeID = dataSet.Tables[0].ToCollection<CycleCountStart>();
                }
                catch (Exception ex) { }
            }
            return new Tuple<List<CycleCountStart>, int>(objStorageTypeID, recordCount);
        }


        public DataSet GetPDF(int CycleCountSno)
        {
            DataSet ds = new DataSet();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            SqlParameter ParmCycleCountSno = new SqlParameter("@CycleCountSno", CycleCountSno);
            ParmCycleCountSno.SqlDbType = SqlDbType.Int;
            Sqlparams.Add(ParmCycleCountSno);

            try
            {
                ds = MasterExecuteCommand(_PDF, Sqlparams);
    
            }
            catch (Exception ex)
            {

            }
            return ds;
        }


    }
}
