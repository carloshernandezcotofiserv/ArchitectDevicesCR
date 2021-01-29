using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.Models.Site;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectDevicesCR.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SiteController : Controller
    {
        private ISite _site;

        public SiteController(ISite site)
        {
            _site = site;
        }

        public IActionResult Index()
        {
            var sites = _site.GetAll().Select(site => new SiteDetailModel
            {
                Id = site.Id,
                Name = site.Name,
                ImageUrl = site.ImageUrl
            });

            var model = new SiteIndexModel() { Sites = sites };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var site = _site.Get(id);

            var model = new SiteDetailModel
            {
                Id = site.Id,
                Name = site.Name,
                ImageUrl = site.ImageUrl
            };

            return View(model);
        }
    }
}
