using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;

namespace TestApplication.Controllers
{

    [RoutePrefix("Api/LrInvoice")]
    public class LrInvoiceController : ApiController
    {
        LrInvoiceRepository objLrRepository = new LrInvoiceRepository();
        //[HttpPost]
        //[Route("LRSearchPage")]
        //public Tuple<List<Lrgrid>, int> LRSearchPage(PageRequest pageRequest)
        //{
        //    pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
        //    return objLrRepository.LRSearchPage(pageRequest);
        //}




        [HttpPost]
        [Route("Filter")]
        public List<Lrgrid> Filter(LrInvoice objDispatchModel)
        {
            return objLrRepository.Dispatch_Filter(objDispatchModel);
        }

        //[HttpPost]
        //[Route("LRInsert")]
        //public string LRInsert(Lrgrid objPDDetails)
        //{
        //    return objLrRepository.LRInsert(objPDDetails);
        //}

        [HttpPost]
        [Route("LRInsert")]
        public List<objLr> LRInsert(objLr objobjLr)
        {
            return objLrRepository.LRInsert(objobjLr);
        }




    }
}