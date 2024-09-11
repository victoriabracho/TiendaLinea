using System;

namespace TiendaLinea
{
    internal class Cliente
    {
        //ATRIBUTOS PRIVADOS DE UN CLIENTE
        private string Nombre;
        private string Correo;
        private int Contraseña;

        //CONSTRUCTOR DE UN CLIENTE
        public Cliente(string nombre, string correo, int contraseña)
        {
            this.Nombre = nombre;
            this.Correo = correo;
            this.Contraseña = contraseña;
        }

        public Cliente() { }

        //VALIDA QUE EL CLIENTE QUE INTENTA INGRESAR SI EXISTA
        public bool ValidarCliente(string correo, int contraseña)
        {
            return Correo == correo && Contraseña == contraseña;
        }

        //PERMITE VER LA INFORMACIÓN DE ESE CLIENTE
        public string GetNombre()
        {
            return Nombre;
        }
    }
}
