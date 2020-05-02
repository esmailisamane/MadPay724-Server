using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.Models.Report
{
    public partial class Customers
    {
        public Customers()
        {
            DocumentsCtopicCode2Navigation = new HashSet<Documents>();
            DocumentsCtopicCodeNavigation = new HashSet<Documents>();
            DocumentsCtopiccode3Navigation = new HashSet<Documents>();
            DocumentsDetailCodeNavigation = new HashSet<Documents>();
            InversePersonId1Navigation = new HashSet<Customers>();
            InversePersonId3Navigation = new HashSet<Customers>();
        }

        public int CustId { get; set; }
        public int CustomerGrpId { get; set; }
        public string CustName { get; set; }
        public decimal Balance { get; set; }
        public decimal FirstBalance { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string WebSite { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Pobox { get; set; }
        public string AccDetailCode { get; set; }
        public decimal MaxCredit { get; set; }
        public byte ServiceCalcType { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal ExtServicePrice { get; set; }
        public double RevenuePercent { get; set; }
        public string EconomicNumber { get; set; }
        public string PostalCode { get; set; }
        public byte State { get; set; }
        public DateTime ModifyDate { get; set; }
        public string OperatorId { get; set; }
        public string CustomerNote { get; set; }
        public byte? ValuationType { get; set; }
        public int? ProjectId { get; set; }
        public int? BudgetId { get; set; }
        public double? InfoWeight { get; set; }
        public string InfoDate { get; set; }
        public byte GrpActionCustomer { get; set; }
        public double? ContactRate { get; set; }
        public string AccCtopicCode { get; set; }
        public string AccCtopicCode2 { get; set; }
        public double? BankId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public int? AccountKind { get; set; }
        public string BankReports { get; set; }
        public string ManageName { get; set; }
        public string ManagerSells { get; set; }
        public string ContactNo { get; set; }
        public string DiscountNote { get; set; }
        public double? Discount { get; set; }
        public int? DayTime { get; set; }
        public byte ConveyKind { get; set; }
        public int? ArzTypeId { get; set; }
        public byte AccStateDefault { get; set; }
        public string NationalId { get; set; }
        public string Mobile { get; set; }
        public int? CustomersRow { get; set; }
        public int PersonId1 { get; set; }
        public string EstablishDate { get; set; }
        public int? SellsMethod { get; set; }
        public int? SellsEmporium { get; set; }
        public byte SellsDefaultState { get; set; }
        public int? MasirId { get; set; }
        public decimal MaxCreditCurrentForm { get; set; }
        public byte CustomerActive { get; set; }
        public string ReagentName { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public int PersonId3 { get; set; }
        public int UseUnitId { get; set; }
        public int? InsertAutoEffectId { get; set; }
        public int? EffectId { get; set; }
        public int? CustomerGrpId2 { get; set; }
        public double? PurchasePercent { get; set; }
        public string CustAccountNumber { get; set; }
        public string TechnicalCode { get; set; }
        public string AccCtopicCode3 { get; set; }
        public long? AccTopicCode { get; set; }
        public string RegisterNumber { get; set; }
        public byte? HctarafGaradadTypeCode { get; set; }
        public byte? HckharidarTypeCode { get; set; }
        public string CustFirstName { get; set; }
        public string PerCityCode { get; set; }
        public int StateCode { get; set; }
        public int CityCode { get; set; }
        public string LastUser { get; set; }
        public string FirstUser { get; set; }
        public byte CustomerState { get; set; }
        public byte HcforoushandeType1Code { get; set; }
        public decimal Max4WaterCo { get; set; }
        public byte SupervisorAllocation { get; set; }
        public string CustomerCheckNote { get; set; }
        public string CustNameL2 { get; set; }
        public byte? Sex { get; set; }
        public long? AlternativeCustId { get; set; }
        public string VatValidityDate { get; set; }
        public string BusinesslicenseValidityDate { get; set; }
        public string LeaseValidityDate { get; set; }
        public double? Area { get; set; }
        public string Degree { get; set; }
        public double? Score { get; set; }
        public int? NumberCreditInstallments { get; set; }
        public decimal? MaxWeeklyShoppingCredit { get; set; }
        public decimal? MinWeeklyShoppingAmount { get; set; }
        public byte? DayOrder { get; set; }
        public long? PaymentCode { get; set; }
        public long? AlternativeCustId2 { get; set; }
        public string TelegramChatId { get; set; }
        public byte? PostControl { get; set; }
        public byte? TTabeiat { get; set; }
        public string PelakSabtiAsli { get; set; }
        public string PelakSabtiFari { get; set; }
        public string BankIdc { get; set; }
        public double? DiscountOne { get; set; }
        public string CarType { get; set; }
        public string ExternalId { get; set; }

        public virtual Customers PersonId1Navigation { get; set; }
        public virtual Customers PersonId3Navigation { get; set; }
        public virtual ICollection<Documents> DocumentsCtopicCode2Navigation { get; set; }
        public virtual ICollection<Documents> DocumentsCtopicCodeNavigation { get; set; }
        public virtual ICollection<Documents> DocumentsCtopiccode3Navigation { get; set; }
        public virtual ICollection<Documents> DocumentsDetailCodeNavigation { get; set; }
        public virtual ICollection<Customers> InversePersonId1Navigation { get; set; }
        public virtual ICollection<Customers> InversePersonId3Navigation { get; set; }
    }
}