using ArchitectDevicesCR.DataModels;
using System.Collections.Generic;

namespace ArchitectDevicesCR.DataInterfaces
{
    public interface IUser
    {
        User Get(int id);
        IEnumerable<User> GetAll();
        void Add(User newUser);

        IEnumerable<CheckoutHistory> GetCheckoutHistory(int userId);
        IEnumerable<Hold> GetHolds(int userId);
        IEnumerable<Checkout> GetCheckouts(int userId);
    }
}
