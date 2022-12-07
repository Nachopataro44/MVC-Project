using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario
    {  
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        #region constructor

        public Usuario(string email,string password, string nombre, string apellido)
        {
            this.Email = email;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Password = password;
        }
        public Usuario() { }

        #endregion
        #region Validadores

        public virtual void ValidarPassword()
        {
            if (this.Password.Length < 8)
            {
                throw new Exception("La contraseña debe ser mayor a 8 caracteres");
            }
        }
        public virtual void ValidarCamposVacios()
        {
            if (this.Nombre is null || this.Password is null || this.Email is null)
            {
                throw new Exception("Ningun campo puede estar vacio");
            }
        }

        public virtual void ValidarMail()
        {
            if (Email.IndexOf('@') != -1)
            {
                int validar = this.Email.IndexOf('@');
                if (validar == this.Email.Length - 1 || validar == 0)
                {
                    throw new Exception("El Email es incorrecto");
                }
            }
            else
            {
                throw new Exception("El email no contiene '@' verifique que se haya ingresado correctamente");
            }
        }

        #endregion
        #region Asignar Rol
        public virtual string ObtenerRol()
        {
            return "SIN_ROL";
        }
        #endregion
    }
}
