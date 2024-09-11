using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLinea
{
    internal class Producto
    {
        //ATRIBUTOS PRIVADOS DE LOS PRODUCTOS
        private string nombre;
        private string descripcion;
        private int precio;


        //CONSTRUCTOR DE PRODUCTOS PENSANDO EN UN FUTURO MEJORAR EL CÓDIGO A QUE TAMBIÉN SE PUEDAN GENERAR PRODUCTOS NUEVOS
        public Producto(string nombre, string descripcion, int precio)
        {

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        //NOS PERMITE OBTENER LA INFOMACIÓN DE LOS PRODUCTOS
        public string getNombre()
        {
            return nombre;
        }
        public string getDescripcion()
        {
            return descripcion;
        }
        public int getPrecio()
        {
            return precio;
        }

    }
}
