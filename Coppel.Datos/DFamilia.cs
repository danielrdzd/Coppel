using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coppel.Datos
{
    public class DFamilia
    {
        //listar familias
        public DataTable Listar()
        {
            //leer una secuencia de filas
            SqlDataReader Resultado;
            //datatable es una data en memoria
            DataTable Tabla = new DataTable();
            //conexion a la base de datos
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //creamos la cadena de conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("familia_listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                //ejecutamos el comando
                Resultado = Comando.ExecuteReader();
                //llenamos la tabla datatable
                Tabla.Load(Resultado);
                return Tabla;
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
