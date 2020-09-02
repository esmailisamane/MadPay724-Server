using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Models.Seller
{
    public class HazineMashinAllat_ViewModel
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string SumHazineha { get; set; }
        public string Metraj { get; set; }
        public string SahmDarBahayeTamamShode { get; set; }
        public string SumKolHazine { get; set; }
        public string SumKolSahmDarBahayeTamamShode { get; set; }
    }


    public class HazineShenOrMase_ViewModel
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Hazine { get; set; }
        public string HazineShenOrMaseWithoutTashim { get; set; }
        
    }

    public class HazineMakhlot_ViewModel
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string HazineKol { get; set; }
        public string DarsadHamlKhodeman { get; set; }
        public string MidPriceMakhlotVorodi { get; set; }

    }
}
