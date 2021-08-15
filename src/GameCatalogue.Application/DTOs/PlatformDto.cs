using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Application.DTOs
{
    public class PlatformDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
