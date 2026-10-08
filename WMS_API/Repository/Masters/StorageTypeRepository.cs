using Entity.Masters;
using Librarys.Extenders;
using POM.Repository;
using POMS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Masters
{
    public class StorageTypeRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_INSERT_StorageType";
        const string _DropDown = "USP_StorageType_Dropdown";
        const string _Edit = "USP_EDIT_StorageType";
        const string _Search = "USP_StorageType_SEARCH";
        public string Insertobj(StorageType objItemMaster)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();



            SqlParameter Par1 = new SqlParameter("@StorageTypeSno", objItemMaster.StorageTypeSno);
            Par1.SqlDbType = SqlDbType.Int;
            Par1.Direction = ParameterDirection.InputOutput;
            sqlParameters.Add(Par1);

            SqlParameter Par2 = new SqlParameter("@TypeName", objItemMaster.TypeName);
            Par2.SqlDbType = SqlDbType.VarChar;
            Par2.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par2);

            SqlParameter Par3 = new SqlParameter("@TypeCode", objItemMaster.TypeCode);
            Par3.SqlDbType = SqlDbType.VarChar;
            Par3.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par3);

            SqlParameter Par4 = new SqlParameter("@CategorySno", objItemMaster.CategorySno);
            Par4.SqlDbType = SqlDbType.Int;
            Par4.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par4);

            SqlParameter Par6 = new SqlParameter("@Image", objItemMaster.Image);
            Par6.SqlDbType = SqlDbType.VarChar;
            Par6.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par6);

            SqlParameter Par5 = new SqlParameter("@UOMSno", objItemMaster.UOMSno);
            Par5.SqlDbType = SqlDbType.Int;
            Par5.Direction = ParameterDirection.Input; sqlParameters.Add(Par5);

            SqlParameter Par7 = new SqlParameter("@Length", objItemMaster.Length);
            Par7.SqlDbType = SqlDbType.Decimal;
            Par7.Direction = ParameterDirection.Input; sqlParameters.Add(Par7);

            SqlParameter Par8 = new SqlParameter("@Breadth", objItemMaster.Breadth);
            Par8.SqlDbType = SqlDbType.Decimal;
            Par8.Direction = ParameterDirection.Input; sqlParameters.Add(Par8);

            SqlParameter Par9 = new SqlParameter("@Height", objItemMaster.Height);
            Par9.SqlDbType = SqlDbType.Decimal;
            Par9.Direction = ParameterDirection.Input; sqlParameters.Add(Par9);

            SqlParameter Par10 = new SqlParameter("@Weight", objItemMaster.Weight);
            Par10.SqlDbType = SqlDbType.Decimal;
            Par10.Direction = ParameterDirection.Input; sqlParameters.Add(Par10);

            SqlParameter Par11 = new SqlParameter("@Description", objItemMaster.Description);
            Par11.SqlDbType = SqlDbType.VarChar;
            Par11.Direction = ParameterDirection.Input; sqlParameters.Add(Par11);

            SqlParameter Par12 = new SqlParameter("@Remarks", objItemMaster.Remarks);
            Par12.SqlDbType = SqlDbType.VarChar;
            Par12.Direction = ParameterDirection.Input; sqlParameters.Add(Par12);

            SqlParameter Par13 = new SqlParameter("@CreOpr", objItemMaster.CreOpr);
            Par13.SqlDbType = SqlDbType.VarChar;
            Par13.Direction = ParameterDirection.Input; sqlParameters.Add(Par13);

            SqlParameter Par14 = new SqlParameter("@CreDat", objItemMaster.CreDat);
            Par14.SqlDbType = SqlDbType.VarChar;
            Par14.Direction = ParameterDirection.Input; sqlParameters.Add(Par14);

            SqlParameter Par15 = new SqlParameter("@IPNumber", objItemMaster.IPNumber);
            Par15.SqlDbType = SqlDbType.VarChar;
            Par15.Direction = ParameterDirection.Input; sqlParameters.Add(Par15);

            SqlParameter Par16 = new SqlParameter("@ActionName", objItemMaster.ActionName);
            Par16.SqlDbType = SqlDbType.VarChar;
            Par16.Direction = ParameterDirection.Input; sqlParameters.Add(Par16);

            SqlParameter Par29 = new SqlParameter("@sts", objItemMaster.sts);
            Par29.SqlDbType = SqlDbType.Bit;
            Par29.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par29);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);
            string strMessage = ds.Tables[0].Rows[0][0].ToString();
            return strMessage;
        }
        public StorageTypeDropDown DropDownList()
        {

            StorageTypeDropDown objListofDropDown = new StorageTypeDropDown();
            List<SqlParameter> listofSqlParameter = new List<SqlParameter>();

            DataSet dataSet = MasterExecuteCommand(_DropDown, listofSqlParameter);
            DataTable dtBranch = new DataTable();
            objListofDropDown.ObjCategoryDropDown = dataSet.Tables[0].ToCollection<CategoryDropDown>();
            objListofDropDown.ObjUOMDropDown = dataSet.Tables[1].ToCollection<UOMDropDown>();

            return objListofDropDown;

        }

        public StorageType Edit(int StorageTypeSno)
        {
            StorageType objrole = new StorageType();
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramHolidaySno = new SqlParameter("@StorageTypeSno", StorageTypeSno);
            paramHolidaySno.SqlDbType = SqlDbType.Int;
            parameters.Add(paramHolidaySno);



            DataSet ds = MasterExecuteCommand(_Edit, parameters);
            objrole = ds.Tables[0].ToCollection<StorageType>().FirstOrDefault();
            return objrole;
        }

        public Tuple<List<StorageType>, int> Search(PageRequest pageRequest)
        {
            List<StorageType> StorageType = new List<StorageType>();
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
                    DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);

                    StorageType = dataSet.Tables[0].ToCollection<StorageType>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<StorageType>, int>(StorageType, recordCount);
        }
    }
}
