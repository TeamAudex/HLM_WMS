using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Masters;
using POM.Repository;
using System.Data;
using System.Data.SqlClient;
using Librarys;
using Librarys.Extenders;
using POMS.Entity;

namespace Repository.Masters
{
   public class FloorRepository : RepositoryBaseNew
    {
        const string _Search = "USP_FLOOR_SEARCH";
        const string _Insert = "USP_FLOOR_INSERT";
        const string _Edit = "USP_FLOOR_EDIT";

        public string Insert(FloorList objFloorList)
        {



            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter FloorSno = new SqlParameter("@FloorSno", objFloorList.objFloor.FloorSno);
            FloorSno.SqlDbType = SqlDbType.Int;

            sqlParameters.Add(FloorSno);

            SqlParameter WarehouseSno = new SqlParameter("@WarehouseSno", objFloorList.objFloor.WarehouseSno);
            WarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(WarehouseSno);

            SqlParameter WarehouseName = new SqlParameter("@WarehouseName", objFloorList.objFloor.WarehouseName);
            WarehouseName.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(WarehouseName);

            SqlParameter paramCreopr = new SqlParameter("@Creopr", objFloorList.objFloor.Creopr);
            paramCreopr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramCreopr);

            SqlParameter objIPNumber = new SqlParameter("@IPNumber", objFloorList.objFloor.IPNumber);
            objIPNumber.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(objIPNumber);

            SqlParameter objFloorDetails = new SqlParameter();
            objFloorDetails.ParameterName = "@FloorDetails";
            objFloorDetails.SqlDbType = SqlDbType.Structured;
            objFloorDetails.Value = objFloorList.objFloorDet.ToDataTable<FloorDet>();
            objFloorDetails.Direction = ParameterDirection.Input;
            sqlParameters.Add(objFloorDetails);

            DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);

          
            string result = string.Empty;

          
            result = ds.Tables[0].Rows[0][0].ToString();
           



            return result;


        }


        public FloorList Edit(int FloorSno)
        {
            FloorList objFloorList = new FloorList();

            List<SqlParameter> Sqlparams = new List<SqlParameter>();
            Sqlparams.Add(new SqlParameter("@FloorSno", FloorSno));

            DataSet ds = MasterExecuteCommand(_Edit, Sqlparams);
            objFloorList.objFloor = ds.Tables[0].ToCustomList<Floor>().FirstOrDefault();
            objFloorList.objFloorDet = ds.Tables[1].ToCustomList<FloorDet>();
            return objFloorList;
        }


        public Tuple<List<Floor>, int> Search(PageRequest pageRequest)
        {
            List<Floor> SearchList = new List<Floor>();
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
                SearchList = dataSet.Tables[0].ToCollection<Floor>();
            }
            return new Tuple<List<Floor>, int>(SearchList, recordCount);

        }
    }
}
