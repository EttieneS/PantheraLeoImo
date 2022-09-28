using Microsoft.AspNetCore.Mvc;
using LionDevAPI.Repositories;
using LionDevAPI.Models;

namespace LionDevAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        LionDevContext _context;

        public UserController(LionDevContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("getbyname")]
        public User GetByName(User model)
        {
            UserRepository userRepository = new UserRepository(_context);
            var user = userRepository.GetByName(model);

            return user;
        }
    }
}
