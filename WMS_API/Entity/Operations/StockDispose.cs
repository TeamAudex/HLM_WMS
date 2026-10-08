using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
    public class StockDispose
    {
       public int StockDisposeSno               {get; set;}
       public string StockDisposeNo             {get; set;}
       public int WarehouseSno                  {get; set;}
       public string WarehouseName              {get; set;}
       public string ReqDate                    {get; set;}
       public string FromDate                   {get; set;}
       public string ToDate                     {get; set;}
       public int ItemSno                       {get; set;}
       public string ItemName                   {get; set;}
       public string TxtItemSno                 {get; set;}
       public string TxtItemName                {get; set;}
       public int BatchSno                      {get; set;}
       public string BatchNo                    {get; set;}
       public string TxtBatchSno                {get; set;}
       public string TxtBatchNo                 {get; set;}
       public int StorageLocationSno            {get; set;}
       public string StorageLocation            {get; set;}
       public string TxtStorageLocationSno      {get; set;}
       public string TxtStorageLocation         {get; set;}
       public int Creopr                        {get; set;}
       public string IPNumber                   {get; set;}
       public bool Sts                          {get; set;}
       public string Status                     {get; set;}
       public string AppFlag                    {get; set;}
       public string DispatchDate               {get; set;}
       public string InvoiceNo                  {get; set;}
       public string InvoiceDate                {get; set;}
       public string Remarks                    {get; set;}

    }
    public class StockDisposeDet
    {
        public int StockDisposeDetSno { get; set; }
        public int StockDisposeSno { get; set; }
        public int LocationStockSno { get; set; }
        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public string ExpDate { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public int StorageLocationSno { get; set; }
        public string StorageLocation { get; set; }
        public decimal AvailableQty { get; set; }
        public decimal Qty { get; set; }
        public decimal TotQty { get; set; }
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
        public string StockCode { get; set; }
        public string Remarks { get; set; }
        public string RackLocation { get; set; }
        public int UOMCode { get; set; }
        public string UOMDesc { get; set; }
        public bool Sts { get; set; }
    }
    public class StockDisposeDetails
    {
        public StockDispose objStockDispose { get; set; }
        public List<StockDisposeDet> objStockDisposeDet { get; set; }
    }

    public class StockDisposeResponse
    {
        public string Result { get; set; }   
        public int StockDisposeSno { get; set; }
    }
}
