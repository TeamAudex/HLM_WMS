using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository.Masters;
using POMS.Entity.Masters;

namespace POMS.API.Controllers.Masters
{
    [RoutePrefix("Api/Employee")]
    public class EmployeeController : ApiController
    {
        EmployeeRepository _EmployeeRepository = new EmployeeRepository();
       
        [ActionName("EmployeeInsert")]
        [HttpPost]
        [Route("EmployeeInsert")]
        public string EmployeeInsert(Employee ObjEmployee)
        {
            return _EmployeeRepository.EmployeeInsert(ObjEmployee);
        }
        [ActionName("EmployeeSearch")]
        [Route("EmployeeSearch")]
        [HttpPost]
        public Tuple<List<Employee>, int> EmployeeSearch(PageRequest ObjEmployee)
        {
            ObjEmployee.Query = ObjEmployee.GetFilterQuery(ObjEmployee.Filters);
            return _EmployeeRepository.EmployeeSearch(ObjEmployee);
        }
        [ActionName("EmployeeGet")]
        [HttpPost]
        [Route("EmployeeGet")]
        public List<Employee> EmployeeGet(Employee ObjEmployee)
        {
            return _EmployeeRepository.EmployeeGet(ObjEmployee);
        }

        [ActionName("EmployeeRoleAutoComplete")]
        [HttpPost]
        [Route("EmployeeRoleAutoComplete")]
        public List<Employee> EmployeeRoleAutoComplete(Employee ObjEmployee)
        {
            return _EmployeeRepository.EmployeeGet(ObjEmployee);
        }

        [HttpPost]
        [Route("SubscriberInsert")]
        public string SubscriberInsert(subscribers ObjSub)
        {
            return _EmployeeRepository.SubscriberInsert(ObjSub);
        }
        [HttpGet]
        [Route("SubscriberLogin")]
        public subscribers SubscriberLoginGet(string MobileNo, string MPIN)
        {
            return _EmployeeRepository.SubscriberLoginGet(MobileNo, MPIN);
        }

    }
}
