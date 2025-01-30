using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class PL_FRACTION
    {
        public string DbType { get; set; }
        public string PartNo { get; set; }
        public string MasterKanban { get; set; }
        public string ChildKanban { get; set; }
        public int MasterQty { get; set; }
        public int ChildQty { get; set; }
        public string CreatedBy { get; set; }
    }
}
