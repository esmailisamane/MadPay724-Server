using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.Models.Report
{
    public partial class DocGroups
    {
        public DocGroups()
        {
            Documents = new HashSet<Documents>();
        }

        public int Serial { get; set; }
        public int CompanyCode { get; set; }
        public int SecondaryDocNo { get; set; }
        public int PrimaryDocNo { get; set; }
        public string DocDate { get; set; }
        public byte DocTypeCode { get; set; }
        public byte Status { get; set; }
        public string DocTopicL1 { get; set; }
        public string DocTopicL2 { get; set; }
        public int UserId { get; set; }
        public DateTime MakeDate { get; set; }
        public string AttachFolderName { get; set; }
        public string DocNoteL1 { get; set; }
        public string DocNoteL2 { get; set; }
        public string FirstUser { get; set; }
        public string SecondUser { get; set; }
        public DateTime DocDateMiladi { get; set; }
        public int YearId { get; set; }
        public string SourceDataBase { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
    }
}