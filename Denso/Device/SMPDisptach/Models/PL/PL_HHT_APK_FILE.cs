using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class PL_HHT_APK_FILE
    {
        public string DbType { get; set; }
        public string FileName { get; set; }
        public string Version { get; set; }
        public byte[] FileData { get; set; }
        public string CreatedBy { get; set; }
    }
}
