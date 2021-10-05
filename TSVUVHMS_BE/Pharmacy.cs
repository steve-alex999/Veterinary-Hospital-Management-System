using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSVUVHMS_BE
{
    public class Pharmacy
    {
        public string InsId { get; set; }
        public string Supplier { get; set; }
        public string DrugCd { get; set; }
        public string DosagesPerPack { get; set; }
        public string Qtyineachpack { get; set; }
        public string BatchNo { get; set; }
        public string ExpDt { get; set; }

        public string Noofpackages { get; set; }
        public string Valueofdrug { get; set; }
        public string Drugqty { get; set; }
        public string SchemeCd { get; set; }
        public DateTime DtReceipt { get; set; }
        public string ReceiptNo { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }

        
        
    }
}
