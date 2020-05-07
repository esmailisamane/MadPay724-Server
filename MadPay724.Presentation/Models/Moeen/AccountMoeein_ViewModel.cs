using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Models.Moeen
{
    public class AccountMoeein_ViewModel
    {
        public long TopicCode { get; set; }
        public string MoeenName { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Remain { get; set; }

    }

    public class AccountMoeeinBar_ViewModel
    {
        public long TopicCode { get; set; }
        public string MoeenName { get; set; }
        public long Debit { get; set; }
        public long Credit { get; set; }
        public long Remain { get; set; }

    }
}
