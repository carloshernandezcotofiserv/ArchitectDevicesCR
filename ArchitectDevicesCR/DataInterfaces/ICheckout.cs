using ArchitectDevicesCR.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.DataInterfaces
{
    public interface ICheckout
    {
        IEnumerable<Checkout> GetAll();
        Checkout GetById(int checkoutId);
        Checkout GetLatestCheckout(int deviceId);
        void Add(Checkout newCheckout);
        void CheckOutItem(int deviceId, int userCardId);
        void CheckInItem(int deviceId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        string GetCurrentCheckoutUser(int deviceId);
        bool IsCheckedOut(int deviceId);

        void PlaceHold(int deviceId, int userCardId);
        string GetCurrentHoldUserName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        void MarkLost(int deviceId);
        void MarkFound(int deviceId);
    }
}
