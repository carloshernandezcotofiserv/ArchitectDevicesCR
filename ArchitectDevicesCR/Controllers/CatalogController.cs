using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.Models.Catalog;
using ArchitectDevicesCR.Models.Checkout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Controllers
{
    //[Authorize(Roles = "Admin, User")]
    [Authorize(Roles = "CanUseApp")]
    public class CatalogController : Controller
    {
        private IDevice _devices;
        private ICheckout _checkouts;
        private IUser _users;

        public CatalogController(IDevice devices, ICheckout checkouts, IUser users)
        {
            _devices = devices;
            _checkouts = checkouts;
            _users = users;
        }

        public IActionResult Index()
        {
            var deviceModels = _devices.GetAll();

            var listingResult = deviceModels.Select(result => new DeviceIndexListingModel
            {
                Id = result.Id,
                Description = result.Description,
                ImageUrl = result.ImageUrl,
                OS = result.OS,
                Site = result.Site.Name,
                Status = result.Status.Description,
                CheckedOutTo = _checkouts.GetCurrentCheckoutUser(result.Id)
            });

            var model = new DeviceIndexModel()
            {
                Devices = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var device = _devices.GetById(id);

            var currentHolds = _checkouts.GetCurrentHolds(id).Select(dev => new DeviceHoldModel
            {
                HoldPlaced = _checkouts.GetCurrentHoldPlaced(dev.Id).ToString("d"),
                UserName = _checkouts.GetCurrentHoldUserName(dev.Id)
            });

            var model = new DeviceDetailModel
            {
                Id = id,
                Description = device.Description,
                OS = device.OS,
                Status = device.Status.Description,
                CurrentLocation = device.Site.Name,
                ImageUrl = device.ImageUrl,
                CheckoutHistory = _checkouts.GetCheckoutHistory(id),
                LatestCheckout = _checkouts.GetLatestCheckout(id),
                UserName = _checkouts.GetCurrentCheckoutUser(id),
                CurrentHolds = currentHolds
            };

            return View(model);
        }

        public IActionResult Checkout(int id)
        {
            var device = _devices.GetById(id);
            //Need to update the following line after implementing the new Authentication system
            //var user = _users.Get(Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var user = _users.GetAll().FirstOrDefault(u => u.Username == this.User.Identity.Name);

            var model = new CheckoutModel
            {
                DeviceID = id,
                ImageUrl = device.ImageUrl,
                Description = device.Description,
                //UserCardId = user.UserCard.Id.ToString(),
                UserId = user.Id.ToString(),
                IsCheckedOut = _checkouts.IsCheckedOut(id)
            };

            return View(model);
        }

        public IActionResult CheckIn(int id)
        {
            _checkouts.CheckInItem(id);
            return RedirectToAction("Detail", new { id = id});
        }

        public IActionResult Hold(int id)
        {
            var device = _devices.GetById(id);
            //var user = _users.Get(Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var user = _users.GetAll().FirstOrDefault(u => u.Username == this.User.Identity.Name);

            var model = new CheckoutModel
            {
                DeviceID = id,
                ImageUrl = device.ImageUrl,
                Description = device.Description,
                //UserCardId = user.UserCard.Id.ToString(),
                UserId = user.Id.ToString(),
                IsCheckedOut = _checkouts.IsCheckedOut(id),
                HoldCount = _checkouts.GetCurrentHolds(id).Count()
            };

            return View(model);
        }

        public IActionResult MarkLost(int deviceId)
        {
            _checkouts.MarkLost(deviceId);
            return RedirectToAction("Detail", new { id = deviceId });
        }

        public IActionResult MarkFound(int deviceId)
        {
            _checkouts.MarkFound(deviceId);
            return RedirectToAction("Detail", new { id = deviceId });
        }

        [HttpPost]
        public IActionResult PlaceCheckout(int deviceId, int userId)
        {
            _checkouts.CheckOutItem(deviceId, userId);
            return RedirectToAction("Detail", new { id = deviceId });
        }

        [HttpPost]
        public IActionResult PlaceHold(int deviceId, int userId)
        {
            _checkouts.PlaceHold(deviceId, userId);
            return RedirectToAction("Detail", new { id = deviceId });
        }

    }
}
