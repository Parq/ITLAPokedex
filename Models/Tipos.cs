using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Tipos
    {
        public Tipos()
        {
            Poderes = new HashSet<Poderes>();
            TiposPokemon = new HashSet<TiposPokemon>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Poderes> Poderes { get; set; }
        public virtual ICollection<TiposPokemon> TiposPokemon { get; set; }
    }
}
