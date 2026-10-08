using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Masters;
using System.Data.SqlClient;
using System.Data;
using Repository;
using Librarys.Extenders;
using Librarys;
using POM.Repository;
using POMS.Entity;


namespace Repository.Masters
{
   public class StoragePalletTypeRepository : RepositoryBaseNew
    {
        const string _Insert = "USP_StoragepalletType_Insert";
        const string _Search = "USP_StoragepalletType_SEARCH";
        const string _Edit = "USP_StoragepalletType_Edit";
        public string Insert(StoragePalletType Obj)
        {
           List<SqlParameter> sqlParameters = new List<SqlParameter>();

            string Result = "";
            SqlParameter paramStoragepallettypeSno = new SqlParameter("@StoragepallettypeSno", Obj.StoragepallettypeSno);
            paramStoragepallettypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramStoragepallettypeSno);

            SqlParameter paramWarehouseSno = new SqlParameter("@WarehouseSno", Obj.WarehouseSno);
            paramWarehouseSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramWarehouseSno);

            SqlParameter paramcustomerSno = new SqlParameter("@customerSno", Obj.customerSno);
            paramcustomerSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramcustomerSno);

            SqlParameter paramItemCategorySno = new SqlParameter("@ItemCategorySno", Obj.ItemCategorySno);
            paramItemCategorySno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramItemCategorySno);

            SqlParameter paramStorageTypeSno = new SqlParameter("@StorageTypeSno", Obj.StorageTypeSno);
            paramStorageTypeSno.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(paramStorageTypeSno);

            SqlParameter categorytype = new SqlParameter("@categorytype", Obj.categorytype);
            categorytype.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(categorytype);

            SqlParameter StorageRequired = new SqlParameter("@StorageRequired", Obj.StorageRequired);
            StorageRequired.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(StorageRequired);


            SqlParameter paraActionName = new SqlParameter("@ActionName", Obj.ActionName);
            paraActionName.SqlDbType = SqlDbType.VarChar;
            sqlParameters.Add(paraActionName);

            SqlParameter IPNumber = new SqlParameter("@IPNumber", Obj.IPNumber);
            IPNumber.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(IPNumber);


            SqlParameter CreOpr = new SqlParameter("@Creopr", Obj.CreOpr);
            CreOpr.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(CreOpr);

            SqlParameter Sts = new SqlParameter("@Sts", Obj.Sts);
            Sts.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(Sts);
            try
            {
                DataSet ds = MasterExecuteCommand(_Insert, sqlParameters);
                 Result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                
            }
            return Result;
        }
        public Tuple<List<StoragePalletType>, int> Search(PageRequest pageRequest)
        {
            List<StoragePalletType> objRole = new List<StoragePalletType>();
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
                    parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    DataSet dataSet = MasterExecuteCommand(_Search, parameters, ref recordCount);

                    objRole = dataSet.Tables[0].ToCollection<StoragePalletType>();
                }
                catch (Exception ee) { }
            }

            return new Tuple<List<StoragePalletType>, int>(objRole, recordCount);
        }
        public StoragePalletType Edit(int StoragepallettypeSno)
        {
            StoragePalletType StoragePallet = new StoragePalletType();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StoragepallettypeSno", StoragepallettypeSno));
            DataSet dataSet = MasterExecuteCommand(_Edit, parameters);
            StoragePallet = dataSet.Tables[0].ToCollection<StoragePalletType>().FirstOrDefault();
            return StoragePallet;
        }
    }
}
