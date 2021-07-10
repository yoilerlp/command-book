using System.ComponentModel.DataAnnotations;

namespace Comandos.Dtos 
{
    public class CommandReadDto
    {
        public int CommandId { get; set; }

        public string HowTo {get; set;}

        public string Line { get; set; }

        public int PlatformId { get; set; }
    
    }

    public class CommandCreateDto
    {
        [Required]
        public string HowTo {get; set;}
        [Required]
        public string Line { get; set; }
        [Required]
        public int PlatformId { get; set; }
    }

    
    public class CommandUpdateDto
    {
        [Required]
        public string HowTo {get; set;}
        [Required]
        public string Line { get; set; }
        [Required]
        public int PlatformId { get; set; }
    } 
}