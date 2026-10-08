using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POM.Repository;
using System.Data.SqlClient;
using System.Data;
using Librarys;
using Librarys.Extenders;
using POMS.Entity;

namespace POMS.Repository.Masters
{
    public class CustomerRepository:RepositoryBaseNew
    {
        const string _InsertCustomer= "USP_INSERT_CUSTOMER";
        public string InsertCustomer(CustomerGrid objCustomerGrid)
        {
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paramsCustomerSno = new SqlParameter("@CustomerSno", objCustomerGrid.objCustomer.CustomerSno);
            paramsCustomerSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsCustomerSno);

            SqlParameter paramsCustomerCode = new SqlParameter("@CustomerCode ", objCustomerGrid.objCustomer.CustomerCode);
            paramsCustomerCode.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsCustomerCode);

            SqlParameter paramsCustomerName = new SqlParameter("@CustomerName", objCustomerGrid.objCustomer.CustomerName);
            paramsCustomerName.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsCustomerName);

            SqlParameter paramsCustomerGroupSno = new SqlParameter("@CustomerGroup", objCustomerGrid.objCustomer.CustomerGroupSno);
            paramsCustomerGroupSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsCustomerGroupSno);

            //SqlParameter paramsCustomerGroup = new SqlParameter("@CustomerGroup", objCustomerGrid.objCustomer.CustomerGroup);
            //paramsCustomerGroup.SqlDbType = SqlDbType.NVarChar;
            //sqlparams.Add(paramsCustomerGroup);

            SqlParameter paramsRegistrationNumber = new SqlParameter("@RegNo", objCustomerGrid.objCustomer.RegistrationNumber);
            paramsRegistrationNumber.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsRegistrationNumber);

            SqlParameter paramsCustomerSoftwareCode = new SqlParameter("@SoftwareCode", objCustomerGrid.objCustomer.CustomerSoftwareCode);
            paramsCustomerSoftwareCode.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsCustomerSoftwareCode);

            SqlParameter paramsPaymentDetailsSno = new SqlParameter("@PaymentDetails", objCustomerGrid.objCustomer.PaymentDetailsSno);
            paramsPaymentDetailsSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsPaymentDetailsSno);

            //SqlParameter paramsPaymentDetails = new SqlParameter("@PaymentDetails", objCustomerGrid.objCustomer.PaymentDetails);
            //paramsPaymentDetails.SqlDbType = SqlDbType.NVarChar;
            //sqlparams.Add(paramsPaymentDetails);

            SqlParameter paramsCreditLimitAmountSno = new SqlParameter("@CurrencySno", objCustomerGrid.objCustomer.CreditLimitAmountSno);
            paramsCreditLimitAmountSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsCreditLimitAmountSno);

            //SqlParameter paramsCreditLimitAmounttype = new SqlParameter("@CreditLimitAmounttype", objCustomerGrid.objCustomer.CreditLimitAmounttype);
            //paramsCreditLimitAmounttype.SqlDbType = SqlDbType.NVarChar;
            //sqlparams.Add(paramsCreditLimitAmounttype);

            SqlParameter paramsCreditLimitAmount = new SqlParameter("@CreditLimitAmount", objCustomerGrid.objCustomer.CreditLimitAmount);
            paramsCreditLimitAmount.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsCreditLimitAmount);

            SqlParameter paramsCreditLimitDays = new SqlParameter("@CreditDays", objCustomerGrid.objCustomer.CreditLimitDays);
            paramsCreditLimitDays.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsCreditLimitDays);

            SqlParameter paramsNameInTheReport = new SqlParameter("@NameReport", objCustomerGrid.objCustomer.NameInTheReport);
            paramsNameInTheReport.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsNameInTheReport);

            SqlParameter paramsPANNumber = new SqlParameter("@PANNo ", objCustomerGrid.objCustomer.PANNumber);
            paramsPANNumber.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsPANNumber);

            SqlParameter paramsEmailID = new SqlParameter("@MailId", objCustomerGrid.objCustomer.EmailID);
            paramsEmailID.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsEmailID);

            SqlParameter paramsWebsite = new SqlParameter("@Website", objCustomerGrid.objCustomer.Website);
            paramsWebsite.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsWebsite);

            SqlParameter paramsBlocksts = new SqlParameter("@BlockList", objCustomerGrid.objCustomer.Blocksts);
            paramsBlocksts.SqlDbType = SqlDbType.Bit;
            sqlparams.Add(paramsBlocksts);

            SqlParameter paramsCreOpr = new SqlParameter("@CreOpr", objCustomerGrid.objCustomer.CreOpr);
            paramsCreOpr.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsCreOpr);

            SqlParameter paramsIPNumber = new SqlParameter("@IPNumber", objCustomerGrid.objCustomer.IPNumber);
            paramsIPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objCustomerGrid.objCustomer.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(ActionName);

            SqlParameter paramsCreDat = new SqlParameter("@CreDat", objCustomerGrid.objCustomer.CreDat);
            paramsCreDat.SqlDbType = SqlDbType.NVarChar;
            sqlparams.Add(paramsCreDat);

            SqlParameter paramsSts = new SqlParameter("@sts", objCustomerGrid.objCustomer.sts);
            paramsSts.SqlDbType = SqlDbType.Bit;
            sqlparams.Add(paramsSts);

            SqlParameter paramsSbuSno = new SqlParameter("@SbuSno", objCustomerGrid.objCustomer.SbuSno);
            paramsSbuSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsSbuSno);

            SqlParameter paramsServerIdSno = new SqlParameter("@ServerIdSno", objCustomerGrid.objCustomer.ServerIdSno);
            paramsServerIdSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsServerIdSno);


            SqlParameter paramsTypes = new SqlParameter("@Types", objCustomerGrid.objCustomer.Types);
            paramsTypes.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsTypes);


            SqlParameter ParamsCustomerDet = new SqlParameter(); 
            ParamsCustomerDet.ParameterName = "@CustomerDettype";
            ParamsCustomerDet.SqlDbType = SqlDbType.Structured;
            ParamsCustomerDet.Value = objCustomerGrid.objCustomerDet.ToDataTable<CustomerDet>();
            ParamsCustomerDet.Direction = ParameterDirection.Input;
            sqlparams.Add(ParamsCustomerDet);



            SqlParameter ParamsbranchDet = new SqlParameter();
            ParamsbranchDet.ParameterName ="@cusBudet";
            ParamsbranchDet.SqlDbType = SqlDbType.Structured;
            ParamsbranchDet.Value = objCustomerGrid.objBisnussdet.ToDataTable<Bisnussdet>();
            ParamsbranchDet.Direction = ParameterDirection.Input;
            sqlparams.Add(ParamsbranchDet);

            DataSet ds = MasterExecuteCommand(_InsertCustomer, sqlparams);
            string Result = ds.Tables[0].Rows[0][0].ToString();

            return Result;

        }

        const string _AutocompleteCustomer = "USP_AUTOCOMPLETE_CUSTOMER";
        public  List<CustomerDet> CustomerAutoComplete(string Condition)
        {
            List<CustomerDet> objAutocomplete = new List<CustomerDet>();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            sqlparams.Add(new SqlParameter("@Condition", Condition));

            DataSet ds = MasterExecuteCommand(_AutocompleteCustomer, sqlparams);
            objAutocomplete = ds.Tables[0].ToCollection<CustomerDet>();
            return objAutocomplete;
        }

        const string _dropDownCustomerGroup = "USP_DROPDOWN_CUSTOMERGROUP";
        public  dropdownList1 CustomerGroupDropDown()
        {
            dropdownList1 objdrop = new dropdownList1();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_dropDownCustomerGroup, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop.objCustomerGroupDropdown = ds.Tables[0].ToCollection<CustomerGroupDropdown>();
            return objdrop;
        }

        const string _dropDownCustomerPayment = "USP_DROPDOWN_CUSTOMERPAYMENT";
        public dropdownList2 CustomerPaymentDropdown()
        {
            dropdownList2 objdrop1 = new dropdownList2();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_dropDownCustomerPayment, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop1.objCustomerPaymentDropdown = ds.Tables[0].ToCollection<CustomerPaymentDropdown>();
            return objdrop1;
        }

        const string _dropDownCustomerCredit = "USP_DROPDOWN_CUSTOMERCREDIT";
        public dropdownList3 CustomerCreditAmountDropdown()
        {
            dropdownList3 objdrop2 = new dropdownList3();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_dropDownCustomerCredit, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop2.objCustomerCreditAmountDropdown = ds.Tables[0].ToCollection<CustomerCreditAmountDropdown>();
            return objdrop2;
        }

        const string _TypeDropdown = "USP_DROPDOWN_CUSTOMERADDRESS"; 
        public dropdownList4 CustomerAddressTypeDropdown()
        {
            dropdownList4 objdrop3 = new dropdownList4();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_TypeDropdown, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop3.objCustomerAddressTypeDropdown = ds.Tables[0].ToCollection<CustomerAddressTypeDropdown>();
            return objdrop3;
        }





        const string _dropDownCustomerAddress = "EntityTypeDropdown";
        public dropdownList5 objTypeDropdown()
        {
            dropdownList5 objdrop5 = new dropdownList5();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_dropDownCustomerAddress, sqlparams);
            DataTable dtBranch = new DataTable();
            objdrop5.objTypeDropdown = ds.Tables[0].ToCollection<typedropdown>();
            return objdrop5;
        }


        const string _EditCustomer = "USP_EDIT_CUSTOMER";
        public CustomerGrid EditCustomer(int CustomerSno)
        {

            List<SqlParameter> sqlparams = new List<SqlParameter>();

            SqlParameter paramsCustomerSno = new SqlParameter("@CustomerSno", CustomerSno);
            paramsCustomerSno.SqlDbType = SqlDbType.Int;
            sqlparams.Add(paramsCustomerSno);
          
            CustomerGrid objCustomerGrid = new CustomerGrid();

            DataSet ds = MasterExecuteCommand(_EditCustomer, sqlparams);

            try
            {
                objCustomerGrid.objCustomer = ds.Tables[0].ToCustomList<Customer>().FirstOrDefault();
                objCustomerGrid.objCustomerDet = ds.Tables[1].ToCustomList<CustomerDet>();
                objCustomerGrid.objBisnussdet = ds.Tables[2].ToCustomList<Bisnussdet>();
            }
            catch(Exception ex)
            {

            }
            return objCustomerGrid;
            
        }

        const string _SearchBudget = "USP_SEARCH_CUSTOMER";
        public Tuple<List<Customer>, int> SearchCustomer(PageRequest pageRequest)
        {
            List<Customer> objCustomer = new List<Customer>();
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
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(_SearchBudget, parameters, ref recordCount);

                    objCustomer = dataSet.Tables[0].ToCollection<Customer>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<Customer>, int>(objCustomer, recordCount);
        }
    }
    }

