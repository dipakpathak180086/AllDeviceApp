
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class BL_HHT_APK_FILE
    {
        public DataTable BL_ExecuteTask(PL_HHT_APK_FILE objPl)
        {
            DL_HHT_APK_FILE objDl = new DL_HHT_APK_FILE();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
