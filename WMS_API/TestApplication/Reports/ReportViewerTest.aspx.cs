using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApplication.Reports
{
    public partial class ReportViewerTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //string reportId = Request.QueryString["id"].ToString();
                    //ReportParameter[] p = new ReportParameter[Request.QueryString.Count - 1];
                    //for (int i = 2; i <= Request.QueryString.Count; i++)
                    //{
                    //    if (Request.QueryString[Request.QueryString.AllKeys[i - 1].ToString()].ToString() != "undefined")
                    //        p.SetValue(new ReportParameter(Request.QueryString.AllKeys[i - 1].ToString(), Request.QueryString[Request.QueryString.AllKeys[i - 1].ToString()].ToString()), i - 2);
                    //    else
                    //        p.SetValue(new ReportParameter(Request.QueryString.AllKeys[i - 1].ToString(), ""), i - 2);

                    //}
                    int ParmCount = Request.QueryString.Count;
                    string reportId = Request.QueryString["id"].ToString();
                    ParmCount--;
                    if (Request.QueryString.AllKeys.Contains("ShowToolBox"))
                    {
                        reportViewer.ShowToolBar = Convert.ToBoolean(Request.QueryString["ShowToolBox"].ToString());
                        ParmCount--;
                    }
                    ReportParameter[] p = new ReportParameter[ParmCount];
                    int pi = 0;
                    string[] defaltparm = { "ShowToolBox", "id" };

                    for (int i = 0; i < Request.QueryString.Count; i++)
                    {
                        if (!defaltparm.Contains(Request.QueryString.AllKeys[i].ToString()))
                            if (Request.QueryString[Request.QueryString.AllKeys[i].ToString()].ToString() != "undefined")
                                p.SetValue(new ReportParameter(Request.QueryString.AllKeys[i].ToString(), Request.QueryString[Request.QueryString.AllKeys[i].ToString()].ToString()), pi++);
                            else
                                p.SetValue(new ReportParameter(Request.QueryString.AllKeys[i].ToString(), ""), pi++);
                    }

                    string reportServerUrl = ConfigurationManager.ConnectionStrings["ReportServerURL"].ToString();
                    string domain = ConfigurationManager.ConnectionStrings["rsDomain"].ToString();
                    string userName = ConfigurationManager.ConnectionStrings["rsUserName"].ToString();
                    string password = ConfigurationManager.ConnectionStrings["rsPassword"].ToString();
                    string reportPath = ConfigurationManager.ConnectionStrings["ReportPath"].ToString();


                    //reportViewer.ShowPrintButton = true;
                    reportViewer.ServerReport.ReportServerUrl = new Uri(reportServerUrl);
                    // reportViewer.ServerReport.Headers.Add("TokenID") = reportId;

                    if (reportId == "BillWiseTracking")
                    {
                        reportViewer.ShowToolBar = false;
                    }
                    if (reportId == "MultiLSPTracking")
                    {
                        reportViewer.ShowToolBar = false;
                    }





                    reportViewer.ServerReport.ReportServerCredentials = new ReportCredentials(userName, password, domain);
                    reportViewer.ServerReport.ReportPath = string.Format(reportPath, reportId);
                    reportViewer.ServerReport.SetParameters(p);

                    //S reportViewer.ServerReport.Render
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.ShowCredentialPrompts = false;
                    reportViewer.ServerReport.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class ReportCredentials : IReportServerCredentials
        {
            public ReportCredentials(string userName, string password, string domain)
            {
                UserName = userName;
                Password = password;
                Domain = domain;
            }

            public WindowsIdentity ImpersonationUser
            {
                get
                {
                    return null;
                }
            }

            public ICredentials NetworkCredentials
            {
                get
                {
                    return new NetworkCredential(UserName, Password, Domain);
                }
            }

            private string UserName { get; set; }
            private string Password { get; set; }
            private string Domain { get; set; }

            public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password, out string authority)
            {
                authCookie = null;
                userName = password = authority = null;
                return false;
            }
        }
    }
}