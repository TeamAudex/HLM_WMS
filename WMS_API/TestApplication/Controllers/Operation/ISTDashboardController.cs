using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;
using Entity.Operations;
using Repository.Operations;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Net.Http.Headers;
using System.Data;

namespace TestApplication.Controllers.Operation
{
    [RoutePrefix("Api/ISTDash")]
    public class ISTDashboardController : ApiController
    {
        ISTDashboardRepository _repository = new ISTDashboardRepository();
        [HttpGet]
        [Route("LoadDash")]
        public List<IST> LoadDash(int UserSno, string RoleFlag)
        {
            return _repository.LoadDash(UserSno, RoleFlag);
        }

        [HttpGet]
        [Route("ISTDetDash")]
        public List<ISTDet> ISTDetDash(int UserSno, int ISTSno)
        {
            return _repository.ISTDetDash(UserSno, ISTSno);
        }

        [HttpGet]
        [Route("PACFetch")]
        public PAFetch PACFetch(int PutAwayLocSno, int ISTDetSno)
        {
            return _repository.PACFetch(PutAwayLocSno, ISTDetSno);
        }
    }
}
