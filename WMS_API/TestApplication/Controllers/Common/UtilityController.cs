
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using POMS.Entity;
using POMS.Repository;

namespace TestApplication.Controllers.Common
{
    [RoutePrefix("Api/Utility")]
    public class UtilityController : ApiController
    {

        [HttpGet]
        [Route("GetIP")]
        public string Approval_Save()
        {
            string ipaddress = string.Empty;
            try
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null)
                {
                    ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].ToString();
                }
                else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
                {
                    ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                }
                else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                {
                    ipaddress = HttpContext.Current.Request.UserHostAddress;
                }

                if (ipaddress == "::1" || ipaddress == "127.0.0.1")
                {
                    ipaddress = GetLocalIPAddress();
                }
                else
                {
                    ipaddress += "-" + GetMacAddress(ipaddress);
                }
            }
            catch (Exception ex)
            {
                //Handle Exceptions  
            }
            return ipaddress;

            //string ipaddress = string.Empty;
            //string pubIp = new System.Net.WebClient().DownloadString("https://ipinfo.io/ip");
            //ipaddress = pubIp.Replace("\n", "");
            ////return ipaddress;

            ////get System IP
            ////string strHostName = System.Net.Dns.GetHostName();
            ////IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            ////IPAddress[] addr = ipEntry.AddressList;
            ////string ip = addr[1].ToString();
            ////return ip;
            ////get System IP

            //NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            //String sMacAddress = string.Empty;
            //String IpWithMacAddress = string.Empty;
            //foreach (NetworkInterface adapter in nics)
            //{
            //    if (sMacAddress == String.Empty)// only return MAC Address from first card  
            //    {
            //        //IPInterfaceProperties properties = adapter.GetIPProperties();
            //        sMacAddress = adapter.GetPhysicalAddress().ToString();
            //        IpWithMacAddress = ipaddress + "-" + sMacAddress;
            //    }
            //}
            //return IpWithMacAddress;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public string GetMacAddress(string ipAddress)
        {
            string macAddress = string.Empty;
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + ipAddress;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2)) + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6] + "-" + substrings[7] + "-" +
                        substrings[8].Substring(0, 2);
                return macAddress;
            }

            else
            {
                return "";
            }
        }

        [HttpGet]
        [Route("GetServerDateTime")]
        public CommonMasterAuto GetServerDateTime()
        {
            CommonRepository _repository = new CommonRepository();
            return _repository.GetServerDateTime();
        }
    }
}
