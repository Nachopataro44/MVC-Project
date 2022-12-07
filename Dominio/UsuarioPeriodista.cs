using System;

namespace Dominio
{
    //Periodista, tiene herencia de Persona.
    public class UsuarioPeriodista : Usuario, IComparable
    {
        public int Id { get; set; } = generateId();
        private static int ContadorId { get; set; } = 0;
        public const string Rol = "Periodista";

        #region Asignar Rol
        public override string ObtenerRol()
        {
            return Rol;
        }
        #endregion
        #region Constructor

        public UsuarioPeriodista(string nombre,string password, string email, string apellido) : base(email, password, nombre, apellido) 
        {
        }

        public static int generateId()
        {
            ContadorId++;   //Generando el autonumerico
            return ContadorId;
        }

        public UsuarioPeriodista()
        {
        }
        #endregion
        public int CompareTo(object obj)
        {
            UsuarioPeriodista b = (UsuarioPeriodista)obj;
            if(b.Apellido.CompareTo(this.Apellido) == 0)
            {
                return b.Nombre.CompareTo(this.Nombre);
            }
            return b.Apellido.CompareTo(this.Apellido);
        }
    }
}

