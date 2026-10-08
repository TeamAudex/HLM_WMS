using Librarys.Extenders;
using POM.Entity;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/FinancialhealthIndex")]
    public class FinancialhealthIndexController : ApiController
    {
        public FinancialHealthIndexRepository _Repository = new FinancialHealthIndexRepository();

        [HttpGet]
        [Route("FHIDashAll")]
        public List<DshFHITot> DshAll(int UserSno, string FromDate, string ToDate, string FlowFlag)
        {
            return _Repository.DshAll(UserSno, FromDate, ToDate, FlowFlag);
        }

    }
}
