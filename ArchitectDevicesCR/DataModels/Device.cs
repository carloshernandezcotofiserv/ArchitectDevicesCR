using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.DataModels
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string OS { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public virtual Site Site { get; set; }
        public string ImageUrl { get; set; }
    }
}
