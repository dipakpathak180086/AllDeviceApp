using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class PL_LOG_INFO
    {
        public string DbType { get; set; }
        public DateTime Timestamp { get; set; }
        public string User { get; set; }
        public string Process { get; set; }
        public string Function { get; set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
    }
}
