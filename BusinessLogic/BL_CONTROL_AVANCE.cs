using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BusinessEntity;
using DataAccess;
using System.Data;
namespace BusinessLogic
{
   public class BL_CONTROL_AVANCE
    {
        public List<BE_CABECERA> f_list_TareProyecto(BE_CABECERA obj)
        {
            return new DA_CONTROL_AVANCE().f_list_TareProyecto_D(obj);
        }
    }
}
