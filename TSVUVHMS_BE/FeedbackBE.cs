using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSVUVHMS_BE
{
    public class FeedbackBE
    {
        public string UniqueInsId { get; set; }
        public DateTime VisitDate { get; set; }
        public string RegNo { get; set; }
        public string VisitId { get; set; }
        public string RegFeePaid { get; set; }
        public string TestFeePaid { get; set; }
        public string OtherAmtPaid { get; set; }
        public string Reg_ServiceQuality { get; set; }
        public string Doctor_ServiceQuality { get; set; }
        public string Phar_ServiceQuality { get; set; }
        public string Free_DrugIssued { get; set; }
        public string Drugs_Pfrmoutside { get; set; }
        public string CleanlinessInHosp { get; set; }
        public string Overall_Experience { get; set; }
        public string ExcessRegFeeTaken { get; set; }
        public string ExcessRegFee { get; set; }
        public string ExcessTestFeeTaken { get; set; }
        public string ExcessTestFee { get; set; }
        public string FreeDrugsNotIssued { get; set; }
        public string CloseFb_Reason { get; set; }
    }
}
