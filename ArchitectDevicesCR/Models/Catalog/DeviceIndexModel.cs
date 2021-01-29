using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Models.Catalog
{
    public class DeviceIndexModel
    {
        public IEnumerable<DeviceIndexListingModel> Devices { get; set; }
    }
}
