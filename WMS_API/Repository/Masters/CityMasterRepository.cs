using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using System.Data.SqlClient;
using System.Data;
using POMS.Entity.Masters;
using POM.Repository;
using Librarys.Extenders;
using Librarys;

namespace POMS.Repository.Masters
{
    public class CityMasterRepository : RepositoryBaseNew
    {
        const string _CityMaster_Insert = "Usp_CityMaster_Insert";
        const string _CityMaster_Search = "USP_CityMaster_Search_Page";
        const string _CityMaster_Edit = "Usp_CityMaster_Edit";
        const string _get_CountryName_autocomplete = "Usp_Get_CountryName_AutoComplete";
        const string _get_StateName_autocomplete = "Usp_Get_State_AutoComplete";
        public string InsertCityMaster(CityMas objCityMaster)
        {

            List<SqlParameter> objListOfsqlParameters = new List<SqlParameter>();

            SqlParameter paramCitySno = new SqlParameter("@CitySno", objCityMaster.CityWithlocation.CitySno);
            paramCitySno.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramCitySno);

            SqlParameter paramCountrySno = new SqlParameter("@CountrySno", objCityMaster.CityWithlocation.CountrySno);
            paramCountrySno.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramCountrySno);

            //SqlParameter paramCountryName = new SqlParameter("@CountryName", objCityMaster.CountryName);
            //paramCountryName.SqlDbType = SqlDbType.NVarChar;
            //objListOfsqlParameters.Add(paramCountryName);

            SqlParameter paramStateSno = new SqlParameter("@StateSno", objCityMaster.CityWithlocation.StateSno);
            paramStateSno.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramStateSno);

            //SqlParameter paramStateName = new SqlParameter("@StateName", objCityMaster.StateName);
            //paramStateName.SqlDbType = SqlDbType.NVarChar;
            //objListOfsqlParameters.Add(paramStateName);            

            SqlParameter paramCityName = new SqlParameter("@CityName", objCityMaster.CityWithlocation.CityName);
            paramCityName.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(paramCityName);

            SqlParameter paramCityCode = new SqlParameter("@CityCode", objCityMaster.CityWithlocation.CityCode);
            paramCityCode.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(paramCityCode);

            SqlParameter ZoneMasSno = new SqlParameter("@ZoneMasSno", objCityMaster.CityWithlocation.ZoneMasSno);
            ZoneMasSno.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(ZoneMasSno);


            SqlParameter Latitude = new SqlParameter("@Latitude", objCityMaster.CityWithlocation.Latitude);
            Latitude.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(Latitude);

            SqlParameter Longitude = new SqlParameter("@Longitude", objCityMaster.CityWithlocation.Longitude);
            Longitude.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(Longitude);

            SqlParameter ActionName = new SqlParameter("@ActionName", objCityMaster.CityWithlocation.ActionName);
            ActionName.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(ActionName);

            SqlParameter IPNumber = new SqlParameter("@IPNumber", objCityMaster.CityWithlocation.IPNumber);
            IPNumber.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(IPNumber);

            SqlParameter CreOpr = new SqlParameter("@CreOpr", objCityMaster.CityWithlocation.CreOpr);
            CreOpr.SqlDbType = SqlDbType.NVarChar;
            objListOfsqlParameters.Add(CreOpr);

            SqlParameter CityWithlocationDet = new SqlParameter();
            CityWithlocationDet.ParameterName = "@CityWithlocationDet";
            CityWithlocationDet.SqlDbType = SqlDbType.Structured;
            CityWithlocationDet.Value = objCityMaster.CityWithlocationDet.ToDataTable<CityWithlocationDet>();
            CityWithlocationDet.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(CityWithlocationDet);

            DataSet ds = MasterExecuteCommand(_CityMaster_Insert, objListOfsqlParameters);
            string result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public Tuple<List<CityMaster>, int> CityMasterSearch(PageRequest pageRequest)
        {
            List<CityMaster> objCityMaster = new List<CityMaster>();
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
                DataSet dataSet = MasterExecuteCommand(_CityMaster_Search, parameters, ref recordCount);
                DataRowCollection rows = dataSet.Tables[0].Rows;
                objCityMaster = dataSet.Tables[0].ToCollection<CityMaster>();
            }
            return new Tuple<List<CityMaster>, int>(objCityMaster, recordCount); 
        }

        public CityMas CityMasterEdit(int CitySno)
        {
            CityMas objCityMaster = new CityMas();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CitySno", CitySno));
            DataSet dataSet = MasterExecuteCommand(_CityMaster_Edit, parameters);
            objCityMaster.CityWithlocation = dataSet.Tables[0].ToCustomList<CityWithlocation>().FirstOrDefault();
            objCityMaster.CityWithlocationDet = dataSet.Tables[1].ToCollection<CityWithlocationDet>();
            return objCityMaster;
        }

        //public List<CityMaster> AutoComplete_CityMaster(string condition, int condition1)
        //{
        //    List<CityMaster> objCityMaster = new List<CityMaster>();
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Condition", condition));
        //    parameters.Add(new SqlParameter("@Condition1", condition1));
        //    DataSet dataSet = MasterExecuteCommand(_Autocomplete, parameters);
        //    DataTable dtBS = new DataTable();
        //    objCityMaster = dataSet.Tables[0].ToCollection<CityMaster>();
        //    return objCityMaster;
        //}

        public List<CityMaster> Autocomplete_CountryName(string Param1)
        {
            const string _get_CountryName_autocomplete = "Usp_Get_CountryName_AutoComplete";
            List<CityMaster> CounrtyNamerAutocomplete = new List<CityMaster>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TypeText", Param1));
            DataSet dataSet = MasterExecuteCommand(_get_CountryName_autocomplete, parameters);
            DataTable dtBranch = new DataTable();
            CounrtyNamerAutocomplete = dataSet.Tables[0].ToCollection<CityMaster>();
            return CounrtyNamerAutocomplete;
        }
        public List<CityWithlocation> Autocomplete_StateName(string param1, string param2)
        {
            const string _get_StateName_autocomplete = "Usp_Get_State_AutoComplete";
            List<CityWithlocation> StateNamerAutocomplete = new List<CityWithlocation>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@condition1", param1));
            parameters.Add(new SqlParameter("@TypeText", param2));
            DataSet dataSet = MasterExecuteCommand(_get_StateName_autocomplete, parameters);
            DataTable dtBranch = new DataTable();
            StateNamerAutocomplete = dataSet.Tables[0].ToCollection<CityWithlocation>();
            return StateNamerAutocomplete;
        }
        public List<CityWithlocation> Autocomplete_StateName(string param1, string param2, string param3)
        {
            const string _get_StateName_autocomplete = "Usp_Get_State_AutoComplete";
            List<CityWithlocation> StateNamerAutocomplete = new List<CityWithlocation>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@condition1", param1));
            parameters.Add(new SqlParameter("@TypeText", param2));
            parameters.Add(new SqlParameter("@TypeText1", param3));
            DataSet dataSet = MasterExecuteCommand(_get_StateName_autocomplete, parameters);
            DataTable dtBranch = new DataTable();
            StateNamerAutocomplete = dataSet.Tables[0].ToCollection<CityWithlocation>();
            return StateNamerAutocomplete;
        }
    }
}
