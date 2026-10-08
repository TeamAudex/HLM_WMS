using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POM.Entity;
using POM.Repository;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/MenuMas")]
    public class MenuMasController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetMenuDetails")]
        [Route("GetMenuDetails")]
        public List<MenuMas> GetMenuList(int RoleID)
        {
         MenuMasRepository  objMenuMasBL = new MenuMasRepository();
            return objMenuMasBL.GetMenuList(RoleID);
        }
        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetMenuListAutoComplete")]
        [Route("GetMenuListAutoComplete")]
        public List<MenuMas> GetMenuListAutoComplete(int RoleID,string title)
        {
            MenuMasRepository objMenuMasBL = new MenuMasRepository();
            return objMenuMasBL.GetMenuListAutoComplete(RoleID, title);
        }
        //[AllowAnonymous]
        //[HttpGet]
        //[ActionName("GetMobileMenu")]
        //[Route("GetMobileMenu")]
        //public List<MenuMas> GetMobileMenu(int StoreSno, int UserSno)
        //{
        //    MenuMasRepository objMenuMasBL = new MenuMasRepository();
        //    return objMenuMasBL.GetMobileMenu(StoreSno,UserSno);
        //}

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetMobileMenu")]
        [Route("GetMobileMenu")]
        public List<MenuMas> GetMobileMenu(int RoleID)
        {
            MenuMasRepository objMenuMasBL = new MenuMasRepository();
            return objMenuMasBL.GetMobileMenu(RoleID);
        }
    }
}