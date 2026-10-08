using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POM.Entity;
using POM.Repository;
using Librarys;
using Librarys.Extenders;
using POMS.Entity;

namespace POMS.Repository
{
   public  class InviteForAuctionRepository : RepositoryBaseNew
    {
        const string _InviteForAuction_Insert = "USP_INSERT_INVITE_AUCTION";
        const string _InviteForAuction_Edit = "USP_EDIT_INVITE_FOR_AUCTION";
        const string _InviteForAuction_select = "USP_RST_INVITE_AUCTION_SELECT";
        const string _Get_Autocomplete = "USP_AUTOCOMPLETE_INVITE_AUCTION";
        const string _Get_Vendor_List = "USP_GET_VENDOR_BY_RFXNO";
        public InviteForAuctionMas GetInviteForAuction(int InvAuctionSno)
        {

            SqlParameter paramActionID = new SqlParameter("@InvAuctionSno", InvAuctionSno);
            SqlCommand sqlCmd = new SqlCommand(_InviteForAuction_Edit);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            InviteForAuctionMas objAuctionMas = new InviteForAuctionMas();
            objAuctionMas.objAuction = new InivationForAuction();
            objAuctionMas.objAuctionDetFetch = new List<InvitationForAuctionDetFetch>();

            DataSet dsInviteForAuction = new DataSet();
            DataTable dtInviteForAuction = new DataTable();
            DataTable dtInviteForAuctionDet = new DataTable();
            dsInviteForAuction.Tables.Add(dtInviteForAuction);
            dsInviteForAuction.Tables.Add(dtInviteForAuctionDet);
            dsInviteForAuction.Load(dataReader, LoadOption.OverwriteChanges, dtInviteForAuction, dtInviteForAuctionDet);
            objAuctionMas.objAuction = dsInviteForAuction.Tables[0].ToCustomList<InivationForAuction>().FirstOrDefault();
            objAuctionMas.objAuctionDetFetch = dsInviteForAuction.Tables[1].ToCollection<InvitationForAuctionDetFetch>();
            return objAuctionMas;
        }
        public string InsertobjInviteForAuction(InviteForAuctionMas objInviteForAuctionMas)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter paramInvAuctionSno = new SqlParameter("@InvAuctionSno", objInviteForAuctionMas.objAuction.InvAuctionSno);
            paramInvAuctionSno.SqlDbType = SqlDbType.Int;
            paramInvAuctionSno.Direction = ParameterDirection.InputOutput;
            sqlParameters.Add(paramInvAuctionSno);

            SqlParameter paramConPRSno = new SqlParameter("@ConPRSno", objInviteForAuctionMas.objAuction.ConPRSno);
            paramConPRSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramConPRSno);

            SqlParameter paramConPRLotSno = new SqlParameter("@ConPRLotSno", objInviteForAuctionMas.objAuction.ConPRLotSno);
            paramConPRLotSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramConPRLotSno);

            SqlParameter paramRuleSno = new SqlParameter("@RuleSno", objInviteForAuctionMas.objAuction.RuleSno);
            paramRuleSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramRuleSno);

            SqlParameter paramBidDate = new SqlParameter("@BidDate", objInviteForAuctionMas.objAuction.BidDate);
            paramBidDate.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(paramBidDate);

            SqlParameter paramBidsubDate = new SqlParameter("@BidsubDate", objInviteForAuctionMas.objAuction.BidsubDate);
            paramBidsubDate.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(paramBidsubDate);

            SqlParameter paramBidComDate = new SqlParameter("@BidComDate", objInviteForAuctionMas.objAuction.BidComDate);
            paramBidComDate.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(paramBidComDate);

            SqlParameter paramBidAwardDate = new SqlParameter("@BidAwardDate", objInviteForAuctionMas.objAuction.BidAwardDate);
            paramBidAwardDate.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(paramBidAwardDate);

            SqlParameter paramFromDuration = new SqlParameter("@FromDuration", objInviteForAuctionMas.objAuction.FromDuration);
            paramFromDuration.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(paramFromDuration);

            SqlParameter paramToDuration = new SqlParameter("@ToDuration", objInviteForAuctionMas.objAuction.ToDuration);
            paramToDuration.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(paramToDuration);

            SqlParameter paramMinDecValue = new SqlParameter("@MinDecValue", objInviteForAuctionMas.objAuction.MinDecValue);
            paramMinDecValue.SqlDbType = SqlDbType.Decimal;
            sqlParameters.Add(paramMinDecValue);

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objInviteForAuctionMas.objAuction.CreOpr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter paramSts = new SqlParameter("@Sts", objInviteForAuctionMas.objAuction.sts);
            paramSts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(paramSts);

            SqlParameter paramIPNumber = new SqlParameter("@IpNumber", objInviteForAuctionMas.objAuction.IPNumber);
            paramIPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(paramIPNumber);


            SqlParameter paramGSTDetails = new SqlParameter();
            paramGSTDetails.ParameterName = "@InviteAuctionDetails";
            paramGSTDetails.SqlDbType = SqlDbType.Structured;
            paramGSTDetails.Value = objInviteForAuctionMas.objAuctionDet.ToDataTable<InvitationForAuctionDet>();
            paramGSTDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(paramGSTDetails);

            DataSet ds = ExecuteCommand(_InviteForAuction_Insert, sqlParameters);
            string strMessage = ds.Tables[0].Rows[0][0].ToString();
            return strMessage;
        }
        public List<InivationForAuction> GetInviteForAuctionDetails(PageRequest pageRequest)
        {
            List<InivationForAuction> InviteForAuction = new List<InivationForAuction>();
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
                parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                DataSet dataSet = ExecuteCommand(_InviteForAuction_select, parameters, ref recordCount);

                InviteForAuction = dataSet.Tables[0].ToCollection<InivationForAuction>();
            }
            return InviteForAuction;
        }

        public List<InivationForAuction> Get(InivationForAuction searchCriteria)
        {
            return new List<InivationForAuction>();
        }
        public List<InvitationForAuctionDetFetch> GetVendorByRFXNo(int ConPRSno,int ConPRLotSno)
        {
            List<InvitationForAuctionDetFetch> objVendorInvite = new List<InvitationForAuctionDetFetch>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ConPRSno", ConPRSno));
            parameters.Add(new SqlParameter("@ConPRLotSno", ConPRLotSno));
            DataSet dataSet = ExecuteCommand(_Get_Vendor_List, parameters);
            DataTable dt = new DataTable();
            objVendorInvite = dataSet.Tables[0].ToCollection<InvitationForAuctionDetFetch>();
            return objVendorInvite;
        }
        public List<InvitationForAuctionDetFetch> GetAutocomplete(string Condition, int condition1,int condition2)
        {
            List<InvitationForAuctionDetFetch> objautocomplete = new List<InvitationForAuctionDetFetch>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", Condition));
            parameters.Add(new SqlParameter("@condition1", condition1));
            parameters.Add(new SqlParameter("@condition2", condition2));
            DataSet dataSet = ExecuteCommand(_Get_Autocomplete, parameters);
            DataTable dt = new DataTable();
            objautocomplete = dataSet.Tables[0].ToCollection<InvitationForAuctionDetFetch>();
            return objautocomplete;
        }
    }
}
