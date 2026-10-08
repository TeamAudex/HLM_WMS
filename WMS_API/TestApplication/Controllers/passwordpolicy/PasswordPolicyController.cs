using Librarys.Extenders;
using Librarys.Logging;
using POM.Entity;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EncryptDecryptAssembly;
using System.Text;

namespace TestApplication.Controllers
{
    [RoutePrefix("Api/PasswordPolicy")]
    public class PasswordPolicyController : ApiController
    {
        passwordpolicyrespository _passwordpolicyrespository = new passwordpolicyrespository();
        EncryptDecrypt objEncrypt = new EncryptDecrypt();

        [Route("GetUser")]
        [HttpGet]
        public UserMas GetUser(string UserCode)
        {
            return _passwordpolicyrespository.GetUser(UserCode);
        }
        [Route("CheckalreadyExists")]
        [HttpGet]
        public string CheckalreadyExists(string UserCode, string password)
        {
            password = objEncrypt.Encrypt(password, "");
            return _passwordpolicyrespository.CheckalreadyExists(UserCode, password);
        }
        [Route("InsertPassword")]
        [HttpPost]
        public Tuple<string, bool> InsertPassword(UserMas objUser)
        {
            objUser.password = GetRandomPassword(8);
            objUser.Opassword = objUser.password;
            objUser.password = objEncrypt.Encrypt(objUser.password, "");
            return _passwordpolicyrespository.InsertPassword(objUser);
        }
        public static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}
