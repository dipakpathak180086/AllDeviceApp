
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class BL_HHT_UPLOAD
    {
        public DataTable BL_ExecuteTask(PL_HHT_UPLOAD objPl)
        {
            DL_HHT_UPLOAD objDl = new DL_HHT_UPLOAD();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
