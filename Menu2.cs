using System;
using System.Collections.Generic;

namespace TiendaLinea
{
    internal class Menu2
    {
        private List<Opciones> opciones;
        private List<Producto> inventario;
        private Carrito carrito; 

        public Menu2() //OPCIONES DEL MENÚ
        {
            carrito = new Carrito(); //SE CREA UN CARRITO

            // SE DEFINE EL INVENTARIO DE PRODUCTOS
            inventario = new List<Producto>()//INVENTARIO DE PRODUCTOS PRECARGADOS EN UNA LISTA
            {
                new Producto("Arroz", "Bolsa de 1kg de arroz integral", 40),
                new Producto("Frijoles", "Lata de frijoles refritos", 25),
                new Producto("Aceite de oliva", "Botella de 500ml de aceite de oliva virgen extra", 120),
                new Producto("Pan de caja", "Paquete de pan de caja integral", 35),
                new Producto("Leche", "Caja de 1 litro de leche entera", 22),
                new Producto("Cereal", "Caja de cereal de avena", 50),
                new Producto("Huevos", "Cartón de 12 huevos", 40),
                new Producto("Pasta", "Paquete de 500g de pasta de espagueti", 18),
                new Producto("Harina", "Bolsa de 1kg de harina de trigo", 30),
                new Producto("Azúcar", "Bolsa de 1kg de azúcar refinada", 28),
                new Producto("Café", "Frasco de 250g de café soluble", 85),
                new Producto("Té verde", "Caja con 20 sobres de té verde", 60),
                new Producto("Salsa de tomate", "Lata de 500g de salsa de tomate", 20),
                new Producto("Sal", "Bolsa de 1kg de sal de mesa", 12),
                new Producto("Jabón para ropa", "Bolsa de 1.5kg de detergente en polvo", 95),
                new Producto("Shampoo", "Botella de 750ml de shampoo para cabello normal", 70),
                new Producto("Papel higiénico", "Paquete de 12 rollos de papel higiénico", 80),
                new Producto("Desinfectante", "Botella de 1 litro de desinfectante multiusos", 45),
                new Producto("Queso", "Paquete de 200g de queso manchego", 65),
                new Producto("Jugo de naranja", "Botella de 1 litro de jugo de naranja", 38)
            };

            //SE DEFINE LA LISTA DE OPCIONES DEL MENÚ
            opciones = new List<Opciones>() {
                new Opciones("Ver catálogo de productos", MostrarCatalogo),
                new Opciones("Agregar productos al carrito", AgregarAlCarrito),
                  new Opciones("Eliminar productos del carrito", EliminarDelCarrito),
                new Opciones("Ver mi carrito", VerCarrito),
                new Opciones("Calcular total", CalcularTotal),
                new Opciones("Cerrar sesión", ()=>Environment.Exit(0))
            };

            while (true)
            {
                MostrarMenu();
                SeleccionarOpcion();
            }
        }

        public void MostrarMenu()//MUESTRA EL MENU
        {
            foreach (Opciones opcion in opciones)
            {
                Console.WriteLine(opciones.IndexOf(opcion) + ". " + opcion.Message);
            }
        }

        public void SeleccionarOpcion()//PERMITE SELECCIONAR LAS OPCIONES E INVOCA LA ACCIÓN
        {
            int numOpcion = int.Parse(Console.ReadLine());
            Console.Clear();
            opciones[numOpcion].Action.Invoke(); 
        }

        // PERMITA VER TODOS LOS PRODUCTOS QUE HAY EN EL CATÁLOGO
        private void MostrarCatalogo()
        {
            Console.WriteLine("Productos Disponibles en tienda:");
            for (int i = 0; i < inventario.Count; i++)//INVENTARIO COUNT REGRESA EL NUMERO DE PRODUCTOS GUARDADOS EN LA LISTA INVENTARIO
            {
                Producto producto = inventario[i];


                Console.WriteLine($"{i}. {producto.getNombre()} | ${producto.getPrecio()}"); //IMPRIME LOS PRODUCTOS 1 A 1
                Console.WriteLine($"{producto.getDescripcion()}\n");
            }
        }


        // AGREGAR PRODUCTO AL CARRITO
        private void AgregarAlCarrito()
        {
            MostrarCatalogo(); //NOS MUESTRA EL CATÁLOGO PARA SABER QUE AGREGAR
            Console.WriteLine("\nIngrese el número del producto que desea agregar a su carrito:");
            int producto = int.Parse(Console.ReadLine());
           
            if (producto >= 0 && producto < inventario.Count) //VALIDAMOS QUE EL NUMERO ESTE DENTRO DE LAS OPCIONES DE PRODUCTOS QUE EXISTEN
            {
                Console.WriteLine("\n¿Cuantas piezas desea agregar de ese producto?:");//PREGUNTAMOS CUANTAS PIEZAS DESEA AGREGAR
                int pza = int.Parse(Console.ReadLine());

                Console.WriteLine(carrito.AgregarProducto(inventario[producto], pza));
            }
            else
            {
                Console.WriteLine("La opción no existe\n");
            }
        }
        private void EliminarDelCarrito() //metodo adicional
        {
            MostrarCatalogo(); //NOS MUESTRA EL CATÁLOGO PARA SABER QUE ELIMINAR
            Console.WriteLine("\nIngrese el número del producto que desea eliminar del carrito:");
            int producto = int.Parse(Console.ReadLine());

            if (producto >= 0 && producto < inventario.Count)//VALIDAMOS QUE EL NUMERO ESTE DENTRO DE LAS OPCIONES DE PRODUCTOS QUE EXISTEN
            {
                Console.WriteLine("\n¿Cuántas piezas desea eliminar de ese producto?:");
                int pza = int.Parse(Console.ReadLine());

                Console.WriteLine(carrito.EliminarProducto(inventario[producto], pza));
            }
            else
            {
                Console.WriteLine("La opción no existe\n");
            }
        }


        // VER PRODUCTOS GUARDADOS EN EL CARRITO
        private void VerCarrito()
        {
           Console.WriteLine(carrito.VerCarrito());
        }

        // Método para calcular el total de la compra
        private void CalcularTotal()
        {
            Console.WriteLine(carrito.CalcularTotal());
        }
    }
}


