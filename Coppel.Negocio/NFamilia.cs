using Coppel.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coppel.Negocio
{
    public class NFamilia
    {

        //listar
        public static DataTable Listar()
        {
            DFamilia obj = new DFamilia();
            return obj.Listar();
        }


    }
}
