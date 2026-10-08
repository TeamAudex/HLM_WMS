using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;
using Entity.Reports;
using Repository.Reports;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Net.Http.Headers;
using System.Data;
namespace TestApplication.Controllers.Reports
{
    [RoutePrefix("Api/STReport")]
    public class StockTransferReportController : ApiController
    {
        StockTransferReportRepository _repository = new StockTransferReportRepository();
        [HttpGet]
        [Route("DropDown")]
        public List<StockTransferDD> DropDown()
        {
            return _repository.DropDown();
        }
    }
}
