using System;
//to use data annotations, use the componentmodel.dataannotations
//these are used for data validation
using System.ComponentModel.DataAnnotations;

//the metadata class is used to save the attributes in case the database changes
//this is because, if you need to regenerate the model class, all attributes will be lost
namespace Pokedex.Models
{
    public class ColoresMetadata
    {
        public int IdColor;
        [StringLength(50)]
        [Required]
        public string Nombre;
        [StringLength(50)]
        [Required]
        public string Codigo;
    }

    public class PoderesMetadata
    {
        public int IdPoder;
        [StringLength(50)]
        [Required]
        public string Nombre;
        public int IdTipo;
        public int? Poder;
        public int? Preci;
        public int? Pp;
        [StringLength(100)]
        public string Descripcion;
    }
    public class PokemonesMetadata
    {
        public int IdPokemon;
        [StringLength(50)]
        [Required]
        public string Nombre;
        public int IdRegion;
    }
    public class RegionesMetadata
    {
        public int IdRegion;
        [StringLength(50)]
        [Required]
        public string Nombre;
        public int IdColor;
    }
    public class TiposMetadata
    {
        public int IdTipo;
        [StringLength(50)]
        public string Nombre;
    }
}

