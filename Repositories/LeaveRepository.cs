using LionDevAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;


namespace LionDevAPI.Repositories
{
    public class LeaveRepository
    {
        private readonly LionDevContext _context;

        public LeaveRepository(LionDevContext context)
        {
            _context = context;
        }

        public long Create(Leave model)
        {
            _context.Leaves.Add(model);
            _context.SaveChanges();
            long id = model.Id;

            return id;
        }

        public List<Leave> GetAll()
        {
            return _context.Leaves.ToList();
        }
        
        public List<LeaveType> GetTypes()
        {
            var types = _context.LeaveTypes.ToList();
            return types;
        }
    }
}
