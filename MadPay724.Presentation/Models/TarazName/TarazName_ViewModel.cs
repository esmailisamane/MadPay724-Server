using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Models.TarazName
{
    public class TarazName_ViewModel
    {
        public int Level2 { get; set; }
        public string MoeenName { get; set; }
        public string SumRemain { get; set; }
        public string SumKol { get; set; }
        public long SumKolInt { get; set; }
    }


    public class TarazNamePie_ViewModel
    {
        public int Level1 { get; set; }
        public string MoeenName { get; set; }
        public long SumKol { get; set; }
        public decimal RemainPer { get; set; }
    }
}
