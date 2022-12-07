using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PartidoEliminatoria : Partido
    {
        public PartidoEliminatoria(Seleccion Ganador, bool Alargue, bool Penales, string Fase, int id, List<Seleccion> seleccion,  DateTime fecha, string estado, string tipo, string resultado) : base(id, seleccion, fecha,estado,tipo, resultado)
        {
            this.Ganador = Ganador;
            this.Alargue = Alargue;
            this.Penales = Penales;
            this.Fase = Fase;
        }
        public PartidoEliminatoria() { }

        public Seleccion Ganador { get; set; }
        public bool Alargue { get; set; }
        public bool Penales { get; set; }
        public string Fase { get; set; }

        public override string ConsultarNombre()
        {
            return "Este es un partido de fase eliminatoria";
        }
    }
}
