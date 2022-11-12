using Coppel.Datos;
using Coppel.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coppel.Negocio
{
    public class NDepartamento
    {
        public static DataTable Listar()
        {
            DDepartamento Datos = new DDepartamento();
            return Datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            DDepartamento Datos = new DDepartamento();
            return Datos.Buscar(valor);
        }

        public static string Insertar(string nombre)
        {
            DDepartamento Datos = new DDepartamento();
            //verficamos si el objeto esta creada
            string existe = Datos.Existe(nombre);
            if (existe.Equals("1"))
            {
                return "El departamento ya existe";
            }
            else
            {
                Departamento obj = new Departamento();
                obj.nombre = nombre;
                return Datos.Insertar(obj);
            }
            
        }

        public static string Actualizar(int id, string nombreAnterior,  string nombre)
        {
            DDepartamento Datos = new DDepartamento();
            Departamento obj = new Departamento();

            if(nombreAnterior.Equals(nombre))
            {
                //actualizamos los datos si tienen el mimso nbombre
                obj.iddepartamento = id;
                obj.nombre = nombre;
                return Datos.Actualizar(obj);
            }
            else
            {
                //si es diferente validamos que el nombre del departamento no exista
                string Existe = Datos.Existe(nombre);
                if (Existe.Equals("1"))
                {
                    return "El departamento ya existe";
                }
                else
                {
                    obj.iddepartamento = id;
                    obj.nombre = nombre;
                    return Datos.Actualizar(obj);
                }
            }
            
           
        }

        public static string Eliminar(int id)
        {
            DDepartamento Datos = new DDepartamento();
            return Datos.Eliminar(id);
        }
    }
}
