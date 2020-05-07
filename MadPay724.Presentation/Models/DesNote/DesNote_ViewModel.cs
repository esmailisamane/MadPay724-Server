using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Models.DesNote
{
    public class DesNote_ViewModel
    {
        public long TopicCode { get; set; }
        public string MoeenName { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Remain { get; set; }
        public string SumDebit { get; set; }
        public string SumCredit { get; set; }
        public string SumRemain { get; set; }
    }

    public class DesNotePie_ViewModel
    {
        public long TopicCode { get; set; }
        public string MoeenName { get; set; }
        public long Debit { get; set; }
        public long Credit { get; set; }
        public long Remain { get; set; }
        public long SumDebit { get; set; }
        public long SumCredit { get; set; }
        public long SumRemain { get; set; }
        public decimal RemainPer { get; set; }
    }
}
