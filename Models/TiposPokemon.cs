using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class TiposPokemon
    {
        public int IdPokemon { get; set; }
        public int IdTipo { get; set; }

        public virtual Pokemones IdPokemonNavigation { get; set; }
        public virtual Tipos IdTipoNavigation { get; set; }
    }
}
