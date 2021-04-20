﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Sync.Models
{
    public partial class Card
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
//        public string InitialTerm { get; set; }
        public string ShortName { get; set; }
        public string TradingName { get; set; }
        public string CorpNumber { get; set; }
        public byte? Directory { get; set; }
//        public string GstNumber { get; set; }
        public double GstRate { get; set; }
        public byte CurrencyForPurchase { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Contact { get; set; }
        public string NameB { get; set; }
        public string CompanyB { get; set; }
        public string Address1B { get; set; }
        public string Address2B { get; set; }
        public string CityB { get; set; }
        public string CountryB { get; set; }
        public string Postal1 { get; set; }
        public string Postal2 { get; set; }
        public string Postal3 { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal ShippingFee { get; set; }
        public bool AcceptMassEmail { get; set; }
        public string Web { get; set; }
        public string CatAccess { get; set; }
        public byte CatAccessGroup { get; set; }
        public int AccessLevel { get; set; }
        public int DealerLevel { get; set; }
        public double Discount { get; set; }
        public double? MDiscountRate { get; set; }
        public byte Language { get; set; }
        public decimal TransTotal { get; set; }
        public decimal Balance { get; set; }
        public string Note { get; set; }
        public int? LastBranchId { get; set; }
        public DateTime LastPostTime { get; set; }
        public int TotalPosts { get; set; }
        public string PmEmail { get; set; }
        public string PmDdi { get; set; }
        public string PmMobile { get; set; }
        public string SmName { get; set; }
        public string SmEmail { get; set; }
        public string SmDdi { get; set; }
        public string SmMobile { get; set; }
        public string ApName { get; set; }
        public string ApEmail { get; set; }
        public string ApDdi { get; set; }
        public string ApMobile { get; set; }
        public int CreditTerm { get; set; }
        public decimal CreditLimit { get; set; }
        public bool? Approved { get; set; }
        public decimal PurchaseNza { get; set; }
        public decimal PurchaseAverage { get; set; }
        public decimal M1 { get; set; }
        public decimal M2 { get; set; }
        public decimal M3 { get; set; }
        public decimal M4 { get; set; }
        public decimal M5 { get; set; }
        public decimal M6 { get; set; }
        public decimal M7 { get; set; }
        public decimal M8 { get; set; }
        public decimal M9 { get; set; }
        public decimal M10 { get; set; }
        public decimal M11 { get; set; }
        public decimal M12 { get; set; }
        public byte WorkingOn { get; set; }
        public bool BuyOnline { get; set; }
        public int? MainCardId { get; set; }
        public bool IsBranch { get; set; }
        public bool StopOrder { get; set; }
        public string StopOrderReason { get; set; }
        public int? Sales { get; set; }
 //       public int? Support { get; set; }
        public int CustomerAccessLevel { get; set; }
        public int? BranchCardId { get; set; }
        public bool NoSysQuote { get; set; }
        public string TechEmail { get; set; }
 //       public byte OurBranch { get; set; }
        public int? PersonalId { get; set; }
        public long? TotalOnlineOrderPoint { get; set; }
        public bool? Registered { get; set; }
        public string Barcode { get; set; }
        public int Points { get; set; }
 //       public string SitePass { get; set; }
 //       public string Tills { get; set; }
 //       public string DefaultLanguage { get; set; }
 //       public string State { get; set; }
 //       public string Area { get; set; }
        public string Mobile { get; set; }
 //       public string Qq { get; set; }
//        public string RegCode { get; set; }
 //       public string CorpRep { get; set; }
 //       public string CorpRepMobile { get; set; }
 //       public string Gm { get; set; }
 //       public string GmMobile { get; set; }
 //       public string IdentityId { get; set; }
 //       public string CustomerNumber { get; set; }
//        public string ResetPwdCc { get; set; }
//        public DateTime? Dob { get; set; }
 //       public string TaxNumber { get; set; }
 //       public string BankName { get; set; }
 //       public string AccountNumber { get; set; }
 //       public string Surname { get; set; }
//        public string Midname { get; set; }
 //       public string DdAccountNumber { get; set; }
 //       public string Url { get; set; }
 //       public string RootPath { get; set; }
 //       public byte SupportLevel { get; set; }
 //       public double? TargetRental { get; set; }
 //       public double? TargetSales { get; set; }
 //       public double? TargetPoint { get; set; }
        public string Zip { get; set; }
        //public bool Updated{ get; set; }
       // public byte[] TimeStamp { get; set; }
    }
}
