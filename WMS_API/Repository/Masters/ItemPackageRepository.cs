using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POM.Entity;
using POM.Repository;
using Librarys;
using Librarys.Extenders;
using POMS.Entity;

namespace POMS.Repository
{
   public class ItemPackageRepository : RepositoryBaseNew
    {
        const string _ItemPackage_Insert = "USP_INSERT_ITEM_PACKAGE";
        const string _ItemPackage_select = "USP_GET_ITEM_PACKAGE";
        const string _ItemPackage_Edit = "USP_EDIT_ITEM_PACKAGE";
        const string _get_AutoComplete = "USP_ITEM_PACKAGE_AUTOCOMPLETE";
        const string  _DropDown = "USP_ITEM_PACKAGE_DROPDOWN";
        const string _get_Volume = "USP_GET_VOLUME";
        const string _get_Volumetric_Weight = "USP_GET_VOLUMETRIC_WEIGHT";
        public ItemPackageDetails ItemPackageEdit(int ItemPackageSno)
        {

            SqlParameter paramActionID = new SqlParameter("@ItemPackageSno", ItemPackageSno);
            SqlCommand sqlCmd = new SqlCommand(_ItemPackage_Edit);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            ItemPackageDetails ItemPackageDetails = new ItemPackageDetails();
            ItemPackageDetails.ItemPackage = new ItemPackage();
            ItemPackageDetails.ItemPackageDet = new List<ItemPackageDet>();

            DataSet dsItemPackageDetails = new DataSet();
            DataTable dtItemPackage = new DataTable();
            DataTable dtItemPackageDet = new DataTable();
            dsItemPackageDetails.Tables.Add(dtItemPackage);
            dsItemPackageDetails.Tables.Add(dtItemPackageDet);
            dsItemPackageDetails.Load(dataReader, LoadOption.OverwriteChanges, dtItemPackage, dtItemPackageDet);
            ItemPackageDetails.ItemPackage = dsItemPackageDetails.Tables[0].ToCustomList<ItemPackage>().FirstOrDefault();
            ItemPackageDetails.ItemPackageDet = dsItemPackageDetails.Tables[1].ToCollection<ItemPackageDet>();
            return ItemPackageDetails;
        }

        public Tuple<List<ItemPackage>,int> ItemPackageSearch(PageRequest pageRequest)
        {
            List<ItemPackage> ItemPackage = new List<ItemPackage>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                    parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                    parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                    parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                    parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                    parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                    parameters.Add(new SqlParameter("@UserSno", pageRequest.UserSno));
                    parameters.Add(new SqlParameter("@TrnType", pageRequest.TrnType));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(_ItemPackage_select, parameters, ref recordCount);

                    ItemPackage = dataSet.Tables[0].ToCollection<ItemPackage>();
                }
                catch (Exception ee) { }
            }
           
            return new Tuple<List<ItemPackage>, int>(ItemPackage, recordCount);
        }
        public string InsertItemPackage(ItemPackageDetails objItemPackage)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter paramItemPackageSno = new SqlParameter("@ItemPackageSno", objItemPackage.ItemPackage.ItemPackageSno);
            paramItemPackageSno.SqlDbType = SqlDbType.Int;
            paramItemPackageSno.Direction = ParameterDirection.InputOutput;
            sqlParameters.Add(paramItemPackageSno);

            SqlParameter paramItemSno = new SqlParameter("@ItemSno", objItemPackage.ItemPackage.ItemSno);
            paramItemSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramItemSno);

            //SqlParameter paramItemUOM = new SqlParameter("@ItemUOM", objItemPackage.ItemPackage.ItemUOM);
            //paramItemUOM.SqlDbType = SqlDbType.NVarChar;
            //sqlParameters.Add(paramItemUOM);

            //SqlParameter paramItemWeight = new SqlParameter("@ItemWeight", objItemPackage.ItemPackage.ItemWeight);
            //paramItemWeight.SqlDbType = SqlDbType.Decimal;
            //sqlParameters.Add(paramItemWeight);


            SqlParameter paramCreopr = new SqlParameter("@Creopr", objItemPackage.ItemPackage.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter paramSts = new SqlParameter("@Sts", objItemPackage.ItemPackage.Sts);
            paramSts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(paramSts);

            SqlParameter paramIPNumber = new SqlParameter("@IpNumber", objItemPackage.ItemPackage.IPNumber);
            paramIPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(paramIPNumber);

            SqlParameter paramActionName = new SqlParameter("@ActionName", objItemPackage.ItemPackage.ActionName);
            paramActionName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(paramActionName);

            SqlParameter paramItemPackageDet = new SqlParameter();
            paramItemPackageDet.ParameterName = "@ItemPackageDet";
            paramItemPackageDet.SqlDbType = SqlDbType.Structured;
            paramItemPackageDet.Value = objItemPackage.ItemPackageDet.ToDataTable<ItemPackageDet>();
            paramItemPackageDet.Direction = ParameterDirection.Input;
            sqlParameters.Add(paramItemPackageDet);
            
            DataSet ds = MasterExecuteCommand(_ItemPackage_Insert, sqlParameters);
            string strMessage = ds.Tables[0].Rows[0][0].ToString();
            return strMessage;
        }

        public List<ItemPackage> GetAutoComplete(string Condition)
        {
            List<ItemPackage> objautoComplete = new List<ItemPackage>();
            //List<SqlParameter> parameters = new List<SqlParameter>();
           // parameters.Add(new SqlParameter("@Condition", Condition));
           // DataSet dataSet = MasterExecuteCommand(_get_AutoComplete, parameters);
           // DataTable dtRefNo = new DataTable();
           // objautoComplete = dataSet.Tables[0].ToCollection<ItemPackage>();
            return objautoComplete;
        }

        public List<ItemPackageDet> FetchVolume(int Condition,decimal Condition1, decimal Condition2, decimal Condition3)
        {
            List<ItemPackageDet> ItemPackageDet = new List<ItemPackageDet>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", Condition));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            parameters.Add(new SqlParameter("@Condition2", Condition2));
            parameters.Add(new SqlParameter("@Condition3", Condition3));
            DataSet dataSet = MasterExecuteCommand(_get_Volume, parameters);
            DataTable dtRefNo = new DataTable();
            ItemPackageDet = dataSet.Tables[0].ToCollection<ItemPackageDet>();
            return ItemPackageDet;
        }


        public List<ItemPackageDet> FetchVolumetricWeight(int Condition, decimal Condition1, decimal Condition2, decimal Condition3, int Condition4)
        {
            List<ItemPackageDet> ItemPackageDet = new List<ItemPackageDet>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", Condition));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            parameters.Add(new SqlParameter("@Condition2", Condition2));
            parameters.Add(new SqlParameter("@Condition3", Condition3));
            parameters.Add(new SqlParameter("@Condition4", Condition4));
            DataSet dataSet = MasterExecuteCommand(_get_Volumetric_Weight, parameters);
            DataTable dtRefNo = new DataTable();
            ItemPackageDet = dataSet.Tables[0].ToCollection<ItemPackageDet>();
            return ItemPackageDet;
        }

        public ItemPackageDropDown DropDownList()
        {

            ItemPackageDropDown objListofDropDown_ItemPackage = new ItemPackageDropDown();
            List<SqlParameter> listofSqlParameter = new List<SqlParameter>();

            DataSet dataSet = MasterExecuteCommand(_DropDown, listofSqlParameter);
            DataTable dtBranch = new DataTable();
            objListofDropDown_ItemPackage.PackageUOMDropdownList = dataSet.Tables[0].ToCollection<PackageUOMDropdownList>();
            objListofDropDown_ItemPackage.UOMDropdownList = dataSet.Tables[1].ToCollection<UOMDropdownList>();
            objListofDropDown_ItemPackage.VolumetricFactorList = dataSet.Tables[2].ToCollection<VolumetricFactorList>();

            return objListofDropDown_ItemPackage;

        }
    }
}
