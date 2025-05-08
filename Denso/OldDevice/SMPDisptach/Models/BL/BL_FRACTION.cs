
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class BL_FRACTION
    {
        public DataTable BL_ExecuteTask(PL_FRACTION objPl)
        {
            DL_FRACTION objDl = new DL_FRACTION();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
