using System;
using System.ComponentModel.DataAnnotations;
//ASP.NET Core uses aspnetcore.mvc instead of compnentmodel.Dataannotations
//for the metadatatype attribute; it also uses modelmetadatatype instead
using Microsoft.AspNetCore.Mvc;

//these partial classes are used to connect the model classes to the metadata classes
namespace Pokedex.Models
{
    [ModelMetadataType(typeof(ColoresMetadata))]
    public partial class Colores { }

    [ModelMetadataType(typeof(PoderesMetadata))]
    public partial class Poderes { }

    [ModelMetadataType(typeof(PokemonesMetadata))]
    public partial class Pokemones { }

    [ModelMetadataType(typeof(RegionesMetadata))]
    public partial class Regiones { }

    [ModelMetadataType(typeof(TiposMetadata))]
    public partial class Tipos { }
}