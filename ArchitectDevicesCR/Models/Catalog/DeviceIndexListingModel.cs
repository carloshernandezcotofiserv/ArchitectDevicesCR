using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Models.Catalog
{
    public class DeviceIndexListingModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string OS { get; set; }
        public string Site { get; set; }
        public string Status { get; set; }
        public string CheckedOutTo { get; set; }
    }
}
