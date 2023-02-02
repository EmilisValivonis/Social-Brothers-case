using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SocialBrothersBackEndCase.Models
{
    public record InsertIntoDatabase
    {  
        public string id { get; set; }
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
