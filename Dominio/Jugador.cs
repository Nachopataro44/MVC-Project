using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Jugador : IValidable, IComparable
    {
  

        //Estos son los atributos de la clase.
        public string NombreCompleto { get; set; }
        public Pais unPais { get; set; }
        public string Categoria { get; set; } // VIP o standard
        public string PieHabil { get; set; }
        public string Puesto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Dorsal { get; set; }
        public string Moneda { get; set; }
        public double Altura { get; set; }
        public int Valor { get; set; }
        public int Id { get; set; }

        #region Constructor
        //Creamos la clase y realizamos su respectivo constructor
        public Jugador(int id, string dorsal, string nombreCompleto, DateTime fechaNacimiento, double altura, string pieHabil, int valor, string moneda, Pais unPais, string puesto)
        {
            this.Id = id;
            this.Dorsal = dorsal;
            this.NombreCompleto = nombreCompleto;
            this.PieHabil = pieHabil;
            this.Puesto = puesto;
            this.FechaNacimiento = fechaNacimiento;
            this.Altura = altura;
            this.Valor = valor;
            this.Moneda = moneda;
            this.unPais = unPais;
          
        }
        public Jugador() {
            ValidarAltura();
            ValidarFecha();
            ValidarStrings();
        }
        #endregion
        #region Comparador
        //Usamos el CompareTo, para ordenar lo pedido con el metodo sort();
        public int CompareTo(object obj)
        {
            Jugador b = (Jugador)obj;
            if (this.Valor > b.Valor) return -1;
            else if (b.Valor > this.Valor) return 1;
            else
            {
                if (this.NombreCompleto.CompareTo(b.NombreCompleto) == 1)
                {
                    return -1;
                }
                else if (this.NombreCompleto.CompareTo(b.NombreCompleto) == -1)
                {
                    return 1;
                }
                else return 0;
            }
        }
        #endregion
        #region Validadores
        public void ValidarFecha()
        {
            DateTime fechaInicial = new DateTime(1000,01,01);
            if (DateTime.Compare(this.FechaNacimiento, fechaInicial)!< 0)
            {
                throw new Exception("El jugador debe tener fecha de nacimiento");
            }
        }

        //Validamos que no pueden existir campos vacios.
        public void ValidarStrings()
        {
            if (this.PieHabil == "" || this.Puesto == "" || this.Dorsal == "" || this.Moneda == "")
            {
                throw new Exception("No pueden haber campos vacios");
            }
        }
        public void ValidarAltura()
        {
            if(this.Altura.Equals(null))
            {
                throw new Exception("La altura no puede ser un campo vacio");
            }
        }
        #endregion

    }

}
