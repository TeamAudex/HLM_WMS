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

   public class PickListRepository : RepositoryBaseNew
    {

        string IssueOrderConfirmURL = System.Configuration.ConfigurationManager.ConnectionStrings["IssueOrderConfirmURL"].ConnectionString;
        string ReqResLogPath = System.Configuration.ConfigurationManager.ConnectionStrings["ReqResLog"].ConnectionString.ToString();
        string SAPusername = System.Configuration.ConfigurationManager.ConnectionStrings["SAPusername"].ConnectionString;
        string SAPpassword = System.Configuration.ConfigurationManager.ConnectionStrings["SAPpassword"].ConnectionString;


        const string _DropDown = "PickListDropdown";
        const string _Fetch = "FetchPickList";
        const string _Insert = "USP_PICKLIST_INSERT";
        const string _Search = "USP_PICKLIST_SEARCH";
        const string _Edit = "USP_PICKLIST_EDIT";
        const string _LoadData = "USP_PICKLIST_DASHBOARD";
        const string _LoadDash = "USP_PICKLIST_DASH";
        const string _PLConfirm = "USP_PLConfirm_DASH";
        const string _PLConfirmationFetch = "USP_PICKLIST_CONFIRMATION_FETCH";
        const string _PLConfirmFetch = "USP_PICKLIST_CONFIRM_FETCH";
        const string _PLConfirmInsert = "USP_PICKLIST_CONFIRM_INSERT";
        const string _PLConInsert = "USP_PL_CONFIRM_INSERT";
        const string _PLConfInsert = "USP_PL_CONF_INSERT";
        const string _PLCInsert = "USP_PICKLIST_CONFIRMATION_INSERT";
        const string _PrintSearch = "GetPickListEmployee";
        const string _Print = "PickListReport";
        const string _PLLocation = "USP_PLConfim_Location";
        public PickListDropDown DropDown()
        {
            PickListDropDown objPickListDD = new PickListDropDown();
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet dataSet = MasterExecuteCommand(_DropDown, parameters);
            DataTable dtBranch = new DataTable();
            objPickListDD.PickListDD = dataSet.Tables[0].ToCollection<PickListDD>();
            objPickListDD.StockTypeDD = dataSet.Tables[1].ToCollection<StockTypeDD>();
            return objPickListDD;
        }

        public PickListDetails Fetch(PickList objPickList)
        {

            PickListDetails objPickListDetails = new PickListDetails();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objPickList.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(WarehouseSno);

            SqlParameter FromDate = new SqlParameter("@FromDate", objPickList.FromDate);
            FromDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter("@ToDate", objPickList.ToDate);
            ToDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ToDate);

            SqlParameter TransactionTypeSno = new SqlParameter("@TransactionTypeSno", objPickList.TransactionTypeSno);
            TransactionTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(TransactionTypeSno);

            SqlParameter StoragelocationSno = new SqlParameter("@StoragelocationSno", objPickList.StoragelocationSno);
            StoragelocationSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(StoragelocationSno);

            SqlParameter StockTypeSno = new SqlParameter("@StockTypeSno", objPickList.StockTypeSno);
            StockTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(StockTypeSno);

            SqlParameter TxtIssueOrderSno = new SqlParameter("@TxtIssueOrderSno", objPickList.TxtIssueOrderSno);
            TxtIssueOrderSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtIssueOrderSno);

            SqlParameter TxtBatchNo = new SqlParameter("@TxtBatchNo", objPickList.TxtBatchNo);
            TxtBatchNo.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(TxtBatchNo);

            SqlParameter objNoofOrders = new SqlParameter("@NoofOrders", objPickList.NoofOrders);
            objNoofOrders.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(objNoofOrders);


            DataSet ds = MasterExecuteCommand(_Fetch, sqlParameters);
            //  objPickListDet = ds.Tables[0].ToCollection<PickListDet>();
            objPickListDetails.objPickListDet = ds.Tables[0].ToCustomList<PickListDet>();
            objPickListDetails.objPickListOrder = ds.Tables[1].ToCustomList<PickListOrder>().FirstOrDefault();


            return objPickListDetails;


        }

        public PickListResponse Insert(PickListDetails objPickListDetails)
        {

            PickListResponse objResp = new PickListResponse();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter PickListSno = new SqlParameter("@PickListSno", objPickListDetails.objPickList.PickListSno);
            PickListSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(PickListSno);

            SqlParameter PickListDate = new SqlParameter("@PickListDate", objPickListDetails.objPickList.PickListDate);
            PickListDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(PickListDate);

            SqlParameter FromDate = new SqlParameter("@FromDate", objPickListDetails.objPickList.FromDate);
            FromDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter("@ToDate", objPickListDetails.objPickList.ToDate);
            ToDate.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(ToDate);


            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objPickListDetails.objPickList.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(WarehouseSno);

            SqlParameter EmployeeSno = new SqlParameter("@EmployeeSno", objPickListDetails.objPickList.EmployeeSno);
            EmployeeSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(EmployeeSno);

            SqlParameter VirtualLocationSts = new SqlParameter("@VirtualLocationSts", objPickListDetails.objPickList.VirtualLocationSts);
            VirtualLocationSts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(VirtualLocationSts);

            SqlParameter VirtualLocSno = new SqlParameter("@VirtualLocSno", objPickListDetails.objPickList.VirtualLocSno);
            EmployeeSno.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(VirtualLocSno);

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objPickListDetails.objPickList.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objPickListDetails.objPickList.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);


            SqlParameter objNoofOrders = new SqlParameter("@NoofOrders", objPickListDetails.objPickList.NoofOrders);
            objNoofOrders.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(objNoofOrders);

            SqlParameter objFloorDetails = new SqlParameter();
            objFloorDetails.ParameterName = "@PickListDetails";
            objFloorDetails.SqlDbType = SqlDbType.Structured;
            objFloorDetails.Value = objPickListDetails.objPickListDet.ToDataTable<PickListDet>();
            objFloorDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objFloorDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);


            //string result = string.Empty;


            //result = ds.Tables[0].Rows[0][0].ToString();
            objResp = ds.Tables[0].ToCustomList<PickListResponse>().FirstOrDefault();



            return objResp;


        }

        public string PLCInsert(PickListConfirmation objPLC)
        {



            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter PickListSno = new SqlParameter("@PickListSno", objPLC.PickListSno);
            PickListSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PickListSno);

            SqlParameter PickListDetSno = new SqlParameter("@PickListDetSno", objPLC.PickListDetSno);
            PickListDetSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PickListDetSno);

            SqlParameter PickListLocSno = new SqlParameter("@PickListLocSno", objPLC.PickListLocSno);
            PickListLocSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PickListLocSno);


            SqlParameter LocationSno = new SqlParameter("@LocationSno", objPLC.LocationSno);
            LocationSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(LocationSno);


            SqlParameter SubZoneSno = new SqlParameter("@SubZoneSno", objPLC.SubZoneSno);
            SubZoneSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(SubZoneSno);


            SqlParameter PalletSno = new SqlParameter("@PalletSno", objPLC.PalletSno);
            PalletSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PalletSno);


            SqlParameter PalletTypeSno = new SqlParameter("@PalletTypeSno", objPLC.PalletTypeSno);
            PalletTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PalletTypeSno);

            SqlParameter Qty = new SqlParameter("@Qty", objPLC.Qty);
            Qty.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(Qty);

            //SqlParameter StorageLocationSno = new SqlParameter("@StorageLocationSno", objPLC.StoragelocationSno);
            //StorageLocationSno.SqlDbType = SqlDbType.Int;
            //sqlParameters.Add(StorageLocationSno);

            DataSet ds = MasterExecuteCommand(_PLCInsert, sqlParameters);


            string result = string.Empty;


            result = ds.Tables[0].Rows[0][0].ToString();




            return result;


        }
        public PickListDetails Edit(int PickListSno)
        {
            PickListDetails objPickListDetails = new PickListDetails();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@PickListSno", PickListSno));

            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            objPickListDetails.objPickList = ds.Tables[0].ToCustomList<PickList>().FirstOrDefault();
            objPickListDetails.objPickListDet = ds.Tables[1].ToCustomList<PickListDet>();
            return objPickListDetails;
        }

        public List<PickListDashboard> LoadData(int UserSno,string RoleFlag)
        {
            List<PickListDashboard> objPickListDashboard = new List<PickListDashboard>();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@UserSno", UserSno));
            Sqlparams.Add(new SqlParameter("@RoleFlag", RoleFlag));
            DataSet ds = MasterExecuteCommand(_LoadData, Sqlparams);
            objPickListDashboard = ds.Tables[0].ToCustomList<PickListDashboard>();
            return objPickListDashboard;
        }

        public PickListConfirmation PLConfirmationFetch(int PickListLocSno)
        {
            PickListConfirmation objPickListConfirmation = new PickListConfirmation();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@PickListLocSno", PickListLocSno));
          
            DataSet ds = MasterExecuteCommand(_PLConfirmationFetch, Sqlparams);
            objPickListConfirmation = ds.Tables[0].ToCustomList<PickListConfirmation>().FirstOrDefault();
            return objPickListConfirmation;
        }
        public Tuple<List<PickList>, int> Search(PageRequest pageRequest)
        {
            List<PickList> SearchList = new List<PickList>();
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
                SearchList = dataSet.Tables[0].ToCollection<PickList>();
            }
            return new Tuple<List<PickList>, int>(SearchList, recordCount);

        }
        public PickListConfirmList PLConfirmFetch(int PickListSno,int IssueOrderDetSno, int SubZoneSno, int LocationSno)
        {
            PickListConfirmList objPickListConfirmation = new PickListConfirmList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@PickListSno", PickListSno));
            Sqlparams.Add(new SqlParameter("@IssueOrderDetSno", IssueOrderDetSno));
            Sqlparams.Add(new SqlParameter("@SubZoneSno", SubZoneSno));
            Sqlparams.Add(new SqlParameter("@LocationSno", LocationSno));

            DataSet ds = MasterExecuteCommand(_PLConfirmFetch, Sqlparams);
            objPickListConfirmation.PLConfirmation = ds.Tables[0].ToCustomList<PickListConfirm>().FirstOrDefault();
            objPickListConfirmation.PLConfirmationDet = ds.Tables[1].ToCustomList<PickListConfirmDet>();
            return objPickListConfirmation;
        }
        public List<PickListDash> LoadDash(int UserSno, string RoleFlag)
        {
            List<PickListDash> objPickListDashboard = new List<PickListDash>();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@UserSno", UserSno));
            Sqlparams.Add(new SqlParameter("@RoleFlag", RoleFlag));
            DataSet ds = MasterExecuteCommand(_LoadDash, Sqlparams);
            objPickListDashboard = ds.Tables[0].ToCustomList<PickListDash>();
            return objPickListDashboard;
        }
        public PLConfirmDash PLCDash(int UserSno, string RoleFlag)
        {
            PLConfirmDash objPickList = new PLConfirmDash();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@UserSno", UserSno));
            Sqlparams.Add(new SqlParameter("@RoleFlag", RoleFlag));

            try
            {
                DataSet ds = MasterExecuteCommand(_PLConfirm, Sqlparams);
                objPickList.objPLConfirm = ds.Tables[0].ToCustomList<PLConfirm>();
                objPickList.objPLConfirmDet = ds.Tables[1].ToCustomList<PLConfirmDet>();
            }
            catch (Exception ex)
            {

            }
            return objPickList;
        }
        public string PLConfirmInsert(PickListConfirmList objPLC)
        {

            string result = string.Empty;

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter PickListSno = new SqlParameter("@PickListSno", objPLC.PLConfirmation.PickListSno);
            PickListSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PickListSno);

            DataTable dtPL = new DataTable();

            dtPL.Columns.Add("PickListLocSno");
            dtPL.Columns.Add("LocationSno");
            dtPL.Columns.Add("SubZoneSno");
            dtPL.Columns.Add("PalletSno");
            dtPL.Columns.Add("PalletTypeSno");
            dtPL.Columns.Add("Qty");

            foreach (PickListConfirmDet Obj in objPLC.PLConfirmationDet)
            {
                dtPL.Rows.Add(Obj.PickListLocSno,Obj.LocationSno,Obj.SubZoneSno,Obj.PalletSno,Obj.PalletTypeSno,Obj.Qty);
            }

            SqlParameter objPLDetails = new SqlParameter();
            objPLDetails.ParameterName = "@PLDetails";
            objPLDetails.SqlDbType = SqlDbType.Structured;
            objPLDetails.Value = dtPL;
            objPLDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objPLDetails);

            try
            {
                DataSet ds = MasterExecuteCommand(_PLConfirmInsert, sqlParameters);

                result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }
        public DataTable PrintSearch(int PickListSno)
        {
            DataTable dt = new DataTable();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@PickListSno", PickListSno));
            DataSet ds = MasterExecuteCommand(_PrintSearch, Sqlparams);
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable Print(int PickListSno, int IssueOrderSno)
        {
            DataTable dt = new DataTable();

            List<SqlParameter> objSqlparameters = new List<SqlParameter>();

            SqlParameter ParamMonthlyBillSno = new SqlParameter("@PickListSno", PickListSno);
            ParamMonthlyBillSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(ParamMonthlyBillSno);

            //SqlParameter ParamEmployeeSno = new SqlParameter("@EmployeeSno", EmployeeSno);
            //ParamEmployeeSno.SqlDbType = SqlDbType.Int;
            //objSqlparameters.Add(ParamEmployeeSno);


            SqlParameter ParamIssueOrderSno = new SqlParameter("@IssueOrderSno", IssueOrderSno);
            ParamIssueOrderSno.SqlDbType = SqlDbType.Int;
            objSqlparameters.Add(ParamIssueOrderSno);

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


        public string IssueOrderConfirmation(IssueOrderConfirmation objIssueOrderConfirmation)
        {
            RequestResponseLog ObjResLog = new RequestResponseLog();
            IssueOrderConfirmationResponse objResp = new IssueOrderConfirmationResponse();

            string Dateformat = "";
            string path = "";
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string Response = string.Empty;

            Dateformat = String.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            path = Path.Combine(ReqResLogPath + "\\IssueOrderConfirm\\" + date, "IssueOrderConfirm" + "_" + Guid.NewGuid().ToString() + "_" + Dateformat + ".txt");



            if (objIssueOrderConfirmation.Delivery_Number != "")
            {
                string URL = IssueOrderConfirmURL;

                string VerbType = "POST", ContentType = "application/json";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpWebResponse response;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);


                string SendData = JsonConvert.SerializeObject(objIssueOrderConfirmation);


                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " +
                 Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(SAPusername + ":" + SAPpassword)));

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
                    if (!string.IsNullOrEmpty(SendData))
                    {
                        data = encoding.GetBytes(SendData);
                        using (var requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(data, 0, data.Length);
                        }
                    }


                    ObjResLog.FileCreate1(path, URL, "IssueOrder Confirmation URL: \n");
                    ObjResLog.FileCreate1(path, request.Headers.ToString(), "Header:\n");
                    string Request = SendData;
                    ObjResLog.FileCreate1(path, Request, "Request: \n");
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        System.IO.Stream dataStream = response.GetResponseStream();
                        System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
                        responseFromServer = reader.ReadToEnd();
                        Response = responseFromServer;
                        ObjResLog.FileCreate1(path, Response, "Success Response: \n");

                        objResp = JsonConvert.DeserializeObject<IssueOrderConfirmationResponse>(responseFromServer);


                    }

                }
                catch (WebException ex)
                {

                    Response = (ex).ToString();
                    ObjResLog.FileCreate1(path, Response, "Error Response: \n");


                }

            }

            else
            {
                Response = "No Record Found";
                ObjResLog.FileCreate1(path, Response, "Response: \n");
            }


            return Response;
        }
        public string PLConInsert(PickListConfirmList objPLC)
        {

            string result = string.Empty;

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter PickListSno = new SqlParameter("@PickListSno", objPLC.PLConfirmation.PickListSno);
            PickListSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PickListSno);

            SqlParameter LocationFlag = new SqlParameter("@LocationFlag", objPLC.PLConfirmation.LocationFlag);
            LocationFlag.SqlDbType = SqlDbType.Char;
            sqlParameters.Add(LocationFlag);

            DataTable dtPL = new DataTable();

            dtPL.Columns.Add("PickListLocSno");
            dtPL.Columns.Add("LocationSno");
            dtPL.Columns.Add("SubZoneSno");
            dtPL.Columns.Add("PalletSno");
            dtPL.Columns.Add("PalletTypeSno");
            dtPL.Columns.Add("Qty");

            foreach (PickListConfirmDet Obj in objPLC.PLConfirmationDet)
            {
                dtPL.Rows.Add(Obj.PickListLocSno, Obj.LocationSno, Obj.SubZoneSno, Obj.PalletSno, Obj.PalletTypeSno, Obj.Qty);
            }

            SqlParameter objPLDetails = new SqlParameter();
            objPLDetails.ParameterName = "@PLDetails";
            objPLDetails.SqlDbType = SqlDbType.Structured;
            objPLDetails.Value = dtPL;
            objPLDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objPLDetails);

            try
            {
                DataSet ds = ExecuteCommand(_PLConInsert, sqlParameters);

                result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }
        public string PLConfInsert(PickListConfirmList objPLC)
        {

            string result = string.Empty;

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter PickListSno = new SqlParameter("@PickListSno", objPLC.PLConfirmation.PickListSno);
            PickListSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(PickListSno);

            SqlParameter LocationFlag = new SqlParameter("@LocationFlag", objPLC.PLConfirmation.LocationFlag);
            LocationFlag.SqlDbType = SqlDbType.Char;
            sqlParameters.Add(LocationFlag);

            DataTable dtPL = new DataTable();

            dtPL.Columns.Add("PickListLocSno");
            dtPL.Columns.Add("IssueOrderDetSno");
            dtPL.Columns.Add("LocationSno");
            dtPL.Columns.Add("SubZoneSno");
            dtPL.Columns.Add("PalletSno");
            dtPL.Columns.Add("PalletTypeSno");
            dtPL.Columns.Add("Qty");

            foreach (PickListConfirmDet Obj in objPLC.PLConfirmationDet)
            {
                dtPL.Rows.Add(Obj.PickListLocSno, Obj.IssueOrderDetSno, Obj.LocationSno, Obj.SubZoneSno, Obj.PalletSno, Obj.PalletTypeSno, Obj.Qty);
            }

            SqlParameter objPLDetails = new SqlParameter();
            objPLDetails.ParameterName = "@PLDetails";
            objPLDetails.SqlDbType = SqlDbType.Structured;
            objPLDetails.Value = dtPL;
            objPLDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objPLDetails);

            try
            {
                DataSet ds = ExecuteCommand(_PLConfInsert, sqlParameters);

                result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }
        public LocData PLCLocation(int UserSno, string TypeValue, int WarehouseSno, int ItemSno, int IssueOrderDetSno, int TypesSno, decimal Qty)
        {
            LocData ObjLOC = new LocData();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UserSno", UserSno));
            parameters.Add(new SqlParameter("@TypeValue", TypeValue));
            parameters.Add(new SqlParameter("@WarehouseSno", WarehouseSno));
            parameters.Add(new SqlParameter("@ItemSno", ItemSno));
            parameters.Add(new SqlParameter("@IssueOrderDetSno", IssueOrderDetSno));
            parameters.Add(new SqlParameter("@TypesSno", TypesSno));
            parameters.Add(new SqlParameter("@Qty_1", Qty));

            try
            {
                DataSet ds = ExecuteCommand(_PLLocation, parameters);
                ObjLOC = ds.Tables[0].ToCollection<LocData>().FirstOrDefault();
            }
            catch (Exception ex)
            {

            }

            return ObjLOC;
        }
    }
}
