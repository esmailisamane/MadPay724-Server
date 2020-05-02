using System;
using System.Collections.Generic;
using System.Text;

namespace ReportInfrastructure.Sql
{
    public class MultipleOutputModel<TDataModel, TMessageModel>
    {
        public TMessageModel message { get; set; }
        public TDataModel data { get; set; }
    }
}
