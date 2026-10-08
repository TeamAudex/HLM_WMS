using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Repository;

namespace POMS.API.Controllers.Masters
{
    [RoutePrefix("Api/Alreadyexist")]
    public class AlreadyexistController : ApiController
    {
        AlreadyCheckRepository _AlreadyCheckRepository = new AlreadyCheckRepository();
        [Route("AlreadyexistOne")]
        [HttpGet]
        public string AlreadyexistOne(string Condition, string Condition1)
        {
            return _AlreadyCheckRepository.AlreadyexistOne(Condition, Condition1);
        }
     
        [Route("AlreadyexistTwo")]
        [HttpGet]
        public string AlreadyexistTwo(string Condition, string Condition1, string Condition2)
        {
            return _AlreadyCheckRepository.AlreadyexistTwo(Condition, Condition1, Condition2);
        }

        [Route("AlreadyexistThree")]
        [HttpGet]
        public string AlreadyexistThree(string Condition, string Condition1, string Condition2, string Condition3)
        {
            return _AlreadyCheckRepository.AlreadyexistThree(Condition, Condition1, Condition2, Condition3);
        }
        [Route("AlreadyexistFive")]
        [HttpGet]
        public string AlreadyexistFive(string Condition, string Condition1, string Condition2, string Condition3, string Condition4, string Condition5)
        {
            return _AlreadyCheckRepository.AlreadyexistFive(Condition, Condition1, Condition2, Condition3, Condition4, Condition5);
        }

    }
}
