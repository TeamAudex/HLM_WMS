using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POM.Repository;
using Librarys;
using Librarys.Extenders;
using POMS.Entity;

namespace POMS.Repository
{
   public  class VendorResponseAucRepository : RepositoryBaseNew
    {
        const string _VendorResponseAuc_Insert = "USP_GET_LIVE_AUCTION_DET";
        const string _VendorResponseAuc_Edit = "USP_EDIT_INVITE_FOR_AUCTION";
        const string _Get_Autocomplete = "USP_AUTOCOMPLETE_INVITE_AUCTION";
        const string _Get_Auction_Timing = "USP_GET_AUCTION_TIMING";
        const string _Get_Auction_Details = "USP_GET_AUCTION_DETAILS";
        const string _Get_Auction_Test = "USP_TEST_AUCTION";
        public int CheckAuctionTiming(int VendorSno,string CurTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@VendorSno", VendorSno));
            parameters.Add(new SqlParameter("@CurTime", CurTime));
            try
            {
                DataSet dataSet = ExecuteCommand(_Get_Auction_Timing, parameters);
                string Auctionflag = dataSet.Tables[0].Rows[0]["Auction"].ToString();
                if (Auctionflag != null && Auctionflag != "")
                {  
                        return Convert.ToInt32(Auctionflag);             
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VendorResponseAucMas GetAuctionDetails(int VendorSno,int InvAuctionSno)
        {
            VendorResponseAucMas objTotalUpdateBidDet = new VendorResponseAucMas();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@InvAuctionSno", InvAuctionSno));
            parameters.Add(new SqlParameter("@VendorSno", VendorSno));
            DataSet dataSet = ExecuteCommand(_Get_Auction_Details, parameters);
            objTotalUpdateBidDet.objVendorRespFetch = dataSet.Tables[0].ToCustomList<VendorResponseAucFetch>().FirstOrDefault();
            objTotalUpdateBidDet.objVendorRespAucDetFetch = dataSet.Tables[1].ToCollection<VendorRespAucDetFetch>();
            objTotalUpdateBidDet.objAuctionRule = dataSet.Tables[2].ToCollection<RulesEngine>();
            return objTotalUpdateBidDet;
        }

        public VendorRespBidDetail GetAuctionDetail(VendorUpdateBidDet objBidDet)     
        {
            VendorRespBidDetail objBid = new VendorRespBidDetail();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter paramVendorAucRespSno = new SqlParameter("@VendorAucRespSno", objBidDet.objAuctionBid.VendorAucRespSno);
            paramVendorAucRespSno.SqlDbType = SqlDbType.Int;
            paramVendorAucRespSno.Direction = ParameterDirection.InputOutput;
            sqlParameters.Add(paramVendorAucRespSno);

            SqlParameter paramVendorSno = new SqlParameter("@VendorSno", objBidDet.objAuctionBid.VendorSno);
            paramVendorSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramVendorSno);

            SqlParameter paramEntryDate = new SqlParameter("@EntryDate", objBidDet.objAuctionBid.EntryDate);
            paramEntryDate.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(paramEntryDate);

            SqlParameter paramConPrSno = new SqlParameter("@ConPrSno", objBidDet.objAuctionBid.ConPrSno);
            paramConPrSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramConPrSno);

            SqlParameter paramVendorRespSno = new SqlParameter("@VendorRespSno", objBidDet.objAuctionBid.VendorRespSno);
            paramVendorRespSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramVendorRespSno);

            SqlParameter paramConPRLotSno = new SqlParameter("@ConPRLotSno", objBidDet.objAuctionBid.ConPRLotSno);
            paramConPRLotSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramConPRLotSno);

            SqlParameter paramDiscountPercent = new SqlParameter("@DiscountPercent", objBidDet.objAuctionBid.DiscountPercent);
            paramDiscountPercent.SqlDbType = SqlDbType.Decimal;
            sqlParameters.Add(paramDiscountPercent);

            SqlParameter paramInvAuctionSno = new SqlParameter("@InvAuctionSno", objBidDet.objAuctionBid.InvAuctionSno);
            paramInvAuctionSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramInvAuctionSno);

            SqlParameter paramTotalAmount = new SqlParameter("@TotalAmount", objBidDet.objAuctionBid.TotalAmount);
            paramTotalAmount.SqlDbType = SqlDbType.Decimal;
            sqlParameters.Add(paramTotalAmount);

            SqlParameter paramTaxAmount = new SqlParameter("@TaxAmount", objBidDet.objAuctionBid.TaxAmount);
            paramTaxAmount.SqlDbType = SqlDbType.Decimal;
            sqlParameters.Add(paramTaxAmount);

            SqlParameter paramsts = new SqlParameter("@sts", objBidDet.objAuctionBid.sts);
            paramsts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(paramsts);

            SqlParameter paramCreOpr = new SqlParameter("@CreOpr", objBidDet.objAuctionBid.CreOpr);
            paramCreOpr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreOpr);

            SqlParameter paramBidWiseFlag = new SqlParameter("@BidWiseFlag", objBidDet.objAuctionBid.BidWiseFlag);
            paramBidWiseFlag.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paramBidWiseFlag);

            SqlParameter paramIpNumber = new SqlParameter("@IpNumber", objBidDet.objAuctionBid.IpNumber);
            paramIpNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paramIpNumber);

            SqlParameter paramDiscountPer = new SqlParameter("@DiscountPer", objBidDet.objAuctionBid.DiscountPer);
            paramDiscountPer.SqlDbType = SqlDbType.Decimal;
            sqlParameters.Add(paramDiscountPer);

            SqlParameter paramLOTDiscountAmt = new SqlParameter("@LOTDiscountAmt", objBidDet.objAuctionBid.LOTDiscountAmt);
            paramLOTDiscountAmt.SqlDbType = SqlDbType.Decimal;
            sqlParameters.Add(paramLOTDiscountAmt);

            SqlParameter paramAuctionLineOfItemWise = new SqlParameter();
            paramAuctionLineOfItemWise.ParameterName = "@AuctionDet";
            paramAuctionLineOfItemWise.SqlDbType = SqlDbType.Structured;
            paramAuctionLineOfItemWise.Value = objBidDet.objAuctionBidDet.ToDataTable<VendorRespAucDet>();
            paramAuctionLineOfItemWise.Direction = ParameterDirection.Input;
            sqlParameters.Add(paramAuctionLineOfItemWise);

            DataSet ds = ExecuteCommand(_VendorResponseAuc_Insert, sqlParameters);
            objBid = ds.Tables[0].ToCustomList<VendorRespBidDetail>().FirstOrDefault();
            return objBid;
        }
        public Bid GetAuctionDetails(string name, decimal price)
        {
            Bid objBidValue = new Bid();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", name));
            parameters.Add(new SqlParameter("@price", price));
            DataSet dataSet = ExecuteCommand(_Get_Auction_Test, parameters);
            objBidValue.name = dataSet.Tables[0].Rows[0]["name"].ToString();
            objBidValue.price = dataSet.Tables[0].Rows[0]["price"].ToString();
            return objBidValue;
        }
        public Bid GetBidDetials (int VendorSno)
        {
            Bid objBidValue = new Bid();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@VendorSno", VendorSno));
            parameters.Add(new SqlParameter("@ActionType", "Fetch"));
            DataSet dataSet = ExecuteCommand(_Get_Auction_Test, parameters);
            objBidValue.name =  dataSet.Tables[0].Rows[0]["name"].ToString();
            objBidValue.price = dataSet.Tables[0].Rows[0]["price"].ToString();
            return objBidValue;
        }
    }
}
