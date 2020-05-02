using System;
using System.Collections.Generic;
using System.Text;

namespace ReportInfrastructure.Sql
{
    public enum ReturnType
    {
        OnlyData = 1,
        OnlyMessage = 2,
        MessageAndData = 3,
        DataAndMessage = 4,
    }
}
