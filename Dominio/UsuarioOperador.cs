using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class UsuarioOperador : UsuarioPeriodista
    {
        DateTime Fecha { get; set; }
        public const string Rol = "Operador";

        #region Asignar Rol
        public override string ObtenerRol()
        {
            return Rol;
        }
        #endregion
        #region Constructor
        public UsuarioOperador() {
        }

        public UsuarioOperador(string nombre, string password, string email, string apellido) : base(nombre, password, email, apellido)
        {
        }
        #endregion
    }
}
