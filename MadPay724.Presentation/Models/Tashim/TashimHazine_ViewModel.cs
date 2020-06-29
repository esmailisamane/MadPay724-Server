using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Models.Tashim
{
    public class TashimHazine_ViewModel
    {
        public int? ID { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public string Debit { get; set; }
        public string SumDebit { get; set; }
        public string DarsadShen { get; set; }
        public string DarsadPompaj { get; set; }
        public string DarsadHamlBeton { get; set; }
        public string DarsadTolidBeton { get; set; }
        public string HazineShen { get; set; }
        public string HazinePompaj { get; set; }
        public string HazineHamlBeton { get; set; }
        public string HazinetolidBeton { get; set; }
        public string SumHazineShen { get; set; }
        public string SumHazinePompaj { get; set; }
        public string SumHazineHamlBeton { get; set; }
        public string SumHazineTolidBeton { get; set; }
        public string VorodiShen { get; set; }
        public string FiTolidShen { get; set; }
        public string DaramadPompaj { get; set; }
        public string FiPompaj { get; set; }
        public string DaramadHamlBeton { get; set; }
        public string FiHamlBeton { get; set; }
        public string DaramadForoshbeton { get; set; }
        public string FiForoshBeton { get; set; }
        public string SumHazinehaWithoutShen { get; set; }
        public string SumKolHazinehaWithoutShen { get; set; }

    }
}
