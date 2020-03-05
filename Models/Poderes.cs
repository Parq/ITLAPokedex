using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Poderes
    {
        public Poderes()
        {
            PoderesPokemon = new HashSet<PoderesPokemon>();
        }

        public int IdPoder { get; set; }
        public string Nombre { get; set; }
        public int IdTipo { get; set; }
        public int? Poder { get; set; }
        public int? Preci { get; set; }
        public int? Pp { get; set; }
        public string Descripcion { get; set; }

        public virtual Tipos IdTipoNavigation { get; set; }
        public virtual ICollection<PoderesPokemon> PoderesPokemon { get; set; }
    }
}
