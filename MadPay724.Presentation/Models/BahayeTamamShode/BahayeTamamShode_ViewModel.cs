﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Models.BahayeTamamShode
{
    public class BahayeTamamShode_ViewModel
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string BetonC25 { get; set; }
        public string BetonC30 { get; set; }
        public string BetonC35 { get; set; }
        public string BetonC40 { get; set; }
        public string SumRow { get; set; }
        public string Description { get; set; }
    }


    public class BahayeTamamShode2_ViewModel
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string BetonC25 { get; set; }
        public string BetonC30 { get; set; }
        public string BetonC35 { get; set; }
        public string BetonC40 { get; set; }
        public string SumBeton { get; set; }
        public string SumHazinehaWithoutShen { get; set; }
        public string SumKolHazinehaWithoutShen { get; set; }
    }
}
