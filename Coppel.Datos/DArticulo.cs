using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coppel.Entidades;
namespace Coppel.Datos
{
    public class DArticulo
    {
        //nos retorna un datatable con la informacion
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
                SqlCommand Comando = new SqlCommand("articulo_listar", SqlCon);
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
                //errores
                throw ex;
            }
            finally
            {
                //veriricamos si la conexion esta abierta y la cerramos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }
        //nos retorna un datatable con la informacion filtrada
        public DataTable Buscar(int valor)
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
                SqlCommand Comando = new SqlCommand("articulo_buscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                //pasamos el parametro
                Comando.Parameters.Add("@sku", SqlDbType.Int ).Value = valor;
                SqlCon.Open();
                //ejecutamos el comando
                Resultado = Comando.ExecuteReader();
                //llenamos la tabla datatable
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception ex)
            {
                //errores
                throw ex;
            }
            finally
            {
                //veriricamos si la conexion esta abierta y la cerramos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        //nos retorna string si existe o no un elemento con ese sku
        public string Existe(int valor)
        {
            //una varibale para retonar la respuesta
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("articulo_sku_existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@sku", SqlDbType.Int).Value = valor;
                //parametro de salida
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                //se lo agrego al comando
                Comando.Parameters.Add(ParExiste);
                //abruimos la conexion
                SqlCon.Open();
                //nonquery devuelve una respuesta
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                //veriricamos si la conexion esta abierta y la cerramos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;
        }
        //nos retorna un string si se inserto o no
        public string Insertar(Articulos obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                //mandamos el storeprocedure
                SqlCommand Comando = new SqlCommand("articulo_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                //mandamos los parametros
                Comando.Parameters.Add("@Sku", SqlDbType.Int).Value = obj.Sku;
                Comando.Parameters.Add("@Articulo", SqlDbType.VarChar).Value = obj.Articulo;
                Comando.Parameters.Add("@Marca", SqlDbType.VarChar).Value = obj.Marca;
                Comando.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = obj.Modelo;
                Comando.Parameters.Add("@Departamento", SqlDbType.Int).Value = obj.Departamento;
                Comando.Parameters.Add("@Clase", SqlDbType.Int).Value = obj.Clase;
                Comando.Parameters.Add("@Familia", SqlDbType.Int).Value = obj.Familia;
                Comando.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = obj.FechaAlta;
                Comando.Parameters.Add("@Stock", SqlDbType.Int).Value = obj.Stock;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = obj.Cantidad;
                Comando.Parameters.Add("@FechaBaja", SqlDbType.Date).Value = obj.FechaBaja;
                //abrimos la conexion a la bd
                SqlCon.Open();
                //mandamos la respuesta 
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Ocurrio un error en insertar articulo";



            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                //veriricamos si la conexion esta abierta y la cerramos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;

        }


        public string Actualizar(Articulos obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                //mandamos el storeprocedure
                SqlCommand Comando = new SqlCommand("articulo_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                //mandamos los parametros
                Comando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = obj.idArticulo;
                Comando.Parameters.Add("@Sku", SqlDbType.Int).Value = obj.Sku;
                Comando.Parameters.Add("@Articulo", SqlDbType.VarChar).Value = obj.Articulo;
                Comando.Parameters.Add("@Marca", SqlDbType.VarChar).Value = obj.Marca;
                Comando.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = obj.Modelo;
                Comando.Parameters.Add("@Departamento", SqlDbType.Int).Value = obj.Departamento;
                Comando.Parameters.Add("@Clase", SqlDbType.Int).Value = obj.Clase;
                Comando.Parameters.Add("@Familia", SqlDbType.Int).Value = obj.Familia;
                Comando.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = obj.FechaAlta;
                Comando.Parameters.Add("@Stock", SqlDbType.Int).Value = obj.Stock;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = obj.Cantidad;
                Comando.Parameters.Add("@Descontinuado", SqlDbType.Int).Value = obj.Descontinuado;
                Comando.Parameters.Add("@FechaBaja", SqlDbType.DateTime).Value = obj.FechaBaja;
                //abrimos la conexion a la bd
                SqlCon.Open();
                //mandamos la respuesta 
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Ocurrio un error en actualizar articulo";



            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                //veriricamos si la conexion esta abierta y la cerramos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;

        }
    }
}
