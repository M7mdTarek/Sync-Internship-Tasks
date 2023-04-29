using Sync_Task1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sync_Task1.ViewsModels
{
    public class BugDeveloperViewModel
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
        [Range(1 , 5)]
        public int priority { get; set; }

        public List<Solution> solutions { get; set; }

        public int solutionID { get; set; }

        public List<Developer> developers { get; set; }

        public int developerID { get; set; }
    }
}
