using POM.Entity;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TestApplication.Controllers.Auction
{
    [RoutePrefix("Api/VendorResponseAuc")]
    public class VendorResponseAucController : ApiController
    {
        VendorResponseAucRepository _VendorResponseAucRepository = new VendorResponseAucRepository();
        [HttpPost]
        [Route("insertBid")]
        public VendorRespBidDetail GetAuctionDetail(VendorUpdateBidDet objBidDet)
        {
            return _VendorResponseAucRepository.GetAuctionDetail(objBidDet);
        }
        [HttpGet]
        [Route("CheckAuctionTiming")]
        public int CheckAuctionTiming(int UserSno, string CurTime)
        {
            return _VendorResponseAucRepository.CheckAuctionTiming(UserSno, CurTime);
        }
        [HttpGet]
        [Route("GetAuctionDetails")]
        public VendorResponseAucMas GetAuctionDetails(int UserSno, int AuctionSno)
        {
            return _VendorResponseAucRepository.GetAuctionDetails(UserSno, AuctionSno);
        }
        [HttpGet]
        [Route("AuctionTest")]
        public Bid GetAuctionDetails(string name,decimal price)
        {
            return _VendorResponseAucRepository.GetAuctionDetails(name, price);
        }
        [HttpGet]
        [Route("GetBidDetialsTest")]
        public Bid GetBidDetials(int VendorSno)
        {
            return _VendorResponseAucRepository.GetBidDetials(VendorSno);
        }

    }
}
