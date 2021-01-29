using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.DataModels
{
    public class Site
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Limit Site name to 30 characters.")]
        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Device> Devices { get; set; }
        public string ImageUrl { get; set; }
    }
}
