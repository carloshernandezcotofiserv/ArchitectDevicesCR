using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.DataModels
{
    public class CheckoutHistory
    {
        public int Id { get; set; }
        [Required]
        public Device Device { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
    }
}
