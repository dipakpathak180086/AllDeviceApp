
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class BL_DETAILS_DATA
    {
        public DataTable BL_ExecuteTask(PL_DETAILS_DATA objPl)
        {
            DL_DETAILS_DATA objDl = new DL_DETAILS_DATA();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
