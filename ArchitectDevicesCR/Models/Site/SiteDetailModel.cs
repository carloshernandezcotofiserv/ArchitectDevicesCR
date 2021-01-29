using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Models.Site
{
    public class SiteDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        //public IEnumerable<DataModels.Device> Devices { get; set; }
        //public IEnumerable<DataModels.User> Users { get; set; }
    }
}
