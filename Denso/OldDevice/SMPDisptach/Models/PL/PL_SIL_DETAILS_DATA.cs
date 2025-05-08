using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class PL_DETAILS_DATA
    {
        public string DbType { get; set; }
        public string SILNo { get; set; }
        public string SILBarcode { get; set; }
        public string DNHASupBarcode { get; set; }
        public string CUSBarcode { get; set; }
        public string PartNo { get; set; }
        public string CustPart { get; set; }
        public string Qty { get; set; }
        public string ExtChar { get; set; }
        public string ProcessCode { get; set; }
        public string TruckNo { get; set; }
        public string ShipTo { get; set; }
        public string CustCode { get; set; }
        public string SequenceNo { get; set; }
        public string CustSeqNo { get; set; }
        public string UserId { get; set; }
        public string SILScannedOn { get; set; }
        public string DNHAScannedOn { get; set; }
        public string CustScannedOn { get; set; }
        public string DNHAPattern { get; set; }
        public bool MatchBarcode1SeqNo { get; set; }
        public string Barcode1SeqNo { get; set; }
        public bool MatchBarcode2SeqNo { get; set; }
        public string Barcode2SeqNo { get; set; }
    }
}
