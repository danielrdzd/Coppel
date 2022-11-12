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
    public class NArticulo
    {

        public static DataTable Listar()
        {
            DArticulo obj = new DArticulo();
            return obj.Listar();
        }

        public static DataTable Buscar(int valor)
        {

            string existe;
            
            DArticulo obj = new DArticulo();
            existe = obj.Existe(valor);
            if (existe.Equals("1"))
            {
                return obj.Buscar(valor);
            }
            else
            {
                return new DataTable();
            }
     }


        public static string Existe(int valor)
        {
            string existe;
            string rpta = "";
            DArticulo obj = new DArticulo();
            existe = obj.Existe(valor);
            if (existe.Equals("1"))
            {
                rpta = "OK";
            }
            return rpta;
            
        }


        public static string Insertar(int sku, string articulo, string marca, string modelo, int departamento, int clase, int familia, int stock, int cantidad)
        {
            if(sku < 12)
            {
                return "EL SKU NO PUEDE SER MENOR A 12";
            }

            DArticulo obj = new DArticulo();
            //verificamos si existe ese articulo
            string existe = obj.Existe(sku);
            if (existe.Equals("1"))
            {
                return "El articulo con el sku  ya existe";
            }
            else
            {

                //creamos un objeto de tipo articulo
                Articulos objArticulo = new Articulos();
                //asignamos los valores
                objArticulo.Sku = sku;
                objArticulo.Articulo = articulo;
                objArticulo.Marca = marca;
                objArticulo.Modelo = modelo;
                objArticulo.Departamento = departamento;
                objArticulo.Clase = clase;
                objArticulo.Familia = familia;
                objArticulo.FechaAlta = DateTime.Now;
                objArticulo.FechaBaja = Convert.ToDateTime("1900-01-01");
                objArticulo.Descontinuado = 0;
                
                objArticulo.Stock = stock;
                objArticulo.Cantidad = cantidad;

                return obj.Insertar(objArticulo);
               
            }



        }


        public static string Actualizar(int id, int sku, int skuanterior, string articulo, string marca, string modelo, int departamento, int clase, int familia, int stock, int cantidad)
        {
            DArticulo obj = new DArticulo();
            //creamos un objeto de tipo articulo
            Articulos objArticulo = new Articulos();

           //comparamos los skus
                if(skuanterior == sku)
                {

                //asignamos los valores sin validar si el sku existe
                objArticulo.idArticulo = id;
                objArticulo.Sku = sku;
                objArticulo.Articulo = articulo;
                objArticulo.Marca = marca;
                objArticulo.Modelo = modelo;
                objArticulo.Departamento = departamento;
                objArticulo.Clase = clase;
                objArticulo.Familia = familia;
                objArticulo.FechaAlta = DateTime.Now;
                objArticulo.FechaBaja = Convert.ToDateTime("1900-01-01");
                objArticulo.Descontinuado = 0;

                objArticulo.Stock = stock;
                objArticulo.Cantidad = cantidad;

                return obj.Actualizar(objArticulo);

            }
            else
                {
                    //verificamos si existe ese sku 
                    string existe = obj.Existe(sku);
                    if (existe.Equals("1"))
                     {
                       return "El articulo con el sku  ya existe";
                    }
                    else
                    {

                    // asignamos los valores
                    objArticulo.idArticulo = id;
                    objArticulo.Sku = sku;
                    objArticulo.Articulo = articulo;
                    objArticulo.Marca = marca;
                    objArticulo.Modelo = modelo;
                    objArticulo.Departamento = departamento;
                    objArticulo.Clase = clase;
                    objArticulo.Familia = familia;
                    objArticulo.FechaAlta = DateTime.Now;
                    objArticulo.FechaBaja = Convert.ToDateTime("1900-01-01");
                    objArticulo.Descontinuado = 0;

                    objArticulo.Stock = stock;
                    objArticulo.Cantidad = cantidad;
                    return obj.Actualizar(objArticulo);
                }


                 }
               
               
            

        }


    }
}
