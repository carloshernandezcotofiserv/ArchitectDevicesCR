using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.DataModels;
using ArchitectDevicesCR.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private IUser _user;

        public UserController(DataInterfaces.IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            var allUsers = _user.GetAll();

            var userModels = allUsers.Select(u => new UserDetailModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                HomeSite = u.Site.Name
            }).ToList();

            var model = new UserIndexModel()
            {
                Users = userModels
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var user = _user.Get(id);

            var model = new UserDetailModel
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                HomeSite = user.Site.Name,
                DevicesCheckedOut = _user.GetCheckouts(id).ToList() ?? new List<Checkout>(),
                CheckOutHistory = _user.GetCheckoutHistory(id) ?? new List<CheckoutHistory>(),
                Holds = _user.GetHolds(id) ?? new List<Hold>()
            };

            return View(model);
        }
    }
}
