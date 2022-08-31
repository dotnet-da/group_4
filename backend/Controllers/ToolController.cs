using System;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly ILogger<ToolController> _logger;
        private readonly ToolContext _context;

        public ToolController(ILogger<ToolController> logger, ToolContext context)
        {
            _logger = logger;
            _context = context;
        }

        #region Player

        [HttpGet]
        [Route("player")]
        public IActionResult GetAllPlayers()
        {
            var result = _context.Players;
            return Ok(result);
            //return Ok(!result.Any() ? null : result);
        }

        [HttpGet]
        [Route("player/{id:int}")]
        public IActionResult GetPlayer(int id)
        {
            try
            {
                var result = _context.Players.FirstOrDefault(player => player.Id == id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region Type

        [HttpGet]
        [Route("type")]
        public IActionResult GetAllTypes()
        {
            return Ok(_context.Types);
        }

        [HttpGet]
        [Route("type/{id:int}")]
        public IActionResult GetType(int id)
        {
            try
            {
                var result = _context.Types.FirstOrDefault(type => type.Id == id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
        
        #region Entry

        [HttpGet]
        [Route("entry")]
        public IActionResult GetAllEntries()
        {
            return Ok(_context.Entries);
        }

        [HttpGet]
        [Route("entry/{id:int}")]
        public IActionResult GetEntryCollection(int id)
        {
            try
            {
                //var collection = _context.Entries.Where(entry => entry.Id == id);
                //return Ok(collection);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("entry/p/{id:int}")]
        public IActionResult GetEntryCollectionsByPlayer(int id)
        {
            try
            {
                //var collection = _context.Entries.AsEnumerable().Where(entry => entry.PlayerId == id).GroupBy(entry => entry.Id);
                //var collection = _context.Entries.Where(entry => entry.PlayerId == id).OrderBy(entry => entry.Id);
                //return Ok(collection);
                return Ok();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest();
            }
        }
        
        [HttpGet]
        [Route("entry/p/{id:int}/g")]
        public IActionResult GetEntryCollectionsByPlayerGrouped(int id)
        {
            try
            {
                //var collection = _context.Entries.AsEnumerable().Where(entry => entry.PlayerId == id).OrderBy(entry => entry.Id).GroupBy(entry => entry.Id);
                //var collection = _context.Entries.Where(entry => entry.PlayerId == id);
                //return Ok(collection);
                return Ok();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("entry/t/{id:int}")]
        public IActionResult GetEntryCollectionsByType(int id)
        {
            try
            {
                var collection = _context.Entries.Where(entry => entry.TypeId == id);
                return Ok(collection);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
        
         #region Collection

        [HttpGet]
        [Route("collection")]
        public IActionResult GetAllCollections()
        {
            return Ok(_context.Collections);
        }

        [HttpGet]
        [Route("collection/{id:int}")]
        public IActionResult GetCollection(int id)
        {
            try
            {
                var result = _context.Collections.Where(c => c.Id == id).FirstOrDefault();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("collection/p/{id:int}")]
        public IActionResult GetCollectionsByPlayer(int id)
        {
            try
            {
                var result = _context.Collections.Where(c => c.PlayerId == id);
                if (!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest();
            }
        }
        
        #endregion
    }
}