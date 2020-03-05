using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class PoderesPokemon
    {
        public int IdPokemon { get; set; }
        public int IdPoder { get; set; }

        public virtual Poderes IdPoderNavigation { get; set; }
        public virtual Pokemones IdPokemonNavigation { get; set; }
    }
}
