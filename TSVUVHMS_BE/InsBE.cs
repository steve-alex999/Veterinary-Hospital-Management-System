using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSVUVHMS_BE
{
    class InsBE
    {
        public string Atype { get; set; }
        public string Vdate { get; set; }
        public string Age { get; set; }
        public int Gender { get; set; }
        public string AnimalOwner { get; set; }
        public string StateCode { get; set; }
        public string Dcode { get; set; }
      
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
