using System.ComponentModel.DataAnnotations;

namespace Sync_Task1.Models
{
    public class Solution
    {
        public int id { get; set; }

        [Required]
        [StringLength(20,MinimumLength =5)]
        public string Title { get; set; }

        [Required]
        public int timeInHours { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

    }
}
