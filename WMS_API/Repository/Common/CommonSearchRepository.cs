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

namespace POMS.Repository
{
    public class CommonSearchRepository : RepositoryBaseNew
    {
        public FilterResponse GetFilterData(FilterRequest filterRequest)
        {
            var result = new Dictionary<string, List<string>>();
            var filterData = new List<SelectList>();
            int recordCount = 0, minFilterTextLength = 0;
            string stringColumnValue = string.Empty, idColumnValue = string.Empty;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PageSize", filterRequest.PageSize));
            parameters.Add(new SqlParameter("@PageNumber", filterRequest.PageNumber));
            parameters.Add(new SqlParameter("@SortColumn", filterRequest.ColumnName));
            parameters.Add(new SqlParameter("@DBColumnName", filterRequest.DBColumn));
            parameters.Add(new SqlParameter("@Query", filterRequest.Query));
            parameters.Add(new SqlParameter("@UserSno", filterRequest.UserSno));
            parameters.Add(new SqlParameter("@TrnType", filterRequest.TrnType));
            if (filterRequest.DynamicApproval)
            {
                parameters.Add(new SqlParameter("@PageID", filterRequest.PageID));
                parameters.Add(new SqlParameter("@UserID", filterRequest.UserSno));
            }
            parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output });
            //parameters.Add(new SqlParameter("@MinTextLength", SqlDbType.Int) { Direction = ParameterDirection.Output });
            DataSet dataSet = ExecuteCommand(GetFilterStoredProc(filterRequest.PageID) + (filterRequest.DynamicApproval == true ? "_Approval" : ""), parameters, ref recordCount, ref minFilterTextLength);
            DataRowCollection rows = dataSet.Tables[0].Rows;
            int length = rows.Count;

            if (filterRequest.PageNumber == 1 && length > 15 || true)
            {
                for (int index = 0; index < length; index += 1)
                {
                    stringColumnValue = Convert.ToString(rows[index].Field<object>(filterRequest.ColumnName));
                    idColumnValue = Convert.ToString(rows[index].Field<object>(filterRequest.DBColumn));

                    if (!result.Keys.Contains(stringColumnValue))
                    {
                        if (index != 0)
                        {
                            filterData.Add(new SelectList() { Text = result.Last().Key, Value = string.Join(",", result[result.Last().Key].ToArray()) });
                        }
                        result.Add(stringColumnValue, new List<string>());
                    }
                    result[stringColumnValue].Add(idColumnValue);
                }
                if (length > 0)
                {
                    filterData.Add(new SelectList() { Text = result.Last().Key, Value = string.Join(",", result[result.Last().Key].ToArray()) });
                }
            }
            return new FilterResponse() { Data = filterData, TotalRecords = recordCount, MinTextLength = minFilterTextLength };
        }

        private string GetFilterStoredProc( PageId pageId)
        {
            string result = "";
            switch (pageId)
            {
                
                case PageId.BranchMaster:
                    result = "USP_BRANCHMASTER_SEARCH"; break;
                case PageId.CommonRef:
                    result = "USP_COMMONREF_SEARCH"; break;
                case PageId.CommonMaster:
                    result = "USP_GET_COMMON_MASTER"; break;
                case PageId.UserBranchMap:
                    result = "USP_UserBranchMap_Search"; break;
                case PageId.EmployeeMaster:
                    result = "USP_EXP_Employee_DETAILS"; break;
                case PageId.FoodRequest:
                    result = "USP_FOODREQUEST_SEARCH"; break;
                case PageId.ChargeMaster:
                    result = "USP_Charge_Search"; break;
                case PageId.ItemMaster:
                    result = "USP_RST_ITEMMASTER_SELECT"; break;
                case PageId.ItemIncredients:
                    result = "USP_ItemIngredients_Search"; break;
                case PageId.ItemPackage:
                    result = "USP_GET_ITEM_PACKAGE"; break;
                case PageId.PurchaseEntry:
                    result = "SearchPurchaseEntry"; break;
                case PageId.ExpenseRegister:
                    result = "SearchExpenseRegister"; break;
                case PageId.POSBill:
                    result = "USP_POS_Search"; break;
                case PageId.UserMap:
                    result = "USP_UserTypeMap_Search"; break;
                case PageId.RoleMaster:
                    result = "USP_ROLE_SEARCH"; break;
                case PageId.StockTransfer:
                    result = "SearchStockTransfer"; break;
                case PageId.StockDispose:
                    result = "SearchStockDispose"; break;
                case PageId.SearchFoodMaking:
                    result = "USP_FoodMaked_Search"; break;
                case PageId.FoodMakingSearchNew:
                    result = "USP_FoodMaking_Search_New"; break;
                case PageId.StateMaster:
                    result = "USP_SEARCH_STATE_MASTER"; break;
                case PageId.CountryMaster:
                    result = "USP_COUNTRY_SEARCH"; break;
                case PageId.UserWarehouseMapping:
                    result = "USP_UserBranchMap_Search"; break;
                case PageId.VendorMaster:
                    result = "USP_VendorMaster_SearchPage"; break;
                case PageId.StorageTypeID:
                    result = "USP_StorageTypeID_Search"; break;
                case PageId.Floor:
                    result = "USP_FLOOR_SEARCH"; break;
                case PageId.Customer:
                    result = "USP_SEARCH_CUSTOMER"; break;
                case PageId.StorageType:
                    result = "USP_StorageType_SEARCH"; break;
                case PageId.CityWithLocation:
                    result = "USP_CityMaster_Search_Page"; break;
                case PageId.StoragePallettype:
                    result = "USP_StoragepalletType_SEARCH"; break;
                case PageId.WarehouseZoneMaster:
                    result = "USP_WarehouseZone_Search"; break;
                case PageId.PickList:
                    result = "USP_SYSTEMATIC_PICKLIST_SEARCH"; break;
                case PageId.IST:
                    result = "USP_IST_SEARCH"; break;
                case PageId.Dispatch:
                    result = "USP_DISPATCH_SEARCH"; break;
                case PageId.CycleCountPlan:
                    result = "USP_CycleCount_Plan_Search"; break;
                case PageId.CycleCountStart:
                    result = "USP_SEARCH_CCPhysical"; break;
                case PageId.CycleCountAdjust:
                    result = "USP_CycleCountAdjust__Search"; break;                 
                case PageId.PutAway:
                    result = "USP_PutAway_Search"; break;
                case PageId.WarehouseLayout:
                    result = "USP_WarehouseLayout_Search"; break;
                case PageId.WarehouseSubZone:
                    result = "USP_WarehouseSubZone_Search"; break;
                case PageId.PickerAttendance:
                    result = "USP_PickerAttand_Search"; break;
                case PageId.PickerOrderConf:
                    result = "USP_PickerOrderConf_Search"; break;
                case PageId.ST:
                    result = "USP_ST_SEARCH"; break;
                case PageId.ISTPosting:
                    result = "USP_IST_POSTING_SEARCH"; break;
                case PageId.CycleCountAdjustApproval:
                    result = "USP_CycleCountAdjust_Approval_Search"; break;
                case PageId.PicklistST:
                    result = "USP_SYSTEMATIC_PICKLIST_SEARCH"; break;
                case PageId.StockDisposes:
                    result = "USP_STOCK_DISPOSE_SEARCH"; break;
                case PageId.StockDisposesApproval:
                    result = "USP_STOCK_DISPOSE_APPROVAL_SEARCH"; break;
                case PageId.StockDisposalDispatch:
                    result = "USP_STOCK_DISPOSAL_DISPATCH_SEARCH"; break;
                case PageId.PickListPickerSearch:
                    result = "USP_SYSTEMATIC_PICKLIST_PICKER_SEARCH"; break;
                case PageId.ISTSplitting:
                    result = "USP_IST_SPLITTING_SEARCH"; break;
                case PageId.UpdateExpiryDate:
                    result = "USP_UpdateExpiryDate_Search"; break;
                case PageId.UserStateMap:
                    result = "USP_UserStateMap_Search"; break;
            }


            return result;
        }
    }
}
