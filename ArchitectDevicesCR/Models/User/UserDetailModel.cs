using System;
using ArchitectDevicesCR.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Models.User
{
    public class UserDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string HomeSite { get; set; }
        public IEnumerable<DataModels.Checkout> DevicesCheckedOut { get; set; }
        public IEnumerable<CheckoutHistory> CheckOutHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }
    }
}
