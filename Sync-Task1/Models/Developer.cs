using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sync_Task1.Models
{
    public class Developer
    {
        public int id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string role { get; set; }

        public string imgUrl { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }

        //public Developer()
        //{
        //    file = null;
        //}
    }
}
