using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comandos.Models
{
    [Table("command")]
    public class Command
    {
        [Key]
        public int CommandId { get; set; }
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public int PlatformId { get; set; }
        public Platform Platform {get; set;} 

    }
}