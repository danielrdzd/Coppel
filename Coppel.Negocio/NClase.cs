using Coppel.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coppel.Negocio
{
    public class NClase
    {
        public static DataTable Listar()
        {
            DClase obj = new DClase();
            return obj.Listar();
        }
    }
}
