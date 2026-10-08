using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Repository;
using POMS.Entity;
using Repository.Masters;
using Entity.Masters;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/UserBranchMap")]
    public class UserWarehouseMapController : ApiController
    {
        UserwarehousemapRepository UBMR = new UserwarehousemapRepository();

        [Route("InsertUserBranchMap")]
        public string InsertUserBranchMap(UserBranchMapSearch UserBranchlist)

        {
            return UBMR.InsertUserBranchMap(UserBranchlist);
        }

        [HttpGet]
        [Route("LoadUserBranchMap")]
        public List<UserBranchMapGrid> LoadUserBranchMap(int EmployeeSno)
        {
            return UBMR.LoadUserBranchMap(EmployeeSno);
        }
        [HttpGet]
        [Route("GetUserBranchAutoComplete")]
        public List<UserBranchMap> GetUserBranchAutoComplete(string Condition, int Condition1)
        {
            return UBMR.GetUserBranchAutoComplete(Condition, Condition1);
        }

        [HttpGet]
        [Route("GetUserBranchMapComplete")]
        public List<UserBranchMapGrid> GetUserBranchMapComplete(string Typedtxt, int Condition, int Condition1)
        {
            return UBMR.GetUserBranchMapComplete(Typedtxt, Condition, Condition1);
        }

        [HttpPost]
        [Route("UserBranchMapSearch")]
        public Tuple<List<UserBranchMap>, int> UserBranchMapSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return UBMR.UserBranchMapSearch(pageRequest);
        }

        [HttpGet]
        [Route("UserBranchMapEdit")]
        public UserBranchMapSearch UserBranchMapEdit(int EmployeeSno)
        {
            return UBMR.UserBranchMapEdit(EmployeeSno);
        }

        [HttpGet]
        [Route("GetEmployeeName")]
        public List<UserBranchMap> GetEmployeeName(string Flag)
        {
            return UBMR.GetEmployeeName(Flag);
        }

        [HttpGet]
        [Route("GetUserBranchMapDetail")]
        public List<UserBranchMapGrid> GetUserBranchMapDetail(int EmployeeSno)
        {
            return UBMR.GetUserBranchMapDetail(EmployeeSno);
        }
    }
}