using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Services
{
    public class CheckoutService : ICheckout
    {
        private DevicesContext _context;

        public CheckoutService(DevicesContext context)
        {
            _context = context;
        }

        public void Add(Checkout newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }

        public IEnumerable<Checkout> GetAll()
        {
            return _context.Checkouts;
        }

        public Checkout GetById(int checkoutId)
        {
            return _context.Checkouts.FirstOrDefault(chout => chout.Id == checkoutId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(h => h.Device).
                Include(h => h.User)
                .Where(h => h.Device.Id == id);
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.Device)
                .Where(h => h.Device.Id == id);
        }

        public Checkout GetLatestCheckout(int deviceId)
        {
            return _context.Checkouts
                .Where(ch => ch.Device.Id == deviceId)
                .OrderByDescending(ch => ch.Since)
                .FirstOrDefault();
        }

        public string GetCurrentHoldUserName(int holdId)
        {
            var hold = _context.Holds
                .Include(h => h.Device)
                .FirstOrDefault(h => h.Id == holdId);

            //var user = _context.Users
            //    .FirstOrDefault(u => u.Id == hold.User.Id);

            return hold.User?.FirstName + " " + hold.User?.LastName;
        }

        public void MarkFound(int deviceId)
        {
            var now = DateTime.Now;

            UpdateDeviceStatus(deviceId, "Available");
            RemoveExistingCheckouts(deviceId);
            CloseExistingCheckoutHistory(deviceId, now);
                
            _context.SaveChanges();
        }

        private void UpdateDeviceStatus(int deviceId, string status)
        {
            var item = _context.Devices
                .FirstOrDefault(d => d.Id == deviceId);

            _context.Update(item);
            item.Status = _context.Statuses.FirstOrDefault(s => s.Description == status);

        }

        private void CloseExistingCheckoutHistory(int deviceId, DateTime now)
        {
            var history = _context.CheckoutHistories.FirstOrDefault(chh => chh.Device.Id == deviceId && chh.CheckedIn == null);
            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = now;
            }
        }

        private void RemoveExistingCheckouts(int deviceId)
        {
            var checkout = _context.Checkouts.FirstOrDefault(ch => ch.Device.Id == deviceId);
            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }

        public void MarkLost(int deviceId)
        {
            UpdateDeviceStatus(deviceId, "Lost");

            _context.SaveChanges();
        }

        public void PlaceHold(int deviceId, int userId)
        {
            var now = DateTime.Now;
            var device = _context.Devices
                .Include(dev => dev.Status)
                .FirstOrDefault(dev => dev.Id == deviceId);
            //var card = _context.UserCards.FirstOrDefault(c => c.Id == userCardId);
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (device.Status.Description == "Available")
            {
                UpdateDeviceStatus(deviceId, "On Hold");
            }

            var hold = new Hold
            {
                HoldPlaced = now,
                Device = device,
                User = user
            };
            _context.Add(hold);
            _context.SaveChanges();
        }

        public void CheckInItem(int deviceId)
        {
            var now = DateTime.Now;
            var item = _context.Devices.FirstOrDefault(dev => dev.Id == deviceId);
            
            //remove any existing checkouts on the device
            RemoveExistingCheckouts(deviceId);

            //close any existing checkout history
            CloseExistingCheckoutHistory(deviceId, now);
            
            //look for existing holds on the device
            var currentHolds = _context.Holds
                .Include(h => h.Device)
                .Include(h => h.User)
                .Where(h => h.Device.Id == deviceId);

            //if there are any holds, checkout the item to the card with the earliest hold
            if (currentHolds.Any())
            {
                CheckoutToEarliestHold(deviceId, currentHolds);
                return;
            }

            //otherwise update the item status to available
            UpdateDeviceStatus(deviceId, "Available");
            _context.SaveChanges();
        }

        private void CheckoutToEarliestHold(int deviceId, IQueryable<Hold> currentHolds)
        {
            var earliestHold = currentHolds
                .OrderBy(holds => holds.HoldPlaced)
                .FirstOrDefault();

            var user = earliestHold.User;

            _context.Remove(earliestHold);
            _context.SaveChanges();
            CheckOutItem(deviceId, user.Id);
        }

        public void CheckOutItem(int deviceId, int userId)
        {
            if (IsCheckedOut(deviceId))
            {
                return;
                //Add logic to handle feedback to the user
            }

            var item = _context.Devices.FirstOrDefault(a => a.Id == deviceId);
            UpdateDeviceStatus(deviceId, "Checked Out");
            var user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            var now = DateTime.Now;
            var checkout = new Checkout
            {
                Device = item,
                User = user,
                Since = now,
                Until = GetDefaultCheckoutTime(now)
            };

            _context.Add(checkout);

            var checkoutHistory = new CheckoutHistory
            {
                CheckedOut = now,
                Device = item,
                User = user
            };

            _context.Add(checkoutHistory);
            _context.SaveChanges();
        }

        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(5);
        }

        public bool IsCheckedOut(int deviceId)
        {
            return _context.Checkouts
                .Where(co => co.Device.Id == deviceId)
                .Any();
        }

        public DateTime GetCurrentHoldPlaced(int holdId)
        {
            return _context.Holds
                .Include(h => h.Device)
                .Include(h => h.User)
                .FirstOrDefault(h => h.Id == holdId)
                .HoldPlaced;
        }

        public string GetCurrentCheckoutUser(int deviceId)
        {
            var checkout = GetCheckOutByDeviceId(deviceId);
            if (checkout == null)
            {
                return "";
            }

            var userId = checkout.User.Id;

            var user = _context.Users
                .FirstOrDefault(p => p.Id == userId);

            return user.FirstName + " " + user.LastName;
        }

        private Checkout GetCheckOutByDeviceId(int deviceId)
        {
            return _context.Checkouts
                .Include(co => co.Device)
                .Include(co => co.User)
                .FirstOrDefault(co => co.Device.Id == deviceId);
        }
    }
}
