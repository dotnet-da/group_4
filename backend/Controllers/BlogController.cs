using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [Route("post")]
        public IActionResult CreatePost([FromBody] BlogModel.Post post)
        {
            try
            {
                if (post == null)
                {
                    return BadRequest();
                }

                _context.Posts.Add(post);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("post")]
        public IActionResult UpdatePost([FromBody] BlogModel.Post post)
        {
            try
            {
                if (post == null)
                {
                    return BadRequest();
                }
                
                var entity = _context.Posts.Where(p => p.ID == post.ID).First();
                _context.Entry(entity).CurrentValues.SetValues(post);
                //_context.Update(post);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}