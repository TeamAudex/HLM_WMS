using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POM.Entity;
using POMS.Entity;
using POMS.Repository.Masters;
using POMS.Repository;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/Customer")]
    public class CustomerController : ApiController
    {
        CustomerRepository _CustomerRepository = new CustomerRepository();

        [HttpPost]
        [Route("InsertCustomer")]
        public string InsertCustomer(CustomerGrid objCustomer)
        {
            return _CustomerRepository.InsertCustomer(objCustomer);
        }

        [HttpGet]
        [Route("EditCustomer")]
        public CustomerGrid EditCustomer(int CustomerSno)
        {
            return _CustomerRepository.EditCustomer(CustomerSno);
        }

        

        [HttpPost]
        [Route("SearchCustomer")]
        public Tuple<List<Customer>, int> SearchCustomer(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _CustomerRepository.SearchCustomer(pageRequest);
        }

        [HttpGet]
        [Route("CustomerAutoComplete")]
        public List<CustomerDet> CustomerAutoComplete(string Condition)
        {
            return _CustomerRepository.CustomerAutoComplete(Condition);
        }


        [HttpGet]
        [Route("DropDown1")]
        public dropdownList1 DropDown1()
        {
            return _CustomerRepository.CustomerGroupDropDown();
        }

        [HttpGet]
        [Route("DropDown2")]
        public dropdownList2 DropDown2()
        {
            return _CustomerRepository.CustomerPaymentDropdown();
        }

        [HttpGet]
        [Route("DropDown3")]
        public dropdownList3 DropDown3()
        {
            return _CustomerRepository.CustomerCreditAmountDropdown();
        }

        [HttpGet]
        [Route("DropDown4")]
        public dropdownList4 DropDown4()
        {
            return _CustomerRepository.CustomerAddressTypeDropdown();
        }


        [HttpGet]
        [Route("DropDown5")]
        public dropdownList5 DropDown5()
        {
            return _CustomerRepository.objTypeDropdown();
        }
    }
}




   

        

       

      
       


