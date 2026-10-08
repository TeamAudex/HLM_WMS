using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Repository
{
    public class DataAccess
    {
        //Get Data Base connection from Web Config file for the DBSERVER
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        public DataAccess()
        {
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}
            //if (con1.State == ConnectionState.Open)
            //{
            //    con1.Close();
            //}
        }

    }
}
