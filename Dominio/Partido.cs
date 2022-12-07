using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Partido
    {
        #region Constructor
        //Creamos la clase y realizamos su respectivo constructor
        public Partido(int id, List<Seleccion> seleccion, DateTime fecha, string estado, string tipo, string resutado)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Estado = /*"Finalizado"*/DefinirEstado();
            this.selecciones = seleccion;
            this.Tipo = tipo;
            this.Resultado = resutado;
        }
        public Partido() { }
        #endregion
        //Estos son los atributos de la clase.
        public List<Seleccion> selecciones { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Resultado { get; set; }
        public string Tipo { get; set; }

        #region Validadores
        public void ValidarSelecciones()
        {
            if (this.selecciones.Count !=2) 
            {
                throw new Exception("No puede haber ni mas ni menos de dos selecciones");
            }
        }
        public void ValidarFecha()
        {
            DateTime t1 = new DateTime(2022, 11, 20);
            DateTime t2 = new DateTime(2022, 12, 18);
            if(DateTime.Compare(this.Fecha, t1)!>0 && DateTime.Compare(this.Fecha, t1)!<0)
            {
                throw new Exception($"la fecha debe ser entre{t1} y {t2}");
            }
        }
        #endregion
        public string DefinirEstado()
        {
            DateTime FechaDeHoy = DateTime.Now;
            if(DateTime.Compare(this.Fecha, FechaDeHoy) <= 0)
            {
                return "Finalizado";
            }
            return "Pendiente";
        }
        public abstract string ConsultarNombre();
    }
}
 