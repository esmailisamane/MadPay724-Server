using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ReportInfrastructure.Sql
{
    public static class ErrorNumbers
    {
        public static int CustomErrors
        {
            get { return 50000; }
        }
    }
    public class BaseModel
    {
        private string _token;

        [MaxLength(10)]
        public string Culture { get; set; }
        [MaxLength(50)]
        public string Token
        {
            get
            { return _token; }
            set { _token = value; }
        }

        [MaxLength(15)]
        public string IP { get; set; }

        public int BranchID { get; set; }

    }

    public class PagingModel : BaseModel
    {
        private int _PageSize { get; set; } = 20;
        private int _PageNumber { get; set; } = 1;

        public int? PageSize { get { return _PageSize; } set { _PageSize = value > 0 ? value ?? 0 : 20; } }
        public int? PageIndex { get { return _PageNumber; } set { _PageNumber = value > 0 ? value ?? 0 : 1; } }
    }

    public class IDModel<TKey> : ReportInfrastructure.Sql.BaseModel
    {
        public TKey ID { get; set; }

    }

    public class PIDModel<Tkey> : ReportInfrastructure.Sql.BaseModel
    {
        public Tkey PID { get; set; }
    }
}
