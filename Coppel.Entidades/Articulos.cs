using System;


namespace Coppel.Entidades
{
    public class Articulos
    {
        //propiedades
        public int idArticulo { get; set; }
        public int Sku {get; set;}
        public string Articulo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Departamento { get; set; }
        public int Clase { get; set; }
        public int Familia { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }
        public int Descontinuado { get; set; }
        public DateTime FechaBaja { get; set; }

    }
}
