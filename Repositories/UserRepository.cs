using System.Collections.Generic;
using System.Linq;
using System;
using LionDevAPI.Models;

namespace LionDevAPI.Repositories
{
    public class UserRepository
    {
        private readonly LionDevContext _context;

        public UserRepository(LionDevContext context)
        {
            _context = context;
        }

        public User GetByName(User model)
        {
            var user = _context.Users.First(u => u.Name == model.Name);

            if (user == null)
            {
                model.LeaveTaken = 0;
                model.Leave = 15;
                _context.Users.Add(model);
                _context.SaveChanges();

                return model;
            }
            else
            {
                model = user;

                return model;
            }
        }

        public void LeaveTaken(Leave leave)
        {
            var days = (leave.EndDate - leave.StartDate).Days;

            var user = _context.Users.First(u => u.Name == leave.Name);
            var editUser = new User();

            if (user == null)
            {
                editUser.LeaveTaken = user.LeaveTaken + days;
                _context.Entry(user).CurrentValues.SetValues(editUser);
                _context.SaveChanges();
            }
        }
    }
}
