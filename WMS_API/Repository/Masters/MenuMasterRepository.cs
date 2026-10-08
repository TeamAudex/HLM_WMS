using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using POMS.Entity;
using POM.Repository;
using Librarys;
using Librarys.Extenders;


namespace POMS.Repository
{
    public class MenuMasterRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_MENUMASTER_INSERT";
        public string MenuMasterInsert(MenuMaster objmenumaster)
        {
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            SqlParameter objMenuSno = new SqlParameter("@MenuSno", objmenumaster.MenuSno);
            objMenuSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(objMenuSno);

            SqlParameter objMenuName = new SqlParameter("@MenuName", objmenumaster.MenuName);
            objMenuName.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(objMenuName);

            SqlParameter objMenuDescription = new SqlParameter("@MenuDescription", objmenumaster.MenuDescription);
            objMenuDescription.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(objMenuDescription);

            SqlParameter objParentMenuSno = new SqlParameter("@ParentMenuSno", objmenumaster.ParentMenuSno);
            objParentMenuSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(objParentMenuSno);

            SqlParameter objMenuOrder = new SqlParameter("@MenuOrder", objmenumaster.MenuOrder);
            objMenuOrder.SqlDbType = SqlDbType.Int;
            sqlparams.Add(objMenuOrder);

            SqlParameter objURLPath = new SqlParameter("@URLPath", objmenumaster.URLPath);
            objURLPath.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(objURLPath);

            SqlParameter objMenuFlag = new SqlParameter("@MenuFlag", objmenumaster.MenuFlag);
            objMenuFlag.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(objMenuFlag);

            SqlParameter objIconCSSClass = new SqlParameter("@IconCSSClass", objmenumaster.IconCSSClass);
            objIconCSSClass.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(objIconCSSClass);

            SqlParameter objSts = new SqlParameter("@Sts", objmenumaster.Sts);
            objSts.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(objSts);

            DataSet ds = MasterExecuteCommand(_Insert, sqlparams);
            string result = ds.Tables[0].Rows[0][0].ToString();

            return result;

        }
         
        const string _Edit = "USP_MENUMASTER_EDIT";
        public List<MenuMaster> MenuMasterEdit(int MenuSno)
        {
            List<MenuMaster> objlist = new List<MenuMaster>();
            List<SqlParameter> objsqlparam = new List<SqlParameter>();
            objsqlparam.Add(new SqlParameter("@MenuSno", MenuSno));



            DataSet ds = MasterExecuteCommand(_Edit, objsqlparam);
            //DataRowCollection rows = ds.Tables[0].Rows;
            objlist = ds.Tables[0].ToCollection<MenuMaster>();
            return objlist;
        }

        const string _Search = "USP_MENUMASTER_SEARCH";
        public List<MenuMaster> MenuMasterSearch(PageRequest pageRequest)
        {
            List<MenuMaster> objMenu = new List<MenuMaster>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                objMenu = dataSet.Tables[0].ToCollection<MenuMaster>();
            }
            return objMenu;
        }

        const string _AutoComplete = "USP_MENUMASTER_AUTOCOMPLETE";
        public List<MenuMaster> AutoComplete(string TypeText)
        {
            List<MenuMaster> Obj = new List<MenuMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", TypeText));
            DataSet dataset = MasterExecuteCommand(_AutoComplete, parameters);
            DataTable DT = new DataTable();
            Obj = dataset.Tables[0].ToCollection<MenuMaster>();
            return Obj;
        }

    }


}
