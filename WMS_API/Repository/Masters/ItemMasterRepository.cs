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
using POMS.Entity.Masters;

namespace POMS.Repository
{
    public class ItemMasterRepository : RepositoryBaseNew
    {
        const string _ItemMaster_Insert = "USP_INSERT_ITEMMASTER";
        const string _ItemMaster_Edit = "USP_EDIT_ITEMMASTER";
        const string _ItemMaster_select = "USP_RST_ITEMMASTER_SELECT";
        const string _get_autocomplete_ = "USP_AUTOCOMPLETE_ITEMMASTER";

        public List<ItemMaster> GetItemMaster(int ItemMasterSno)
        {
            List<ItemMaster> objrole = new List<ItemMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ItemMasterSno", ItemMasterSno));

            DataSet ds = MasterExecuteCommand(_ItemMaster_Edit, parameters);
            objrole = ds.Tables[0].ToCustomList<ItemMaster>();
            return objrole;
        }

        public string InsertobjItemMaster(ItemMaster objItemMaster)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();



            SqlParameter Par1 = new SqlParameter("@ItemSno", objItemMaster.ItemMasterSno);
            Par1.SqlDbType = SqlDbType.Int;
            Par1.Direction = ParameterDirection.InputOutput;
            sqlParameters.Add(Par1);

            SqlParameter Par2 = new SqlParameter("@BrandName", objItemMaster.BrandName);
            Par2.SqlDbType = SqlDbType.VarChar;
            Par2.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par2);

            SqlParameter Par3 = new SqlParameter("@ItemName", objItemMaster.ItemName);
            Par3.SqlDbType = SqlDbType.VarChar;
            Par3.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par3);

            SqlParameter Par4 = new SqlParameter("@ItemCode", objItemMaster.ItemCode);
            Par4.SqlDbType = SqlDbType.VarChar;
            Par4.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par4);

            SqlParameter Par5 = new SqlParameter("@ItemCommoditySno", objItemMaster.ItemCommoditySno);
            Par5.SqlDbType = SqlDbType.Int;
            Par5.Direction = ParameterDirection.Input; sqlParameters.Add(Par5);

            SqlParameter Par6 = new SqlParameter("@ItemCategorySno", objItemMaster.ItemCategorySno);
            Par6.SqlDbType = SqlDbType.Int;
            Par6.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par6);

            SqlParameter Par7 = new SqlParameter("@StoreUOMSno", objItemMaster.StoreUOMSno);
            Par7.SqlDbType = SqlDbType.Int;
            Par7.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par7);

            //SqlParameter Par8 = new SqlParameter("@RotationSno", objItemMaster.RotationSno);
            //Par8.SqlDbType = SqlDbType.Int;
            //Par8.Direction = ParameterDirection.Input;
            //sqlParameters.Add(Par8);

            SqlParameter Par9 = new SqlParameter("@lbhUOMSno", objItemMaster.lbhUOMSno);
            Par9.SqlDbType = SqlDbType.Int;
            Par9.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par9);

            SqlParameter Par10 = new SqlParameter("@WeightUOMSno", objItemMaster.WeightUOMSno);
            Par10.SqlDbType = SqlDbType.Int;
            Par10.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par10);

            SqlParameter Par11 = new SqlParameter("@MovementSno", objItemMaster.MovementSno);
            Par11.SqlDbType = SqlDbType.Int;
            Par11.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par11);

            SqlParameter Par12 = new SqlParameter("@ValueSno", objItemMaster.ValueSno);
            Par12.SqlDbType = SqlDbType.Int;
            Par12.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par12);

            SqlParameter Par13 = new SqlParameter("@NeedSno", objItemMaster.NeedSno);
            Par13.SqlDbType = SqlDbType.Int;
            Par13.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par13);

            SqlParameter Par14 = new SqlParameter("@ItemDetails", objItemMaster.ItemDetails);
            Par14.SqlDbType = SqlDbType.VarChar;
            Par14.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par14);

            SqlParameter Par15 = new SqlParameter("@Remarks", objItemMaster.Remarks);
            Par15.SqlDbType = SqlDbType.VarChar;
            Par15.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par15);

            SqlParameter Par16 = new SqlParameter("@Length", objItemMaster.Length);
            Par16.SqlDbType = SqlDbType.VarChar;
            Par16.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par16);

            SqlParameter Par17 = new SqlParameter("@Breadth", objItemMaster.Breadth);
            Par17.SqlDbType = SqlDbType.VarChar;
            Par17.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par17);

            SqlParameter Par18 = new SqlParameter("@Height", objItemMaster.Height);
            Par18.SqlDbType = SqlDbType.VarChar;
            Par18.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par18);

            SqlParameter Par19 = new SqlParameter("@Weight", objItemMaster.Weight);
            Par19.SqlDbType = SqlDbType.VarChar;
            Par19.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par19);

            SqlParameter Par20 = new SqlParameter("@Rate", objItemMaster.Rate);
            Par20.SqlDbType = SqlDbType.VarChar;
            Par20.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par20);

            SqlParameter Par21 = new SqlParameter("@Volume", objItemMaster.Volume);
            Par21.SqlDbType = SqlDbType.VarChar;
            Par21.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par21);

            SqlParameter Par22 = new SqlParameter("@CreOpr", objItemMaster.CreOpr);
            Par22.SqlDbType = SqlDbType.Int;
            Par22.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par22);

            //SqlParameter Par23 = new SqlParameter("@CreDat", objItemMaster.CreDat);
            //Par23.SqlDbType = SqlDbType.VarChar;
            //Par23.Direction = ParameterDirection.Input;
            //sqlParameters.Add(Par23);

            SqlParameter Par24 = new SqlParameter("@IPNumber", objItemMaster.IPNumber);
            Par24.SqlDbType = SqlDbType.NVarChar;
            Par24.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par24);

            SqlParameter Par25 = new SqlParameter("@sts", objItemMaster.sts);
            Par25.SqlDbType = SqlDbType.Bit;
            Par25.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par25);

            SqlParameter Par26 = new SqlParameter("@Documentpath", objItemMaster.Documentpath);
            Par26.SqlDbType = SqlDbType.NVarChar;
            Par26.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par26);


            //SqlParameter Par27 = new SqlParameter("@BusinessUnitSno", objItemMaster.BusinessUnitSno);
            //Par27.SqlDbType = SqlDbType.Int;
            //Par27.Direction = ParameterDirection.Input;
            //sqlParameters.Add(Par27);

            SqlParameter Par28 = new SqlParameter("@ActionName", objItemMaster.ActionName);
            Par28.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(Par28);


            SqlParameter Par29 = new SqlParameter("@HeightcanDown", objItemMaster.HeightcanDown);
            Par29.SqlDbType = SqlDbType.Bit;
            Par29.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par29);

            SqlParameter Par30 = new SqlParameter("@WidthcanUp", objItemMaster.WidthcanUp);
            Par30.SqlDbType = SqlDbType.Bit;
            Par30.Direction = ParameterDirection.Input;
            sqlParameters.Add(Par30);

            DataSet ds = MasterExecuteCommand(_ItemMaster_Insert, sqlParameters);
            string strMessage = ds.Tables[0].Rows[0][0].ToString();
            return strMessage;
        }

        const string _USP_Volume_Calculation = "USP_Volume_Calculation";
        public string VolumeCalculation(decimal Length, decimal Breadth, decimal Height, int UOV)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Length", Length));
            parameters.Add(new SqlParameter("@Breadth", Breadth));
            parameters.Add(new SqlParameter("@Height", Height));
            parameters.Add(new SqlParameter("@UOVSno", UOV));
            DataSet dataSet = MasterExecuteCommand(_USP_Volume_Calculation, parameters);
            DataTable dtBranch = new DataTable();
            string result = dataSet.Tables[0].Rows[0][0].ToString();
            return result;
        }
        public Tuple<List<ItemMaster>, int> GetItemMasterDetails(PageRequest pageRequest)
        {
            List<ItemMaster> ItemMaster = new List<ItemMaster>();
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
                parameters.Add(new SqlParameter("@UserSno", pageRequest.UserSno));
                parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                DataSet dataSet = MasterExecuteCommand(_ItemMaster_select, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                ItemMaster = dataSet.Tables[0].ToCollection<ItemMaster>();
            }
            return new Tuple<List<ItemMaster>, int>(ItemMaster, recordCount);

        }


        public List<ItemMaster> GetItemMasterAutoComplete(string Condition, int Condition1, int Condition2)
        {
            List<ItemMaster> objautoComplete = new List<ItemMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", Condition));
            parameters.Add(new SqlParameter("@Condition1", Condition1));
            parameters.Add(new SqlParameter("@Condition2", Condition2));
            DataSet dataSet = MasterExecuteCommand(_get_autocomplete_, parameters);
            objautoComplete = dataSet.Tables[0].ToCollection<ItemMaster>();
            return objautoComplete;
        }

        const string _ItemCategoryDropdown = "USP_ItemCategoryDropdown";
        public ItemCategoryDropdownList ItemCategoryDropdown()
        {
            ItemCategoryDropdownList objdrop = new ItemCategoryDropdownList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_ItemCategoryDropdown, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objItemCategoryDropdown = ds.Tables[0].ToCollection<ItemCategoryDropdown>();
            return objdrop;
        }

        //const string _RotationDropdown = "USP_RotationDropdown";
        //public RotationDropdownList RotationDropdown()
        //{
        //    RotationDropdownList objdrop = new RotationDropdownList();
        //    List<SqlParameter> sqlparams = new List<SqlParameter>();
        //    DataSet ds = MasterExecuteCommand(_RotationDropdown, sqlparams);
        //    DataTable dtBranch = new DataTable();
        //    objdrop.objRotationDropdown = ds.Tables[0].ToCollection<RotationDropdown>();
        //    return objdrop;
        //}

        const string _WeightUOMDropdown = "USP_WeightUOMDropdown";
        public WeightUOMDropdownList WeightUOMDropdown()
        {
            WeightUOMDropdownList objdrop = new WeightUOMDropdownList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_WeightUOMDropdown, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objWeightUOMDropdown = ds.Tables[0].ToCollection<WeightUOMDropdown>();
            return objdrop;
        }

        const string _MovementDropdown = "USP_MovementDropdown";
        public MovementDropdownList MovementDropdown()
        {
            MovementDropdownList objdrop = new MovementDropdownList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_MovementDropdown, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objMovementDropdown = ds.Tables[0].ToCollection<MovementDropdown>();
            return objdrop;
        }

        const string _ValueDropdown = "USP_ValueDropdown";
        public ValueDropdownList ValueDropdown()
        {
            ValueDropdownList objdrop = new ValueDropdownList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_ValueDropdown, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objValueDropdown = ds.Tables[0].ToCollection<ValueDropdown>();
            return objdrop;
        }

        const string _NeedDropdown = "USP_NeedDropdown";
        public NeedDropdownList NeedDropdown()
        {
            NeedDropdownList objdrop = new NeedDropdownList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_NeedDropdown, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objNeedDropdown = ds.Tables[0].ToCollection<NeedDropdown>();
            return objdrop;
        }

        const string _lbhUOMDropdown = "USP_lbhUOMDropdown";
        public lbhUOMDropdownList lbhUOMDropdown()
        {
            lbhUOMDropdownList objdrop = new lbhUOMDropdownList();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_lbhUOMDropdown, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objlbhUOMDropdown = ds.Tables[0].ToCollection<lbhUOMDropdown>();
            return objdrop;
        }
        //const string _BusinessUnitAUTO = "USP_BUSNESS_Auto";
        //public List<ItemMaster> GetBussinessAuto(string Condition, int Condition1, int Condition2 )
        //{
        //    List<ItemMaster> objautoCompletes = new List<ItemMaster>();
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Condition", Condition));
        //    parameters.Add(new SqlParameter("@Condition1", Condition1));
        //    parameters.Add(new SqlParameter("@Condition2", Condition2));
        //    DataSet dataSet = MasterExecuteCommand(_BusinessUnitAUTO, parameters);
        //    objautoCompletes = dataSet.Tables[0].ToCollection<ItemMaster>();
        //    return objautoCompletes;
        //}
    }
}

