﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce_API.Dto
{
    public class OrderItemDto
    {
        public int Kid { get; set; }
        public int Id { get; set; }
        public int Code { get; set; }
        public double Quantity { get; set; }
        public string ItemName { get; set; }
        public string ImageUrl { get; set; }
        public string SupplierCode { get; set; }
        public string Barcode{ get; set; }
        public decimal CommitPrice { get; set; }
        public decimal PriceGstInc { get; set; }
        public string ItemNameCn { get; set; }
        public string Cat { get; set; }
        public string SCat { get; set; }
        public string SsCat { get; set; }
        public string Note{ get; set; }
        public double OrderTotal { get; set; }

    }
}
