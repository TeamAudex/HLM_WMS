
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POMS.Entity;
using POM.Repository;
using Librarys.Extenders;
using Librarys;
using EncryptDecryptAssembly;

namespace POMS.Repository.Masters
{
    public class EmployeeRepository : RepositoryBaseNew
    {
        public List<Employee> EmployeeRoleAutoComplete(Employee ObjEmployee)
        {
            string _USP_Retrive_Employee = "USP_Retrive_Employee";
            List<Employee> _Employee = new List<Employee>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmployeeSno", ObjEmployee.EmployeeSno));
            DataSet dataSet = MasterExecuteCommand(_USP_Retrive_Employee, parameters);
            DataRowCollection rows = dataSet.Tables[0].Rows;
            _Employee = dataSet.Tables[0].ToCollection<Employee>();
            return _Employee;
        }
        public List<Employee> EmployeeGet(Employee ObjEmployee)
        {
            string _USP_Retrive_Employee = "USP_Retrive_Employee";
            List<Employee> _Employee = new List<Employee>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmployeeSno", ObjEmployee.EmployeeSno));
            DataSet dataSet = MasterExecuteCommand(_USP_Retrive_Employee, parameters);
            DataRowCollection rows = dataSet.Tables[0].Rows;
            _Employee = dataSet.Tables[0].ToCollection<Employee>();
            return _Employee;
        }

        public List<Employee> LoginGet(string UserName, string Password)
        {
            string _USP_LOGIN = "USP_LOGIN";
            List<Employee> _Employee = new List<Employee>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserName", UserName));
            parameters.Add(new SqlParameter("@Password", Password));
            DataSet dataSet = MasterExecuteCommand(_USP_LOGIN, parameters);

            try
            {
                DataRowCollection rows = dataSet.Tables[0].Rows;
                _Employee = dataSet.Tables[0].ToCollection<Employee>();
            }

            catch (Exception e)
            {

            }

            return _Employee;
        }


        public Tuple<List<Employee>, int> EmployeeSearch(PageRequest pageRequest)
        {
            string _USP_EXP_Employee_DETAILS = "USP_EXP_Employee_DETAILS";
            List<Employee> _Employee = new List<Employee>();
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
                DataSet dataSet = MasterExecuteCommand(_USP_EXP_Employee_DETAILS, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                _Employee = dataSet.Tables[0].ToCollection<Employee>();
            }
            return new Tuple<List<Employee>, int>(_Employee, recordCount);
        }
        public string EmployeeInsert(Employee ObjEmployee)
        {
            const string _USP_INSERT_EMPLOYEE = "USP_INSERT_EMPLOYEE";
            EncryptDecrypt objEncrypt = new EncryptDecrypt();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter CountrySno = new SqlParameter("@EmployeeSno", ObjEmployee.EmployeeSno);
            CountrySno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(CountrySno);

            SqlParameter EmployeeCode = new SqlParameter("@EmployeeCode", ObjEmployee.EmployeeCode);
            EmployeeCode.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(EmployeeCode);


            SqlParameter FirstName = new SqlParameter("@FirstName", ObjEmployee.FirstName);
            FirstName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(FirstName);

            SqlParameter MiddleName = new SqlParameter("@MiddleName", ObjEmployee.MiddleName);
            MiddleName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(MiddleName);


            SqlParameter LastName = new SqlParameter("@LastName", ObjEmployee.LastName);
            LastName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(LastName);



            SqlParameter Gendertype = new SqlParameter("@Gendertype", ObjEmployee.Gendertype);
            Gendertype.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(Gendertype);

            SqlParameter DOB = new SqlParameter("@DOB", ObjEmployee.DOB);
            DOB.SqlDbType = SqlDbType.DateTime;
            sqlParameters.Add(DOB);

            SqlParameter EmpAdd = new SqlParameter("@EmpAdd", ObjEmployee.EmpAdd);
            EmpAdd.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(EmpAdd);

            SqlParameter EmailID = new SqlParameter("@EmailID", ObjEmployee.EmailID);
            EmailID.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(EmailID);

            SqlParameter Designation = new SqlParameter("@Designation", ObjEmployee.Designation);
            Designation.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(Designation);

            SqlParameter UserName = new SqlParameter("@UserName", ObjEmployee.UserName);
            UserName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(UserName);

            ObjEmployee.Password = objEncrypt.Encrypt(ObjEmployee.UserName + "@123", "");

            SqlParameter pwd = new SqlParameter("@pwd", ObjEmployee.Password);
            pwd.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(pwd);

            SqlParameter RoleSno = new SqlParameter("@RoleSno", ObjEmployee.RoleSno);
            RoleSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(RoleSno);

            SqlParameter PhoneNo = new SqlParameter("@PhoneNo", ObjEmployee.PhoneNo);
            PhoneNo.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(PhoneNo);

            SqlParameter CreOpr = new SqlParameter("@CreOpr", ObjEmployee.CreOpr);
            CreOpr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(CreOpr);

            SqlParameter IPNumber = new SqlParameter("@IPNumber", ObjEmployee.IPNumber);
            IPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(IPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", ObjEmployee.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(ActionName);


            SqlParameter LoginSts = new SqlParameter("@LoginSts", ObjEmployee.LoginSts);
            LoginSts.SqlDbType = SqlDbType.Bit;
            sqlParameters.Add(LoginSts);

            SqlParameter Sts = new SqlParameter("@Sts", ObjEmployee.sts);
            Sts.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(Sts);

            SqlParameter parmsLSPSno = new SqlParameter("@VendorSno", ObjEmployee.VendorSno);
            parmsLSPSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(parmsLSPSno);

            DataSet ds = MasterExecuteCommand(_USP_INSERT_EMPLOYEE, sqlParameters);
            string Result = ds.Tables[0].Rows[0][0].ToString();
            return Result;
        }

        public string SubscriberInsert(subscribers ObjSubscriber)
        {
            const string _SubscriberCreatePin = "USP_CreatePin_Subscriber";
            string Result = "";
            EncryptDecrypt objEncrypt = new EncryptDecrypt();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter SubscriberSno = new SqlParameter("@SubscriberSno", ObjSubscriber.SubscriberSno);
            SubscriberSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(SubscriberSno);

            SqlParameter MobileNo = new SqlParameter("@MobileNo", ObjSubscriber.MobileNo);
            MobileNo.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(MobileNo);


            ObjSubscriber.MPIN = objEncrypt.Encrypt(ObjSubscriber.MPIN, "");
            ObjSubscriber.ConfirmPIN = objEncrypt.Encrypt(ObjSubscriber.ConfirmPIN, "");

            SqlParameter MPIN = new SqlParameter("@MPIN", ObjSubscriber.MPIN);
            MPIN.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(MPIN);

            SqlParameter ConfirmPIN = new SqlParameter("@ConfirmPIN", ObjSubscriber.ConfirmPIN);
            ConfirmPIN.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(ConfirmPIN);

            try
            {
                DataSet ds = MasterExecuteCommand(_SubscriberCreatePin, sqlParameters);
                Result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

            }
            return Result;
        }
        public subscribers SubscriberLoginGet(string MobileNo, string MPIN)
        {
            string _USP_LOGIN = "USP_SubscriberLOGIN";

            EncryptDecrypt objEncrypt = new EncryptDecrypt();

            MPIN = objEncrypt.Encrypt(MPIN, "");

            subscribers _Employee = new subscribers();
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MobileNo", MobileNo));
            parameters.Add(new SqlParameter("@MPIN", MPIN));

            DataSet dataSet = MasterExecuteCommand(_USP_LOGIN, parameters);

            try
            {
                DataRowCollection rows = dataSet.Tables[0].Rows;
                _Employee = dataSet.Tables[0].ToCollection<subscribers>().FirstOrDefault();
            }

            catch (Exception e)
            {

            }

            return _Employee;
        }
    }
}

