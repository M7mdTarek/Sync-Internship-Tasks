using System.ComponentModel.DataAnnotations;

namespace Sync_Task1.Models
{
    public class Bug
    {
        public int id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string title { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        [Range(1, 5)]
        public int priority { get; set; }

        public Solution solution { get; set; }

        public Developer developer { get; set; }

        

    }
}
