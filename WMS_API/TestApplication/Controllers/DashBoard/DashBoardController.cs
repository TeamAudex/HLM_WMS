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
    [RoutePrefix("Api/DashBoard")]
    public class DashBoardController : ApiController
    {
        public  DashBoardRepository _DashBoardRepository = new DashBoardRepository();

        [HttpGet]
        [Route("LoadLiveData")]
        public LiveTrackDet LoadLiveData(int UserSno)
        {
            return _DashBoardRepository.LoadLiveData(UserSno);
        }

        [HttpPost]
        [Route("FilterLiveData")]
        public LiveTrackDet FilterLiveData(request objSearch)
        {
            return _DashBoardRepository.FilterLiveData(objSearch);
        }
        }
}
