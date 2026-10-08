using POM.Entity;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.Controllers
{
    [RoutePrefix("Api/InviteForAuction")]
    public class InviteForAuctionController : ApiController
    {
        InviteForAuctionRepository _InviteForAuctionRepository = new InviteForAuctionRepository();
        [HttpPost]
        [Route("insertInviteForAuction")]
        public string insertInviteForAuction(InviteForAuctionMas objInviteForAuctionMas)
        {
            return _InviteForAuctionRepository.InsertobjInviteForAuction(objInviteForAuctionMas);
        }
        [HttpPost]
        [Route("GetInviteForAuctionDetails")]
        public List<InivationForAuction> GetInviteForAuctionDetails(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _InviteForAuctionRepository.GetInviteForAuctionDetails(pageRequest);
        }
        [HttpGet]
        [Route("GetInviteForAuction")]
        public InviteForAuctionMas GetInviteForAuction(int InvAuctionSno)
        {
            return _InviteForAuctionRepository.GetInviteForAuction(InvAuctionSno);
        }
        [HttpGet]
        [Route("GetVendorByRFXNo")]
        public List<InvitationForAuctionDetFetch> GetVendorByRFXNo(int ConPRSno,int ConPRLotSno)
        {
            return _InviteForAuctionRepository.GetVendorByRFXNo(ConPRSno, ConPRLotSno);
        }
        [HttpGet]
        [Route("GetAutocomplete")]
        public List<InvitationForAuctionDetFetch> GetAutocomplete(string Condition, int condition1, int condition2)
        {
            return _InviteForAuctionRepository.GetAutocomplete(Condition, condition1, condition2);
        }
        }
}
