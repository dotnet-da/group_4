using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        
        private readonly ILogger<BlogController> _logger;
        private readonly BlogContext _context;

        public BlogController(ILogger<BlogController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet]
        [Route("user/all")]
        public async Task<ActionResult<List<BlogModel.User>>> GetUserAll()
        {
            return await _context.Users.ToListAsync();
        }
        
        [HttpGet]
        [Route("user/{id:int}")]
        public async Task<ActionResult<List<BlogModel.User>>> GetUser(int id)
        {
            return await _context.Users.Where(u => u.ID == id).ToListAsync();
        }
        
        [HttpGet]
        [Route("post/all")]
        public async Task<ActionResult<List<BlogModel.Post>>> GetPostAll()
        {
            return await _context.Posts.Include(p => p.Author).ToListAsync();
        }
        
        [HttpGet]
        [Route("post/{id:int}")]
        public async Task<ActionResult<List<BlogModel.Post>>> GetPost(int id)
        {
            return await _context.Posts.Where(p => p.ID == id).Include(p => p.Author).ToListAsync();
        }
    }
}