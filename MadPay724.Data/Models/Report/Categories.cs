using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.Models.Report
{
    public partial class Categories
    {
        public Categories()
        {
            Documents = new HashSet<Documents>();
        }

        public long TopicCode { get; set; }
        public string MoeenNameL1 { get; set; }
        public string MoeenNameL2 { get; set; }
        public int LevelId { get; set; }
        public int FinancialId { get; set; }
        public int AuditId { get; set; }
        public int? Essence { get; set; }
        public int? ReactionForRepEssence { get; set; }
        public int? TaxonomyType { get; set; }
        public long? TaxonomyTopicCode { get; set; }
        public long? LastYearTopicCode { get; set; }
        public long? LastTopicCode { get; set; }
        public int? AidInfoType { get; set; }
        public int? AuditReferenceNo { get; set; }
        public string AuditReferenceTxt { get; set; }
        public string RecalInterfaceId { get; set; }
        public int KindInsertBudgetCode { get; set; }
        public int? BudgetTopicId { get; set; }
        public int? ProjectId { get; set; }
        public DateTime MakeDate { get; set; }
        public decimal ConstructionPercent { get; set; }
        public decimal BudgetPrice { get; set; }
        public string UserRelated { get; set; }
        public byte Active { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
    }
}