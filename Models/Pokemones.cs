using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Pokemones
    {
        public Pokemones()
        {
            PoderesPokemon = new HashSet<PoderesPokemon>();
            TiposPokemon = new HashSet<TiposPokemon>();
        }

        public int IdPokemon { get; set; }
        public string Nombre { get; set; }
        public int IdRegion { get; set; }

        public virtual Regiones IdRegionNavigation { get; set; }
        public virtual ICollection<PoderesPokemon> PoderesPokemon { get; set; }
        public virtual ICollection<TiposPokemon> TiposPokemon { get; set; }
    }
}
