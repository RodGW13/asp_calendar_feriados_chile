using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FeriadosBO
    {
        public string Nombre { get; set; } //Nombre del feriado
        public string Comentarios { get; set; } //Comentarios sobre el feriado.
        public DateTime Fecha { get; set; } //Fecha en la que es efectivo el feriado.
        public int Irrenunciable { get; set; } //0 si no lo es 1 es irrenunciable

        public string Tipo { get; set; }

        public List<LeyesBO> leyes = new List<LeyesBO>();
    }
}
