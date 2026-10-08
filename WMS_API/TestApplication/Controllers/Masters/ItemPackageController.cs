using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity.Masters;
using POMS.Repository;
using POMS.Entity;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/ItemPackage")]
    public class ItemPackageController : ApiController
    {
        ItemPackageRepository objItemPackageRepository = new ItemPackageRepository();


        [HttpPost]
        [Route("InsertItemPackage")]
        public string InsertItemPackage(ItemPackageDetails objItemPackage)
        {
            return objItemPackageRepository.InsertItemPackage(objItemPackage);
        }

        [HttpPost]
        [Route("ItemPackageSearch")]
        public Tuple<List<ItemPackage>,int>ItemPackageSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return objItemPackageRepository.ItemPackageSearch(pageRequest);
        }


        [HttpGet]
        [Route("ItemPackageEdit")]
        public ItemPackageDetails ItemPackageEdit(int ItemPackageSno)
        {
            return objItemPackageRepository.ItemPackageEdit(ItemPackageSno);
        }


        [HttpGet]
        [Route("DropDownList")]
        public ItemPackageDropDown DropDownList()
        {
            return objItemPackageRepository.DropDownList();
        }


        [HttpGet]
        public List<ItemPackage> GetAutocomplete(string Condition)
        {
   
            return objItemPackageRepository.GetAutoComplete(Condition);
        }


        [HttpGet]
        public List<ItemPackageDet> FetchVolume(int Condition,decimal Condition1,decimal Condition2,decimal Condition3)
        {

            return objItemPackageRepository.FetchVolume(Condition, Condition1, Condition2, Condition3);
        }

        [HttpGet]
        public List<ItemPackageDet> FetchVolumetricWeight(int Condition, decimal Condition1, decimal Condition2, decimal Condition3,int Condition4)
        {

            return objItemPackageRepository.FetchVolumetricWeight(Condition, Condition1, Condition2, Condition3, Condition4);
        }

    }
}