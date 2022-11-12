using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coppel.Datos
{
    public class DClase
    {
        public DataTable Listar()
        {
            //necesitamos leer
            SqlDataReader Resultado;
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //obtenemos la conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("clase_listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                //llenamos la tabla
                tabla.Load(Resultado);
                return tabla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //veriricamos si la conexion esta abierta y la cerramos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

         
        }
    }
}
