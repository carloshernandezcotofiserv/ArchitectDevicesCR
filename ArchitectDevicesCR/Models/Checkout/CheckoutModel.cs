using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Models.Checkout
{
    public class CheckoutModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public int DeviceID { get; set; }
        public string ImageUrl { get; set; }
        public int HoldCount { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
