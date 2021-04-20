﻿using FarroAPI.Entities;
using FarroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FarroAPI.Controllers
{
    [Route("api/SalesItemReport")]
    public class SalesItemReportController : Controller
    {
        private readonly farroContext _context;

        public SalesItemReportController(farroContext context
            )
        {
            this._context = context;
        }
        [HttpPost("DateRange")]
        public async Task<IActionResult> GetSalesItemReport([FromBody] SalesItemReportFilterDto filter)
        {
                // Set NoTracking for ChangeTracker
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var resultList = new List<SalesItemReportDto>();

                // Make commandText ready
                string commandText = null;

                string branchIds = "";
                if (filter.BranchIds.Count > 0)
                {
                    branchIds = " and b.id in (";
                    for (int i = 0; i < filter.BranchIds.Count; i++)
                    {
                        branchIds += filter.BranchIds[i].ToString();
                        if (i < filter.BranchIds.Count - 1)
                            branchIds += ",";
                        else
                            branchIds += ") ";
                    }
                }
                else
                {
                    branchIds = " and b.fax <> 'Hidden4MReport' ";
                }

                string supplierIds = "";
                if (filter.SupplierIds.Count > 0)
                {
                    supplierIds = " and c.supplier in (";
                    for (int i = 0; i < filter.SupplierIds.Count; i++)
                    {
                        supplierIds += filter.SupplierIds[i].ToString();
                        if (i < filter.SupplierIds.Count - 1)
                            supplierIds += ",";
                        else
                            supplierIds += ") ";
                    }
                }

                string subSubCategories = "";
                if (filter.SubSubCategories.Count > 0)
                {
                    subSubCategories = " and (";
                    for (int i = 0; i < filter.SubSubCategories.Count; i++)
                    {
                        subSubCategories += @"(s.cat = '" + filter.SubSubCategories[i].CategoryName + @"' ";
                        if (filter.SubSubCategories[i].SubCategoryName.ToLower() != "all")
                            subSubCategories += @" and s.s_cat = '" + filter.SubSubCategories[i].SubCategoryName + @"' ";
                        else
                        {
                            if (filter.SubSubCategories[i].SubSubCategoryName.ToLower() != "all")
                                subSubCategories += @" and s.ss_cat = '" + filter.SubSubCategories[i].SubSubCategoryName + @"' ";
                        }
                        subSubCategories += @")";
                        if (i < filter.SubSubCategories.Count - 1)
                            subSubCategories += " or ";
                        else
                            subSubCategories += ") ";
                    }
                }

                commandText = @"select b.id as BranchId
                                , c.code as Code
	                            , (select name from code_relations where code = c.code) as Description
	                            , (select name_cn from code_relations where code = c.code) as Name
	                            , (select cat from code_relations where code = c.code) as Category
	                            , (select s_cat from code_relations where code = c.code) as SubCategory
	                            , (select ss_cat from code_relations where code = c.code) as SubSubCategory
                                , round(sum(s.commit_price * s.quantity), 2) as Sales
                                , round(sum((s.commit_price - s.supplier_price) * s.quantity), 2) as Profit
	                            , round(sum(s.quantity), 3) as Quantity
                            from sales s
                            join invoice i on s.invoice_number = i.invoice_number
                            join branch b on i.branch = b.id
                            join code_relations c on s.code = c.code
                            where i.commit_date >= @startDateTime
                            and i.commit_date < @endDateTime
                            and i.tax=isnull(@tax,i.tax)
                            and s.code <> '-900001'"
                            + subSubCategories + branchIds + supplierIds +
                            @" group by b.id, c.code
                            order by b.id, c.code";

                // Run SQL Command
                using (var connection = (SqlConnection)_context.Database.GetDbConnection())
                {

                    var command = new SqlCommand(commandText, connection);
                    command.Parameters.AddWithValue("@startDateTime", filter.StartDateTime);
                    command.Parameters.AddWithValue("@endDateTime", filter.EndDateTime);
                if (filter.OnlineOrder)
                {
                    command.Parameters.AddWithValue("@tax", 0);
                }
                else
                {
                    command.Parameters.AddWithValue("@tax", DBNull.Value);
                }
                _context.Database.OpenConnection();
                    using (var result = await command.ExecuteReaderAsync())
                    {
                        while (result.Read())
                        {
                            SalesItemReportDto dto = new SalesItemReportDto
                            {
                                BranchId = Convert.ToInt32(result["BranchId"]),
                                Code = Convert.ToInt32(result["Code"]),
                                Description = Convert.ToString(result["Description"]),
                                Name = Convert.ToString(result["Name"]),
                                Category = Convert.ToString(result["Category"]),
                                SubCategory = Convert.ToString(result["SubCategory"]),
                                SubSubCategory = Convert.ToString(result["SubSubCategory"]),
                                AmountWithoutGST = Convert.ToDecimal(result["Sales"] is DBNull ? 0 : result["Sales"]),
                                ProfitWithoutGST = Convert.ToDecimal(result["Profit"] is DBNull ? 0 : result["Profit"]),
                                Quantity = Convert.ToInt32(result["Quantity"])
                            };
                            resultList.Add(dto);
                        }
                    }
                    _context.Database.CloseConnection();

                    return Ok(resultList);
                }
            
        }
    }
}
