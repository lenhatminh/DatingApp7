using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
namespace API.Controllers
{   
    public class UsersController:BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;            
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>getUsers(){
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>getUser(int id){
            return await _context.Users.FindAsync(id);
        }
    }

}