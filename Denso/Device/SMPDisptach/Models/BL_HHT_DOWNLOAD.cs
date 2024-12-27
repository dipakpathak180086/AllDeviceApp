
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class BL_HHT_DOWNLOAD
    {
        public DataTable BL_ExecuteTask(PL_HHT_DOWNLOAD objPl)
        {
            DL_HHT_DOWNLOAD objDl = new DL_HHT_DOWNLOAD();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
