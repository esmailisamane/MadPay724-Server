using System;
using System.Collections.Generic;
using System.Text;

namespace ReportInfrastructure.Sql
{
    public class DBMessageModel
    {
        public int MessageID { get; set; }
        public string MessageKey { get; set; }
        public string Value { get; set; }
        public int StateID { get; set; }
        public string State { get; set; }
    }
}
