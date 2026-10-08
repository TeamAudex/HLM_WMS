using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class FilterRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PageId PageID { get; set; }
        public string UserSno { get; set; }
        public string TrnType { get; set; }
        public string ColumnName { get; set; }
        public string DBColumn { get; set; }
        public string Query { get; set; }
        public bool DynamicApproval { get; set; }
    }
    public class FilterResponse
    {
        public int TotalRecords { get; set; }
        public int MinTextLength { get; set; }
        public List<SelectList> Data { get; set; }
    }
    public class SelectList
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }
    public class Filter
    {
        public string ColunName { get; set; }
        public string DBColumn { get; set; }
        public string Value { get; set; }
        public bool UniversalGate { get; set; }
        public FilterOperator Operator { get; set; }
    }

    //public class PageView
    //{
    //    public PageId PageId { get; set; }
    //    public string Settings { get; set; }
    //    public string ViewName { get; set; }
    //    public bool IsDefaultView { get; set; }
    //    public bool IsSystemView { get; set; }
    //    public string PageUrl { get; set; }
    //    public int ViewId { get; set; }
    //    public int UserId { get; set; }
    //}
    public class PageRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public bool SortOrder { get; set; }
        public string DBColumnName { get; set; }
        public List<Filter> Filters { get; set; }
        public string Query { get; set; }
        public bool DynamicApproval { get; set; }
        public int PageID { get; set; }
        public string UserSno { get; set; }
        public string TrnType { get; set; }
        public string GetFilterQuery(List<Filter> filters)
        {
            var result = new StringBuilder();

            if (filters == null || filters.Count == 0)
            {
                return result.ToString();
            }

            var temp = new Dictionary<string, List<string>>();
            foreach (var filter in filters)
            {
                var key = filter.DBColumn + "~" + ((int)filter.Operator).ToString();

                if (!temp.ContainsKey(key))
                {
                    temp.Add(key, new List<string>());
                }

                //DateTime dateValue;
                //if (DateTime.TryParse(filter.Value, out dateValue))
                //{
                //    var dateString = dateValue.ToString("yyyy-MM-dd");
                //    if (filter.Operator != FilterOperator.EQUAL && filter.Operator != FilterOperator.NOTEQUAL)
                //    {
                //        dateString += (filter.Operator == FilterOperator.LESSTHAN)
                //            ? " 00:00:00" : " 23:59:59";
                //    }
                //    temp[key].Add(dateString);
                //}
                //else
                //{
                //    temp[key].Add(filter.Value);
                //}
                temp[key].Add(filter.Value);
            }

            foreach (var filter in temp)
            {
                var columnName = filter.Key.Split('~')[0];
                var values = "'" + string.Join("' , '", filter.Value) + "'";
                int length = filter.Value.Count;
                var filterOperator = (POMS.Entity.FilterOperator)Convert.ToInt32(filter.Key.Split('~')[1]);
                switch (filterOperator)
                {
                    case POMS.Entity.FilterOperator.EQUAL:
                        {
                            if (length == 1)
                            {
                                result.Append(string.Format(" {0} {1} {2} ", columnName, " = ", values));
                            }
                            else
                            {
                                result.Append(string.Format(" {0} {1} {2} {3} ", columnName, " IN (", values, ")"));
                            }
                            result.Append(" AND ");
                            break;
                        }
                    case POMS.Entity.FilterOperator.NOTEQUAL:
                        {
                            if (length == 1)
                            {
                                result.Append(string.Format(" {0} {1} {2} ", columnName, " != ", values));
                            }
                            else
                            {
                                result.Append(string.Format(" {0} {1} {2} {3} ", columnName, " NOT IN (", values, ")"));
                            }
                            result.Append(" AND ");
                            break;
                        }
                    case FilterOperator.GREATERTHAN:
                        {
                            result.Append(string.Format(" {0} {1} {2} ", columnName, " <= ", values));
                            result.Append(" AND ");
                            break;
                        }
                    case FilterOperator.LESSTHAN:
                        {
                            result.Append(string.Format(" {0} {1} {2} ", columnName, " >= ", values));
                            result.Append(" AND ");
                            break;
                        }
                }
            }

            var query = result.ToString();

            if (query.Length > 0)
            {
                query = query.Substring(0, query.Length - 4);
            }

            return query;
        }
    }
    public class ExportModel
    {
        public List<Export> ExportList { get; set; }
        public ExportType ExportType { get; set; }
        public PageRequest PageRequest { get; set; }
        public List<Filter> Filters { get; set; }
        public int PageId { get; set; }
    }
    public class Export
    {
        public string Title { get; set; }
        public bool Visible { get; set; }
        public string Name { get; set; }
    }
    //public enum PageId : int { EmployeeSearch = 1 }
    public enum ExportType : int { Excel = 1, CSV = 2 }
    public enum FilterOperator : int { EQUAL = 1, LESSTHAN = 2, GREATERTHAN = 3, NOTEQUAL = 4 }



    public class InboundReport
    {
        public int? RailReceiptSno { get; set; }
        public int? SurveyReportSno { get; set; }
        public int? CustomerSno { get; set; }
        public int? JobWorkOrderSno { get; set; }
        public int? WarehouseSno { get; set; }
        public int? GrnSno { get; set; }
        public DateTime? RRFromDate { get; set; }
        public DateTime? RRToDate { get; set; }
        public PageRequest PageRequest { get; set; }
        //public List<InboundReportDetails> InboundReportDetails { get; set; }
    }
    public class OutboundReportSearch
    {
        public int? RailReceiptSno { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        //public int?          SurveyReportSno { get; set; }
        public int? STASno { get; set; }
        public int? DeliveryOrderSno { get; set; }
        public int? DispatchSno { get; set; }
        public int? CustomerSno { get; set; }
        public int? ConsignmentNoSno { get; set; }
        public int? WarehouseSno { get; set; }
        public PageRequest PageRequest { get; set; }
    }

   
}
