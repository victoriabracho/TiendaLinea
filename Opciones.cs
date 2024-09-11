using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLinea
{
    //SE ENCARGA DE LAS OPCIONES DE LOS MENU
    internal class Opciones
    {
        private string message;
        private Action action;

        public Opciones(string message, Action action)
        {
            this.message = message;
            this.action = action;
        }

        public string Message { get { return message; } }
        public Action Action { get { return action; } }
    }
}
