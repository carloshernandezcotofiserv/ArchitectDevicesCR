using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.DataModels
{
    public class Hold
    {
        public int Id { get; set; }
        public virtual Device Device { get; set; }
        public virtual User User { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
