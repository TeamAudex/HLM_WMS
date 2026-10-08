using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using POMS.Entity;
using POMS.Entity.Masters;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using System.Data;

namespace POMS.Repository.Masters
{
    public class VendorMasterRepository : RepositoryBaseNew
    {
        const string _AutoCompleteVendorMasterDiv = "AutoCompleteVendorMasterDiv";
        const string _AutoCompleteVendorMasterGrid1 = "VendorMaster_Grid_1_AutoComplete";
        const string _AutoCompleteVendorMasterGrid2 = "VendorMasterGrid_2_AutoComplete";
        const string _DropDownVendorMasterGrid2 = "DropDown_VendorMaster";
        const string _Insert_VendorMaster = "Insert_VendorMaster";
        const string _Edit_VendorMaster = "Edit_Vendor_Master";
        const string _Search_VendorMaster = "USP_VendorMaster_SearchPage";

        public VendorMasterdropdown DropDownVendorMasterDiv()
        {
            VendorMasterdropdown bra = new VendorMasterdropdown();
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet dataSet = MasterExecuteCommand(_DropDownVendorMasterGrid2, parameters);
            DataTable dtBranch = new DataTable();
            bra.objVendorDropDown = dataSet.Tables[0].ToCollection<VendorDropDown>();
            bra.objPaymentTypeDropdown = dataSet.Tables[1].ToCollection<PaymentTypeDropdown>();
            return bra;
        }
        //public List<VendorMasterDiv> AutoCompleteVendorMasterDiv(string AutoCount, string TypedValue)
        //{
        //    List<VendorMasterDiv> bra = new List<VendorMasterDiv>();
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@AutoCount", AutoCount));
        //    parameters.Add(new SqlParameter("@TypeText", TypedValue));
        //    DataSet dataSet = MasterExecuteCommand(_AutoCompleteVendorMasterDiv, parameters);
        //    DataTable dtBranch = new DataTable();
        //    bra = dataSet.Tables[0].ToCollection<VendorMasterDiv>();
        //    return bra;
        //}
        public List<VendorMasterGrid1> AutoComplete_VendorMasterFirstGird(string AutoCount, string TypedValue)
        {
            List<VendorMasterGrid1> bra = new List<VendorMasterGrid1>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AutoCount", AutoCount));
            parameters.Add(new SqlParameter("@TypeText", TypedValue));
            DataSet dataSet = MasterExecuteCommand(_AutoCompleteVendorMasterGrid1, parameters);
            DataTable dtBranch = new DataTable();
            bra = dataSet.Tables[0].ToCollection<VendorMasterGrid1>();
            return bra;
        }
        public List<VendorCategoryLevelMas> AutoCompleteVendorMasterSecondGird(string AutoCount, string TypeOfSno, string TypedValue)
        {
            List<VendorCategoryLevelMas> bra = new List<VendorCategoryLevelMas>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AutoCount", AutoCount));
            parameters.Add(new SqlParameter("@TypeSno", TypeOfSno));
            parameters.Add(new SqlParameter("@TypeText", TypedValue));
            DataSet dataSet = MasterExecuteCommand(_AutoCompleteVendorMasterGrid2, parameters);
            DataTable dtBranch = new DataTable();
            bra = dataSet.Tables[0].ToCollection<VendorCategoryLevelMas>();
            return bra;
        }

        public Tuple<List<VendorMasterDiv>, int> SearchPage_VendorMaster(PageRequest pageRequest)
        {
            List<VendorMasterDiv> objVendor = new List<VendorMasterDiv>();
            int recordCount = 0;
            if (pageRequest != null)
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();


                    parameters.Add(new SqlParameter("@TrnType", pageRequest.TrnType));
                    parameters.Add(new SqlParameter("@UserSno", pageRequest.UserSno));
                    parameters.Add(new SqlParameter("@PageSize", pageRequest.PageSize));
                    parameters.Add(new SqlParameter("@PageNumber", pageRequest.PageNumber));
                    parameters.Add(new SqlParameter("@SortColumn", pageRequest.SortColumn));
                    parameters.Add(new SqlParameter("@SortOrder", pageRequest.SortOrder));
                    parameters.Add(new SqlParameter("@DBColumnName", pageRequest.DBColumnName));
                    parameters.Add(new SqlParameter("@Query", pageRequest.Query));
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(_Search_VendorMaster, parameters, ref recordCount);

                    objVendor = dataSet.Tables[0].ToCollection<VendorMasterDiv>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<VendorMasterDiv>, int>(objVendor, recordCount);
        }

        public string Insert_VendorMaster(VendorMasterList objVendorMasterList)
        {

            List<SqlParameter> listOfSqlParameter = new List<SqlParameter>();

            SqlParameter objSqlParamVendorMasterSno = new SqlParameter("@VendorMasterSno", objVendorMasterList.vendorMasterDiv.VendorMasterSno);
            objSqlParamVendorMasterSno.SqlDbType = SqlDbType.Int;
            listOfSqlParameter.Add(objSqlParamVendorMasterSno);

            SqlParameter objSqlParamVendorTypeSno = new SqlParameter("@VendorTypeSno", objVendorMasterList.vendorMasterDiv.VendorTypeSno);
            objSqlParamVendorTypeSno.SqlDbType = SqlDbType.Int;
            listOfSqlParameter.Add(objSqlParamVendorTypeSno);

            SqlParameter objSqlParamVendorName = new SqlParameter("@VendorName", objVendorMasterList.vendorMasterDiv.VendorName);
            objSqlParamVendorName.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamVendorName);

            SqlParameter objSqlParamVendorSoftwareCode = new SqlParameter("@VendorSoftwareCode", objVendorMasterList.vendorMasterDiv.VendorSoftwareCode);
            objSqlParamVendorSoftwareCode.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamVendorSoftwareCode);

            SqlParameter objSqlParamRegistrationNo = new SqlParameter("@RegistrationNo", objVendorMasterList.vendorMasterDiv.RegistrationNo);
            objSqlParamRegistrationNo.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamRegistrationNo);

            SqlParameter objSqlParamPaymentTypeSno = new SqlParameter("@PaymentTypeSno", objVendorMasterList.vendorMasterDiv.PaymentTypeSno);
            objSqlParamPaymentTypeSno.SqlDbType = SqlDbType.Int;
            listOfSqlParameter.Add(objSqlParamPaymentTypeSno);

            SqlParameter objSqlParamCreditLimit = new SqlParameter("@CreditLimit", objVendorMasterList.vendorMasterDiv.CreditLimit);
            objSqlParamCreditLimit.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamCreditLimit);

            SqlParameter objSqlParamCreditDays = new SqlParameter("@CreditDays", objVendorMasterList.vendorMasterDiv.CreditDays);
            objSqlParamCreditDays.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamCreditDays);

            SqlParameter objSqlParamNameOfReport = new SqlParameter("@NameOfReport", objVendorMasterList.vendorMasterDiv.NameOfReport);
            objSqlParamNameOfReport.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamNameOfReport);

            SqlParameter objSqlParamPANNo = new SqlParameter("@PANNo", objVendorMasterList.vendorMasterDiv.PANNo);
            objSqlParamPANNo.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamPANNo);

            SqlParameter objSqlParamBlackList = new SqlParameter("@BlackList", objVendorMasterList.vendorMasterDiv.BlackList);
            objSqlParamBlackList.SqlDbType = SqlDbType.Bit;
            listOfSqlParameter.Add(objSqlParamBlackList);

            SqlParameter WithPincode = new SqlParameter("@WithPincode", objVendorMasterList.vendorMasterDiv.WithPincode);
            WithPincode.SqlDbType = SqlDbType.Bit;
            listOfSqlParameter.Add(WithPincode);

            SqlParameter objSqlParamEmailId = new SqlParameter("@EmailId", objVendorMasterList.vendorMasterDiv.EmailId);
            objSqlParamEmailId.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamEmailId);

            SqlParameter objSqlParamSts = new SqlParameter("@Sts", objVendorMasterList.vendorMasterDiv.Sts);
            objSqlParamSts.SqlDbType = SqlDbType.Bit;
            listOfSqlParameter.Add(objSqlParamSts);

            SqlParameter objSqlParamCreOpr = new SqlParameter("@CreOpr", objVendorMasterList.vendorMasterDiv.CreOpr);
            objSqlParamCreOpr.SqlDbType = SqlDbType.Int;
            listOfSqlParameter.Add(objSqlParamCreOpr);

            SqlParameter objSqlParamWebsite = new SqlParameter("@Website", objVendorMasterList.vendorMasterDiv.Website);
            objSqlParamWebsite.SqlDbType = SqlDbType.VarChar;
            listOfSqlParameter.Add(objSqlParamWebsite);

            SqlParameter objSqlParamIPNumber = new SqlParameter("@IPNumber", objVendorMasterList.vendorMasterDiv.IPNumber);
            objSqlParamIPNumber.SqlDbType = SqlDbType.NVarChar;
            listOfSqlParameter.Add(objSqlParamIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objVendorMasterList.vendorMasterDiv.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            listOfSqlParameter.Add(ActionName);


            SqlParameter paramsSbuSno = new SqlParameter("@SbuSno", objVendorMasterList.vendorMasterDiv.SbuSno);
            paramsSbuSno.SqlDbType = SqlDbType.Int;
            listOfSqlParameter.Add(paramsSbuSno);

            SqlParameter paramsServerIdSno = new SqlParameter("@ServerIdSno", objVendorMasterList.vendorMasterDiv.ServerIdSno);
            paramsServerIdSno.SqlDbType = SqlDbType.Int;
            listOfSqlParameter.Add(paramsServerIdSno);

            //SqlParameter objSqlParam_Grid_1 = new SqlParameter("@TempVendorMasterGrid_1", objVendorMasterList.objVendorMasterGrid1.ToDataTable<VendorMasterGrid1>());
            //objSqlParam_Grid_1.SqlDbType = SqlDbType.Structured;
            //listOfSqlParameter.Add(objSqlParam_Grid_1);

            SqlParameter objSqlParamForType_1 = new SqlParameter();
            objSqlParamForType_1.ParameterName = "@TempVendorMasterGrid_1";
            objSqlParamForType_1.SqlDbType = SqlDbType.Structured;
            objSqlParamForType_1.Value = objVendorMasterList.objVendorMasterGrid1.ToDataTable<VendorMasterGrid1>();
            objSqlParamForType_1.Direction = ParameterDirection.Input;
            listOfSqlParameter.Add(objSqlParamForType_1);

            //SqlParameter objSqlparam_VendorMastercATEGORY = new SqlParameter("@TempVendorMasterGrid_2", objVendorMasterList.objVendorCategoryLevelMas.ToDataTable<VendorCategoryLevelMas>());
            //objSqlparam_VendorMastercATEGORY.SqlDbType = SqlDbType.Structured;
            //listOfSqlParameter.Add(objSqlparam_VendorMastercATEGORY);

            SqlParameter objSqlParamForType_2 = new SqlParameter();
            objSqlParamForType_2.ParameterName = "@TempVendorMasterGrid_2";
            objSqlParamForType_2.SqlDbType = SqlDbType.Structured;
            objSqlParamForType_2.Value = objVendorMasterList.objVendorCategoryLevelMas.ToDataTable<VendorCategoryLevelMas>();
            objSqlParamForType_2.Direction = ParameterDirection.Input;
            listOfSqlParameter.Add(objSqlParamForType_2);

            SqlParameter objSqlParamForType_3 = new SqlParameter();
            objSqlParamForType_3.ParameterName = "@TempVendorMasterGrid_3";
            objSqlParamForType_3.SqlDbType = SqlDbType.Structured;
            objSqlParamForType_3.Value = objVendorMasterList.objGridElements.ToDataTable<VendorMasterGrid3>();
            objSqlParamForType_3.Direction = ParameterDirection.Input;
            listOfSqlParameter.Add(objSqlParamForType_3);


            DataSet ds = MasterExecuteCommand(_Insert_VendorMaster, listOfSqlParameter);
            string result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public VendorMasterList Edit_VendorMaster(int VendorMasterSno)
        {
            SqlParameter paramActionID = new SqlParameter("@VendorMasterSno", VendorMasterSno);
            SqlCommand sqlCmd = new SqlCommand(_Edit_VendorMaster);
            SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(paramActionID);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            VendorMasterList objVendorMasterList = new VendorMasterList();
            objVendorMasterList.vendorMasterDiv = new VendorMasterDiv();
            objVendorMasterList.objVendorMasterGrid1 = new List<VendorMasterGrid1>();
            objVendorMasterList.objVendorCategoryLevelMas = new List<VendorCategoryLevelMas>();
            objVendorMasterList.objGridElements = new List<VendorMasterGrid3>();

            DataSet dsVendorMasterList = new DataSet();
            DataTable dtVendorMasterDiv = new DataTable();
            DataTable dtVendorMasterGrid1 = new DataTable();
            DataTable dtVendorCategoryLevelMas = new DataTable();
            DataTable dtVendorMasterGrid3 = new DataTable();
            dsVendorMasterList.Tables.Add(dtVendorMasterDiv);
            dsVendorMasterList.Tables.Add(dtVendorMasterGrid1);
            dsVendorMasterList.Tables.Add(dtVendorCategoryLevelMas);
            dsVendorMasterList.Tables.Add(dtVendorMasterGrid3);
            dsVendorMasterList.Load(dataReader, LoadOption.OverwriteChanges, dtVendorMasterDiv, dtVendorMasterGrid1, dtVendorCategoryLevelMas, dtVendorMasterGrid3);
            objVendorMasterList.vendorMasterDiv = dsVendorMasterList.Tables[0].ToCustomList<VendorMasterDiv>().FirstOrDefault();
            objVendorMasterList.objVendorMasterGrid1 = dsVendorMasterList.Tables[1].ToCollection<VendorMasterGrid1>();
            objVendorMasterList.objVendorCategoryLevelMas = dsVendorMasterList.Tables[2].ToCollection<VendorCategoryLevelMas>();
            objVendorMasterList.objGridElements = dsVendorMasterList.Tables[3].ToCollection<VendorMasterGrid3>();
            return objVendorMasterList;
        }
    }
}
