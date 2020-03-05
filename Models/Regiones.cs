using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Regiones
    {
        public Regiones()
        {
            Pokemones = new HashSet<Pokemones>();
        }

        public int IdRegion { get; set; }
        public string Nombre { get; set; }
        public int IdColor { get; set; }

        public virtual Colores IdColorNavigation { get; set; }
        public virtual ICollection<Pokemones> Pokemones { get; set; }
    }
}
