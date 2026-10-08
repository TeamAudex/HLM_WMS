using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POM.Entity;
using Librarys;
using Librarys.Extenders;



namespace POM.Repository
{
    public class MenuMasRepository : RepositoryBaseNew
    {
        const string _MenuList = "USP_GET_MENU_MAS_LIST";
        const string _MobileMenu = "USP_GET_MENU_MAS_Mobile";

        public List<MenuMas> GetMenuList(int RoleID)
        {
            List<MenuMas> MenuMas = new List<MenuMas>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@RoleID", RoleID));
            DataSet dataSet = ExecuteCommand(_MenuList, parameters);
            MenuMas = dataSet.Tables[0].ToCustomList<MenuMas>();
            return MenuMas;
        }
        public List<MenuMas> GetMenuListAutoComplete(int RoleID,string title)
        {
            List<MenuMas> MenuMas = new List<MenuMas>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition1", 1));
            parameters.Add(new SqlParameter("@RoleID", RoleID));
            parameters.Add(new SqlParameter("@title", title));
            DataSet dataSet = ExecuteCommand(_MenuList, parameters);
            MenuMas = dataSet.Tables[0].ToCustomList<MenuMas>();
            return MenuMas;
        }
        //public List<MenuMas> GetMobileMenu(int StoreSno, int UserSno)
        //{
        //    List<MenuMas> MenuMas = new List<MenuMas>();
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@StoreSno", StoreSno));
        //    parameters.Add(new SqlParameter("@UserSno", UserSno));
        //    DataSet dataSet = ExecuteCommand(_MobileMenu, parameters);
        //    MenuMas = dataSet.Tables[0].ToCustomList<MenuMas>();
        //    return MenuMas;
        //}

        public List<MenuMas> GetMobileMenu(int RoleID)
        {
            List<MenuMas> MenuMas = new List<MenuMas>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@RoleID", RoleID));
            DataSet dataSet = ExecuteCommand(_MobileMenu, parameters);
            MenuMas = dataSet.Tables[0].ToCustomList<MenuMas>();
            return MenuMas;
        }
    }
}
