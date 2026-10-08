using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using POM.Repository;
using System.Data;
using System.Data.SqlClient;
using Librarys;
using Librarys.Extenders;

namespace POMS.Repository
{

    public class BranchMasterRepository : RepositoryBaseNew
    {

        const string _Insert = "USP_BRANCHMASTER_INSERT";
        public string BranchInsert(BranchMaster objclass)
        {
            List<SqlParameter> objParams = new List<SqlParameter>();
            SqlParameter objBranchSno = new SqlParameter("@BranchSno", objclass.BranchSno);
            objBranchSno.SqlDbType = SqlDbType.Int;
            objParams.Add(objBranchSno);

            SqlParameter objBranchName = new SqlParameter("@BranchName", objclass.BranchName);
            objBranchName.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objBranchName);

            SqlParameter objBranchCode = new SqlParameter("@BranchCode", objclass.BranchCode);
            objBranchCode.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objBranchCode);

            SqlParameter objCitySno = new SqlParameter("@CitySno", objclass.CitySno);
            objCitySno.SqlDbType = SqlDbType.Int;
            objParams.Add(objCitySno);

            SqlParameter objShortName = new SqlParameter("@ShortName", objclass.ShortName);
            objShortName.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objShortName);

            SqlParameter objEstablishedDate = new SqlParameter("@EstablishedDate", objclass.EstablishedDate);
            objEstablishedDate.SqlDbType = SqlDbType.DateTime;
            objParams.Add(objEstablishedDate);

            SqlParameter objPhoneNumber = new SqlParameter("@PhoneNumber", objclass.PhoneNumber);
            objPhoneNumber.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objPhoneNumber);

            SqlParameter objFaxNumber = new SqlParameter("@FaxNumber", objclass.FaxNumber);
            objFaxNumber.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objFaxNumber);

            SqlParameter objEmailID = new SqlParameter("@EmailID", objclass.EmailID);
            objEmailID.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objEmailID);

            SqlParameter objPANNumber = new SqlParameter("@PANNumber", objclass.PANNumber);
            objPANNumber.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objPANNumber);

            SqlParameter objGSTINNumber = new SqlParameter("@GSTINNumber", objclass.GSTINNumber);
            objGSTINNumber.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objGSTINNumber);

            SqlParameter objInCharge = new SqlParameter("@InChargeSno", objclass.InChargeSno);
            objInCharge.SqlDbType = SqlDbType.Int;
            objParams.Add(objInCharge);

            SqlParameter objContactPerson = new SqlParameter("@ContactPerson", objclass.ContactPerson);
            objContactPerson.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objContactPerson);

            SqlParameter objBranchAddress = new SqlParameter("@BranchAddress", objclass.BranchAddress);
            objBranchAddress.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objBranchAddress);

            SqlParameter objPincode = new SqlParameter("@Pincode", objclass.Pincode);
            objPincode.SqlDbType = SqlDbType.NVarChar;
            objParams.Add(objPincode);

            SqlParameter objLat = new SqlParameter("@LAt", objclass.Latitude);
            objLat.SqlDbType = SqlDbType.Decimal;
            objParams.Add(objLat);

            SqlParameter objLang = new SqlParameter("@LNG", objclass.Longitude);
            objLang.SqlDbType = SqlDbType.Decimal;
            objParams.Add(objLang);

            SqlParameter objGeoFence = new SqlParameter("@geofencing", objclass.GeoFence);
            objGeoFence.SqlDbType = SqlDbType.Decimal;
            objParams.Add(objGeoFence);

            SqlParameter objCreOpr = new SqlParameter("@CreOpr", objclass.CreOpr);
            objCreOpr.SqlDbType = SqlDbType.Int;
            objParams.Add(objCreOpr);

            SqlParameter objCreDat = new SqlParameter("@CreDat", objclass.CreDat);
            objCreDat.SqlDbType = SqlDbType.DateTime;
            objParams.Add(objCreDat);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objclass.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            objParams.Add(objIPNumber);

            SqlParameter ActionName = new SqlParameter("@ActionName", objclass.ActionName);
            ActionName.SqlDbType = SqlDbType.VarChar;
            objParams.Add(ActionName);

            SqlParameter objsts = new SqlParameter("@sts", objclass.sts);
            objsts.SqlDbType = SqlDbType.Bit;
            objParams.Add(objsts);


            SqlParameter objTypes = new SqlParameter("@Types", objclass.Types);
            objTypes.SqlDbType = SqlDbType.Int;
            objParams.Add(objTypes);

            DataSet ds = MasterExecuteCommand(_Insert, objParams);
            string result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        const string _Edit = "USP_BRANCHMASTER_EDIT";
        public List<BranchMaster> BranchEdit(int BranchSno)
        {
            List<BranchMaster> Editlist = new List<BranchMaster>();
            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@BranchSno", BranchSno));
            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            Editlist = ds.Tables[0].ToCustomList<BranchMaster>();
            return Editlist;
        }

        const string _Search = "USP_BRANCHMASTER_SEARCH";

        public Tuple<List<BranchMaster>, int> BranchSearch(PageRequest pageRequest)
        {
            List<BranchMaster> SearchList = new List<BranchMaster>();
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
                DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                SearchList = dataSet.Tables[0].ToCollection<BranchMaster>();
            }
            return new Tuple<List<BranchMaster>, int>(SearchList, recordCount);

        }

        const string _droptype = "EntityTypeDropdown";
        public Typesdropdownlist Typesdropdown()
        {
            Typesdropdownlist obdrop = new Typesdropdownlist();
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            DataSet ds = MasterExecuteCommand(_droptype, sqlparams);
            DataTable dtBranch = new DataTable();
            obdrop.objTypesDropdown = ds.Tables[0].ToCollection<Typesdropdown>();
            return obdrop;
        }





        const string _AutoComplete = "USP_AUTOCOMPLETE_ROP";
        public List<BranchMaster> AutoComplete(string Condition, int Condition1, int Condition2)
        {
            List<BranchMaster> Obj = new List<BranchMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Condition", Condition));
            parameters.Add(new SqlParameter("@ConditionOne", Condition1));
            parameters.Add(new SqlParameter("@ConditionTwo", Condition2));
            DataSet dataset = MasterExecuteCommand(_AutoComplete, parameters);


            //DataTable DT = new DataTable();
            Obj = dataset.Tables[0].ToCollection<BranchMaster>();
            return Obj;
        }

    }
}
