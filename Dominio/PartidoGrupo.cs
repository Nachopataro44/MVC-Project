using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PartidoGrupo : Partido
    {
        public PartidoGrupo(string nombreGrupo, int id, List<Seleccion> seleccion, DateTime fecha, string estado, string tipo, string resultado): base(id, seleccion, fecha, estado, tipo, resultado)
        {
            this.nombreGrupo = nombreGrupo;
        }
        public PartidoGrupo() { }
        public string nombreGrupo { get; set; }

        public override string ConsultarNombre()
        {
            return this.nombreGrupo;
        }
    }
}
