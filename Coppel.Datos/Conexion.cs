using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coppel.Datos
{
    public class Conexion
    {
        private string Base; //nombre de la base de datos
        private string Servidor; //servidort de la BD
        private string Usuario; //usuario para acceder
        private string Clave; //clave usuario
        private bool Seguridad; //decidimos si es aut. windows o sql server
        //objeto que tiene la conexion
        private static Conexion Con = null;

        //hacemos el constructor privado para que la clase conexion no pueda ser instanciada en otro lado
        private Conexion()
        {
            this.Base = "Coppel";
            this.Servidor = "GRAFY";
            this.Usuario = "daniel";
            this.Clave = "123";
            this.Seguridad = true; //true=windows false=SQlserver Autehntication
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                //cadena general
                Cadena.ConnectionString = "Server="+this.Servidor+";Database="+ this.Base+ ";";
                if (this.Seguridad)
                {
                    //seguridad windows
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else{
                    //seguridad sqlserver
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id="+this.Usuario+";Password="+this.Clave;
                }
            }
            catch (Exception ex)
            {
             
                Cadena = null;
                throw ex;
            }

            //retornamos la cadena
            return Cadena;
        }


        //metodo para crear la instancia
        public static Conexion getIntancia()
        {
            if(Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }
}
