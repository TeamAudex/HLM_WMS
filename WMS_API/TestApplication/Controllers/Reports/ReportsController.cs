using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web;
using System.Net.Http;
using System.Net;
using POMS.Entity;
using Microsoft.Reporting.WebForms;
using System.Web.Mvc;
using POMS.Repository;
using System.Text;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml;
using System.Data;

namespace TestApplication.Controllers
{
    [System.Web.Http.RoutePrefix("Api/Reports")]
    public class ReportsController : ApiController
    {

        ReportsRepository _repository = new ReportsRepository();
    
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("AutoCompleteAPI")]
        public List<ReportsClass> AutoCompleteAPI(string SP, int UserSno, string TypeValue, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "")
        {
            return _repository.AutoComplete(SP, UserSno, TypeValue, Condition1, Condition2, Condition3, Condition4, Condition5, Condition6);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("AutoCompleteIST")]
        public List<ReportsClass> AutoCompleteIST(string SP, int UserSno, string TypeValue, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "", string Condition7 = "")
        {
            return _repository.AutoCompleteIST(SP, UserSno, TypeValue, Condition1, Condition2, Condition3, Condition4, Condition5, Condition6, Condition7);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("DropDownFetch")]
        public DropDownList DropDownFetch()
        {
            return _repository.DropDownFetch();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("DropDownFetchData")]
        public DropDownList DropDownFetchData(string SP)
        {
            return _repository.DropDownFetchData(SP);
        }
        //[System.Web.Http.HttpGet]
        //[System.Web.Http.Route("DropDownFetchDataLifecycle")]
        //public DropDownListLifecycle DropDownFetchDataLifecycle(string SP)
        //{
        //    return _repository.DropDownFetchDataLifecycle(SP);
        //}

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("DropDownsAPI")]
        public List<List<Reports1>> DropDowns(string SP, int UserSno, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "")
        {
            return _repository.DropDowns(SP, UserSno, Condition1, Condition2, Condition3, Condition4, Condition5, Condition6);
        }
        



    }
}
