using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.Models.Report
{
    public partial class Documents
    {
        public int Serial { get; set; }
        public long TopicCode { get; set; }
        public int? DetailCode { get; set; }
        public int? CtopicCode { get; set; }
        public int? CtopicCode2 { get; set; }
        public string CommentL1 { get; set; }
        public string CommentL2 { get; set; }
        public int Row { get; set; }
        public decimal Debt { get; set; }
        public decimal Credit { get; set; }
        public decimal? AidDocNo { get; set; }
        public string AidDocdate { get; set; }
        public double? AidAmount { get; set; }
        public int? BudgetTopicId { get; set; }
        public int? BudgetId { get; set; }
        public int? ReferenceNo { get; set; }
        public string ReferenceTxt { get; set; }
        public string ReferenceDate { get; set; }
        public int? ProjectId { get; set; }
        public byte? ReferenceCheck { get; set; }
        public int CompanyCode { get; set; }
        public byte AuditDoPrint { get; set; }
        public int Ctopiccode3 { get; set; }
        public int Id { get; set; }
        public int YearId { get; set; }
        public int RelatedId { get; set; }
        public int DetailCompany { get; set; }
        public int CurrencyType { get; set; }
        public byte CashType { get; set; }
        public string SanamaId { get; set; }

        public virtual Customers CtopicCode2Navigation { get; set; }
        public virtual Customers CtopicCodeNavigation { get; set; }
        public virtual Customers Ctopiccode3Navigation { get; set; }
        public virtual Customers DetailCodeNavigation { get; set; }
        public virtual DocGroups DocGroups { get; set; }
        public virtual Categories TopicCodeNavigation { get; set; }
    }
}