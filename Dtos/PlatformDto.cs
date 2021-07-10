using System.ComponentModel.DataAnnotations;

namespace Comandos.Dtos {

    public class PlatformCreateDto 
    {
        [MaxLength(100)]
        [Required]
        public string Name {get; set;}
        [MaxLength(250)]
        [Required]
        public string Descripcion {get; set;}
    }







}