using Coppel.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coppel.Datos
{
    public class DDepartamento
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
                SqlCommand Comando = new SqlCommand("departamento_listar", SqlCon);
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

        public DataTable Buscar(string valor)
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
                SqlCommand Comando = new SqlCommand("departamento_buscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                //agregamos parametro
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
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

        public string Existe(string valor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("departamento_existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                //parametro de salida
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                //se lo agrego al comando
                Comando.Parameters.Add(ParExiste);
                SqlCon.Open();
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

        public string Insertar(Departamento Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("departamento_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.nombre;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el departamento";
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

        public string Actualizar(Departamento Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("departamento_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.nombre;
                Comando.Parameters.Add("@iddepartamento", SqlDbType.Int).Value = Obj.iddepartamento;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el departamento";
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


        public string Eliminar(int id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon = Conexion.getIntancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("departamento_eliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@iddepartamento", SqlDbType.Int).Value = id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el departamento";
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

