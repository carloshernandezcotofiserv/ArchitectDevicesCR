using ArchitectDevicesCR.DataModels;
using System;
using System.Collections.Generic;

namespace ArchitectDevicesCR.Models.Catalog
{
    public class DeviceDetailModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string OS { get; set; }
        public string Status { get; set; }
        public  string CurrentLocation { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public DataModels.Checkout LatestCheckout { get; set; }
        public DataModels.User CurrentAssociatedUser { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
        public IEnumerable<DeviceHoldModel> CurrentHolds { get; set; }
    }

    public class DeviceHoldModel
    {
        public string UserName { get; set; }
        public string HoldPlaced { get; set; }
    }
}
