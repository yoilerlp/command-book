using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comandos.Models {

    [Table("platform")]
    public class Platform {

        [Key]
        public int PlatformId {get; set;}
        [MaxLength(100)]
        [Required]
        public string Name {get; set;}
        [MaxLength(250)]
        [Required]
        public string Descripcion {get; set;}
    }
}