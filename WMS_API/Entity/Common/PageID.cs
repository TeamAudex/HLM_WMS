using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public enum PageId : int
    {
        BranchMaster = 1,      
        CommonRef = 2,
        CommonMaster = 3,
        UserBranchMap = 4,
        EmployeeMaster = 5,
        FoodRequest = 6,
        ChargeMaster = 7,
        ItemMaster=8,
        ItemIncredients=9,
        ItemPackage=10,
        PurchaseEntry=11,
        ExpenseRegister=12,
        POSBill=13,
        UserMap=14,
        RoleMaster = 15,
        StockTransfer = 16,
        StockDispose = 17,
        SearchFoodMaking=18,
        FoodMakingSearchNew = 19,
        StateMaster = 20,
        CountryMaster = 21,
        UserWarehouseMapping = 22,
        VendorMaster=23,
        StorageTypeID = 24,
        Floor=25,
        Customer = 26,
        StorageType = 27,
        CityWithLocation =28,
        StoragePallettype =29,
        WarehouseZoneMaster =30,
        PickList=31,
        IST=32,
        WarehouseLayout=33,
        Dispatch=34,
        CycleCountPlan = 35,
        CycleCountStart = 36,
        CycleCountAdjust = 37,
        PutAway = 38,
        WarehouseSubZone =39,
        PickerAttendance = 40,
        PickerOrderConf = 41,
        ST=42,
        ISTPosting=43,
        CycleCountAdjustApproval=44,
        PicklistST = 45,
        StockDisposes = 46,
        PickListPickerSearch = 47,
        StockDisposesApproval = 48,
        StockDisposalDispatch = 49,
        ISTSplitting = 50,
        UpdateExpiryDate = 51,
        UserStateMap = 52
    }
}
