using System.ComponentModel.DataAnnotations;

namespace SocialBrothersBackEndCase.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string street { get; set; }
        [Required]
        public string house_number { get; set; }
        [Required]
        public string zip_code { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }
    }
}
