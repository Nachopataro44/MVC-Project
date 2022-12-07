using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Resenia
    {
        #region Constructor
        public Resenia(UsuarioPeriodista unPeriodista, Partido unPartido, int partidoId , DateTime fecha, string titulo, string contenido)
        {
            this.Fecha = fecha;
            this.Titulo = titulo;
            this.Contenido = contenido;
            this.partidoId = partidoId;
        }

        public Resenia() { }
        #endregion
        public Usuario UnPeriodista { get; set; }
        public Partido unPartido { get; set; }
        public DateTime Fecha { get; set; }
        public int partidoId { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
    }
}
