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

        /*[HttpGet]
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
        
        //[HttpGet]
        //[Route("player/{name:string}")]
        public IActionResult GetPlayer(string name)
        {
            try
            {
                var result = _context.Players.FirstOrDefault(player => player.Name == name);
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

        [HttpGet(Name = "player")]
        public IActionResult Get([FromQuery]int? id, [FromQuery]string name)
        {
            if (id.HasValue)
            {
                return GetPlayer(id.Value);
            }
            return string.IsNullOrEmpty(name) ? GetPlayer(name) : GetAllPlayers();
        }*/

        [HttpGet]
        [Route("player", Name = "get_player")]
        public IActionResult GetPlayer(int? id, string name)
        {
            if (!id.HasValue && string.IsNullOrEmpty(name))
            {
                var result = _context.Players;
                return Ok(result);
            }

            if (id.HasValue)
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

            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    var result = _context.Players.FirstOrDefault(player => player.Name == name);
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

            return BadRequest();
        }

        [HttpPost]
        [Route("player", Name = "create_player")]
        public IActionResult CreatePlayer([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            try
            {
                var entity = new ToolModel.Player()
                {
                    Name = name
                };
                _context.Players.Add(entity);
                _context.SaveChanges();
                return CreatedAtRoute("get_player", new { id = entity.Id }, entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region Type

        /*[HttpGet]
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
        }*/

        [HttpGet]
        [Route("type", Name = "get_type")]
        public IActionResult GetType(int? id, string identifier)
        {
            if (!id.HasValue && string.IsNullOrEmpty(identifier))
            {
                var result = _context.Types;
                return Ok(result);
            }

            if (id.HasValue)
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

            if (!string.IsNullOrEmpty(identifier))
            {
                try
                {
                    var result = _context.Types.FirstOrDefault(type => type.Identifier == identifier);
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

            return BadRequest();
        }

        [HttpPost]
        [Route("type", Name = "create_type")]
        public IActionResult CreateType(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                return BadRequest();
            }

            try
            {
                var entity = new ToolModel.Type()
                {
                    Identifier = identifier
                };
                _context.Types.Add(entity);
                _context.SaveChanges();
                return CreatedAtRoute("get_type", new { id = entity.Id }, entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region Entry

        /*[HttpGet]
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
        }*/

        [HttpGet]
        [Route("entry", Name = "get_entry")]
        public IActionResult GetEntry(int? cid, int? tid)
        {
            if (!cid.HasValue)
            {
                if (!tid.HasValue)
                {
                    var result = _context.Entries;
                    return Ok(result);
                }
                else
                {
                    var result = _context.Entries.Where(entry => entry.TypeId == tid.Value);
                    return Ok(result);
                }
            }

            try
            {
                if (!tid.HasValue)
                {
                    var result = _context.Entries.Where(entry => entry.CollectionId == cid);
                    if (!result.Any())
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }
                else
                {
                    var result = _context.Entries.Where(entry => entry.CollectionId == cid)
                        .Where(entry => entry.TypeId == tid);
                    if (!result.Any())
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("entry", Name = "create_entry")]
        public IActionResult CreateEntry(int? cid, int? tid, int? value)
        {
            if (!cid.HasValue)
            {
                return BadRequest();
            }

            if (!tid.HasValue)
            {
                return BadRequest();
            }

            if (!value.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var entity = new ToolModel.Entry()
                {
                    CollectionId = cid.Value,
                    TypeId = tid.Value,
                    Value = value.Value
                };
                _context.Entries.Add(entity);
                _context.SaveChanges();

                return CreatedAtRoute("get_entry", new { cid = entity.CollectionId, tid = entity.TypeId }, entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region Collection

        /*[HttpGet]
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
        }*/

        [HttpGet]
        [Route("collection", Name = "get_collection")]
        public IActionResult GetCollection(int? id, int? pid)
        {
            try
            {
                if (!id.HasValue && !pid.HasValue)
                {
                    var result = _context.Collections;
                    return Ok(result);
                }

                if (id.HasValue)
                {
                    var result = _context.Collections.Where(collection => collection.Id == id.Value);
                    if (!result.Any())
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }

                if (pid.HasValue)
                {
                    var result = _context.Collections.Where(collection => collection.PlayerId == pid.Value);
                    if (!result.Any())
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }

            return BadRequest();
        }
        
        [HttpPost]
        [Route("collection", Name = "create_collection")]
        public IActionResult CreateCollection(int? pid)
        {
            if (!pid.HasValue)
            {
                return BadRequest(); 
            }
            
            try
            {
                var entity = new ToolModel.Collection()
                {
                    PlayerId = pid.Value
                };
                _context.Collections.Add(entity);
                _context.SaveChanges();
                return CreatedAtRoute("get_collection", new { id = entity.Id }, entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
    }
}