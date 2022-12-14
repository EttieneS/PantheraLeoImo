using Microsoft.AspNetCore.Mvc;
using LionDevAPI.Models;
using LionDevAPI.Repositories;
using System.Collections.Generic;

namespace LionDevAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : Controller
    {
        LionDevContext _context;

        public LeaveController(LionDevContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public long Create(Leave model)
        {
            LeaveRepository leaveRespository = new LeaveRepository(_context);
            long id  = leaveRespository.Create(model);

            UserRepository userRepository = new UserRepository(_context);
            userRepository.LeaveTaken(model);

            CalenderController calenderController = new CalenderController();
            calenderController.CreateEvent(model);

            return id;
        }
        [Route("getall")]
        public List<Leave> GetAll()
        {
            var leaveRepository = new LeaveRepository(_context);
            List<Leave> leave = leaveRepository.GetAll();

            return leave;
        }

        [Route("gettypes")]
        public List<LeaveType> GetTypes()
        {
            var leaveRepository = new LeaveRepository(_context);
            return leaveRepository.GetTypes();

        }
    }
}
