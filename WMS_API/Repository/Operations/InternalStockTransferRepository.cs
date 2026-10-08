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
    public class InternalStockTransferRepository: RepositoryBaseNew
    {

        string ISTConfirmURL = System.Configuration.ConfigurationManager.ConnectionStrings["ISTConfirmURL"].ConnectionString;
        string ReqResLogPath = System.Configuration.ConfigurationManager.ConnectionStrings["ReqResLog"].ConnectionString.ToString();
        string SAPusername = System.Configuration.ConfigurationManager.ConnectionStrings["SAPusername"].ConnectionString;
        string SAPpassword = System.Configuration.ConfigurationManager.ConnectionStrings["SAPpassword"].ConnectionString;


        const string _Insert = "USP_IST_INSERT";
        const string _Edit = "USP_IST_EDIT";
        const string _Search = "USP_IST_SEARCH";
        const string _PostingInsert = "USP_IST_POSTING_INSERT";
        const string _PostingSearch = "USP_IST_POSTING_SEARCH";
        const string _PostingEdit = "USP_IST_POSTING_EDIT";
        const string _PrintSearch = "GetStockTransferEmployee";
        const string _SplittingSearch = "USP_IST_SPLITTING_SEARCH";
        const string _SplittingEdit = "USP_IST_SPLITTING_EDIT";
        const string _SplittingInsert = "USP_IST_SPLITTING_INSERT";
        const string _Print = "StockTransferReport";
        const string _ISTConfirmation = "GetISTConfirmation";
        const string _ISTConfInsert = "InsertISTConfirmation";
        const string _ISTConfErrorInsert = "InsertErrorISTConfirmation";
        public ISTResponse Insert(ISTList objISTList)
        {
            ISTResponse objResp = new ISTResponse();


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
            objISTDetails.Value = objISTList.objISTDet.ToDataTable<InternalStockTransferDet>();
            objISTDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objISTDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);


            //string result = string.Empty;


            //result = ds.Tables[0].Rows[0][0].ToString();

            objResp = ds.Tables[0].ToCustomList<ISTResponse>().FirstOrDefault();


            return objResp;


        }

        public ISTList Edit(int ISTSno)
        {
            ISTList objISTList = new ISTList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@ISTSno", ISTSno));

            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            objISTList.objIST = ds.Tables[0].ToCustomList<InternalStockTransfer>().FirstOrDefault();
            objISTList.objISTDet = ds.Tables[1].ToCustomList<InternalStockTransferDet>();
            return objISTList;
        }

        public Tuple<List<InternalStockTransfer>, int> Search(PageRequest pageRequest)
        {
            List<InternalStockTransfer> SearchList = new List<InternalStockTransfer>();
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
                SearchList = dataSet.Tables[0].ToCollection<InternalStockTransfer>();
            }
            return new Tuple<List<InternalStockTransfer>, int>(SearchList, recordCount);

        }

        public Tuple<List<IST>, int> PostingSearch(PageRequest pageRequest)
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
                DataSet dataSet = MasterExecuteCommand(_PostingSearch, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                SearchList = dataSet.Tables[0].ToCollection<IST>();
            }
            return new Tuple<List<IST>, int>(SearchList, recordCount);

        }

        public Tuple<List<IST>, int> SplittingSearch(PageRequest pageRequest)
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
                DataSet dataSet = MasterExecuteCommand(_SplittingSearch, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                SearchList = dataSet.Tables[0].ToCollection<IST>();
            }
            return new Tuple<List<IST>, int>(SearchList, recordCount);

        }

        public STList PostingEdit(int ISTSno)
        {
            STList objISTList = new STList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@ISTSno", ISTSno));

            DataSet ds = MasterExecuteCommand(_PostingEdit, Sqlparams);
            objISTList.objIST = ds.Tables[0].ToCustomList<IST>().FirstOrDefault();
            objISTList.objISTDet = ds.Tables[1].ToCustomList<ISTDet>();

            return objISTList;
        }

        public STList SplittingEdit(int ISTSno)
        {
            STList objISTList = new STList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@ISTSno", ISTSno));

            DataSet ds = MasterExecuteCommand(_SplittingEdit, Sqlparams);
            objISTList.objIST = ds.Tables[0].ToCustomList<IST>().FirstOrDefault();
            objISTList.objISTDet = ds.Tables[1].ToCustomList<ISTDet>();

            return objISTList;
        }

        public STResponse PostingInsert(STList objISTList)
        {
            STResponse objResp = new STResponse();


            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter ISTSno = new SqlParameter("@ISTSno", objISTList.objIST.InternalStockTransferSno);
            ISTSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(ISTSno);

            SqlParameter TransferDate = new SqlParameter("@TransferDate", objISTList.objIST.TransDate);
            TransferDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TransferDate);

            SqlParameter MovementTypeSno = new SqlParameter("@MovementTypeSno", objISTList.objIST.MovementTypeSno);
            MovementTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(MovementTypeSno);


            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objISTList.objIST.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

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

            DataSet ds = MasterExecuteCommand(_PostingInsert, sqlParameters);
            objResp = ds.Tables[0].ToCustomList<STResponse>().FirstOrDefault();


            return objResp;


        }

        public STResponse SplittingInsert(STList objISTList)
        {
            STResponse objResp = new STResponse();


            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter ISTSno = new SqlParameter("@ISTSno", objISTList.objIST.InternalStockTransferSno);
            ISTSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(ISTSno);

            SqlParameter objISTDetails = new SqlParameter();
            objISTDetails.ParameterName = "@ISTDetails";
            objISTDetails.SqlDbType = SqlDbType.Structured;
            objISTDetails.Value = objISTList.objISTDet.ToDataTable<ISTDet>();
            objISTDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objISTDetails);

            DataSet ds = MasterExecuteCommand(_SplittingInsert, sqlParameters);
            objResp = ds.Tables[0].ToCustomList<STResponse>().FirstOrDefault();


            return objResp;


        }

        public DataTable PrintSearch(int StockTransferSno)
        {
            DataTable dt = new DataTable();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@StockTransferSno", StockTransferSno));
            DataSet ds = MasterExecuteCommand(_PrintSearch, Sqlparams);
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable STPrintSearch(int StockTransferSno,int cnt)
        {
            DataTable dt = new DataTable();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@StockTransferSno", StockTransferSno));
            Sqlparams.Add(new SqlParameter("@Cnt", cnt));
            DataSet ds = MasterExecuteCommand(_PrintSearch, Sqlparams);
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable Print(int StockTransferSno, int EmployeeSno)
        {
            DataTable dt = new DataTable();

            List<SqlParameter> objSqlparameters = new List<SqlParameter>();

            SqlParameter ParamStockTransferSno = new SqlParameter("@StockTransferSno", StockTransferSno);
            ParamStockTransferSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(ParamStockTransferSno);

            SqlParameter ParamEmployeeSno = new SqlParameter("@EmployeeSno", EmployeeSno);
            ParamEmployeeSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(ParamEmployeeSno);



            try
            {
                DataSet ds = ExecuteCommand(_Print, objSqlparameters);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public ISTConfirmRespDetails ISTConfirmation(int ISTSno, string PostingLogFile)
        {

            RequestResponseLog ObjResLog = new RequestResponseLog();
            ISTConfirmation objISTConfirmation = new ISTConfirmation();
            objISTConfirmation.MatCreate = new List<ISTMatCreate>();
            ISTConfirmRespDetails objResp = new ISTConfirmRespDetails();
            string Response = string.Empty;
         


                DataTable dt = new DataTable();

                string URL = ISTConfirmURL+ "?ISTSno=" + ISTSno+ "&PostingLogFile="+ PostingLogFile;



                string VerbType = "GET", ContentType = "application/json";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpWebResponse response;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
               

               
                string responseFromServer = string.Empty;
                request.ContentType = ContentType;
                request.Method = VerbType;
                //  request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36";
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.ServicePoint.ConnectionLimit = 1;
                request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = new byte[20000];
                try
                {
            

                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        System.IO.Stream dataStream = response.GetResponseStream();
                        System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
                        responseFromServer = reader.ReadToEnd();
                        Response = responseFromServer;
                    

                        objResp = JsonConvert.DeserializeObject<ISTConfirmRespDetails>(responseFromServer);

                     





                    }

                }
                catch (WebException ex)
                {

                    objResp.Result = (ex.Message).ToString();
                

                }




          




            return objResp;
        }
    }
}
