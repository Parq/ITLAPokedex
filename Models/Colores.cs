using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Colores
    {
        public Colores()
        {
            Regiones = new HashSet<Regiones>();
        }

        public int IdColor { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Regiones> Regiones { get; set; }
    }
}
