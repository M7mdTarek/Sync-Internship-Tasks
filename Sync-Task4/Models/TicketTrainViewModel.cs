using System.ComponentModel.DataAnnotations;

namespace Sync_Task4.Models
{
    public class TicketTrainViewModel
    {
        public int Id { get; set; }

        public int TrainId { get; set; }

        public Train Train { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(9,MinimumLength =9)]
        public string Payment { get; set; }
    }
}
