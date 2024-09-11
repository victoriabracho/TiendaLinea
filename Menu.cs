using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLinea
{

    internal class Menu
    {
        private List<Opciones> opciones;//LISTA PARA MANEJAR OPCIONES DEL MENU
        private List<Cliente> clientes;//LISTA PARA MANEJAR CLIENTES
        private Cliente clienteActual; //LISTA BUSQUEDA CLIENTE ACTUAL

        public Menu() //OPCIONES DEL MENÚ INICIAL, YA QUE NO PUEDES ACCEDER AL SUPER SI TENER UNA CUENTA
        {
            clientes = new List<Cliente>(); 
            opciones = new List<Opciones>() {
                new Opciones("Registrarse", Registrarse),
                new Opciones("Iniciar Sesión", IniciaSesion),
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
        public void SeleccionarOpcion()//PERMITE SELECCIONAR LAS OPCIONES E INVOCA LA ACCION
        {
            int numOpcion = int.Parse(Console.ReadLine());
            Console.Clear();
            opciones[numOpcion].Action.Invoke();
        }
        private void Registrarse()//PIDE AL USUARIO SU INFORMACIÓN, CREA AL CLIENTE Y LO AGREGA A LA LISTA DE CLIENTES
        {
            Console.WriteLine("Ingrese su nombre y apellido por favor:");
            string n = Console.ReadLine();
            Console.WriteLine("Ingrese su correo electrónico por favor:");
            string c = Console.ReadLine();
            Console.WriteLine("Cree una contraseña numérica para su cuenta por favor:");
            int con = int.Parse(Console.ReadLine());

            Cliente nuevoCliente = new Cliente(n, c, con); //SE CREA UN NUEVO CLIENTE QUE ADEMÁS SE GUARDA EN OTRA VARIABLE DE TIPO CLIENTE
            clientes.Add(nuevoCliente);//APROVECHANDO LA VARIABLE ANTERIOR SE AGREGA ESE NUEVO CLIENTE A LA LISTA DE CLIENTES
        }
        private void IniciaSesion()//SI YA TIENES CUENTA UTILIZA TU INFORMACION PARA BUSCARTE Y PERMITIRTE INICIAR SESIÓN
        {
            Console.WriteLine("Ingrese su correo electrónico por favor:");
            string c = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña por favor:");
            int con = int.Parse(Console.ReadLine());

            foreach (Cliente cliente in clientes) //BUSCA EN LA LISTA DE CLIENTES
            {
                if (cliente.ValidarCliente(c, con))//ESTO REGRESA UN TRUE Y PERMITE HACER LA ACCIÓN, SI ES CIERTO
                {
                    clienteActual = cliente;
                    Console.WriteLine($"Inicio de sesión exitoso. Bienvenid@: {cliente.GetNombre()}\n");
                    MostrarMenuTienda();//NOS ABRE EL MENU DE LA TIENDA
                    return;
                }
            }
            Console.WriteLine("El correo o o contraseña ingresados no son válidos.\n");
        }
        private void MostrarMenuTienda()//NOS MANDA AL MENU DE LA TIENDA Ó MENU 2
        {
            Menu2 menuTienda = new Menu2();
        }
    }

}




