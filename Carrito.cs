using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLinea
{
    
    internal class Carrito
    {
        private List<Producto> productos;//LISTA DE PRODUCTOS EN EL CARRITO

        public Carrito() //SE HACE EL CONSTRUCTOR DEL CARRITO QUE SERÍA BASICAMENTE UNA LISTA DE PRODUCTOS
        {
            productos = new List<Producto>();
        }

        public string AgregarProducto(Producto producto, int pza)//AGREGA PRODUCTOS A LA LISTA DE PRODUCTOS DEPENDIENDO LAS PIEZAS QUE HAYAS SELECCIONADO AGREGAR
        {
            for (int i = 0; i < pza; i++)
            {
                productos.Add(producto);
            }
            return($"El producto {producto.getNombre()} ha sido agregado al carrito {pza} veces.\n");
        }
        public string EliminarProducto(Producto producto, int pza)//MÉTODO ADICIONAL
        {
            int cantidad = productos.FindAll(p => p == producto).Count; // CUENTA CUANTOS PRODUCTOS HAY EN EL CARRITO DEL SELECCIONADO

            if (cantidad == 0)
            {
                return $"El producto {producto.getNombre()} no está agregado en el carrito.\n"; //NO SE ELIMINA SI NO HA SIDO AGREGADO
            }
            else if (pza >= cantidad)
            {
                // SI LA CANTIDAD A ELIMINAR ES MAYOR O IGUAL A LAS PIEZAS QUE HAY, QUE SE ELIMINEN TODAS
                productos.RemoveAll(p => p == producto); // ELIMINA TODAS LAS PIEZAS DEL PRODUCTO
                return $"Se han eliminado todas las piezas de {producto.getNombre()} del carrito.\n";
            }
            else
            {
                // ELIMINAR SÓLO CIERTA CANTIDAD
                for (int i = 0; i < pza; i++)
                {
                    productos.Remove(producto); // ELIMINA UNA PIEZA A LA VEZ, DEPENDIENDO CUANTAS SE HAYAN PEDIDO ELIMINAR
                }
                return $"Se han eliminado {pza} piezas de {producto.getNombre()} del carrito.\n";
            }
        }


        public string VerCarrito()
        {
            if (productos.Count == 0)//SI NO HAS METIDO NADA AL CARRO LANZA UN MENSAJE
            {
                return "El carrito está vacío\n.";
            }

            StringBuilder resultado = new StringBuilder();//LA CLASE STRINGBUILDER NOS PERMITIRÁ MANEJAR CADENAS DE TEXTO MUTABLES (A DIFERENCIA DE UNA STRING) A TRAVES DE LA VARIABLE RESULTADO
            resultado.AppendLine("Productos en el carrito:");//APPENDLINE AGREGA UNA LINEA DE TEXTO AL FINAL Y UN SALTO DE LÍNEA

            foreach (var producto in productos) //RECORRE CADA UNO DE LOS PRODUCTOS EN EL CARRITO
            {
                resultado.AppendLine($"{producto.getNombre()} - ${producto.getPrecio()}");//VA GUARDANDO CADA PRODUCTO
            }

            return resultado.ToString(); // RETORNA EL STRING CON LA LISTA DE PRODUCTOS. EL TO STRING CONVIERTE EL CONTENIDO ACUMULADO EN UN SOLO STRING.
        }

        public string CalcularTotal()
        {
            int total = 0;//INICIALIZA LA VARIABLE TOTAL EN 0
            foreach (var producto in productos)
            {
                total = total + producto.getPrecio();//REALIZA EL ACUMULADO DE PRECIOS
            }
            return $"El costo total de los productos agregados en su carrito es de ${total}\n";//RETORNA EL TOTAL
        }
    }

}
