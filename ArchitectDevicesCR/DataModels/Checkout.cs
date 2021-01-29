using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.DataModels
{
    public class Checkout
    {
        public int Id { get; set; }
        [Required]
        public Device Device { get; set; }
        public User User { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
    }
}
