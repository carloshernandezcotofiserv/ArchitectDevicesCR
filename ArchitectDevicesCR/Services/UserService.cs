using ArchitectDevicesCR.DataInterfaces;
using ArchitectDevicesCR.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchitectDevicesCR.Services
{
    public class UserService : IUser
    {
        private DevicesContext _context;

        public UserService(DevicesContext context)
        {
            _context = context;
        }

        public void Add(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public User Get(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .Include(user => user.Site);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int userId)
        {
            return _context.CheckoutHistories
                .Include(coh => coh.Device)
                .Where(coh => coh.User.Id == userId)
                .OrderByDescending(coh => coh.CheckedOut);
        }

        public IEnumerable<Checkout> GetCheckouts(int userId)
        {
            return _context.Checkouts
                .Include(co => co.Device)
                .Where(co => co.User.Id == userId);
        }

        public IEnumerable<Hold> GetHolds(int userId)
        {
            return _context.Holds
                .Include(ho => ho.Device)
                .Where(ho => ho.User.Id == userId)
                .OrderByDescending(ho => ho.HoldPlaced);
        }
    }
}
