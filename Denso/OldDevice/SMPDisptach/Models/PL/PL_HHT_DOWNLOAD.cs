using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class PL_HHT_DOWNLOAD
    {
        public string DbType { get; set; }
        public string PATTERN_CODE { get; set; }
        public string SIL_CODE { get; set; } = null;
        public string PART_NO { get; set; } = null;
        public int? TOTAL_QTY { get; set; } = null;
        public int? SCAN_QTY { get; set; } = null;
        public int? BAL_QTY { get; set; } = null;
        public string CP_PROCESS { get; set; } = null;
        public string SIL_BARCODE { get; set; } = null;
        public string BARCODE1 { get; set; } = null;
        public string BARCODE2 { get; set; } = null;

        public bool IsMatchBarcode1SeqNo { get; set; }
        public string Barcode1SeqNo { get; set; }
        public bool IsMatchBarcode2SeqNo { get; set; }
        public string Barcode2SeqNo { get; set; }
        public int? BinQty { get; set; }
        public string CreatedBy { get; set; }
    }
}
