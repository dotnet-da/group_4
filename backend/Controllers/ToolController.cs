using System;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult CreatePlayer(int? id, string name)
        {
            if (!id.HasValue && string.IsNullOrEmpty(name))
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
        
        [HttpDelete]
        [Route("player", Name = "delete_player")]
        public IActionResult DeletePlayer(int? id, string name)
        {
            if (!id.HasValue && string.IsNullOrEmpty(name))
            {
                return BadRequest();
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

                    _context.Players.Remove(result);
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

                    _context.Players.Remove(result);
                }
                catch
                {
                    return BadRequest();
                }
            }
            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpPut]
        [Route("player", Name = "update_player")]
        public IActionResult UpdatePlayer(int? id, string name)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                var entity = _context.Players.Where(p => p.Id == id).First();
                entity.Name = !string.IsNullOrEmpty(name) ? name : entity.Name;
                _context.SaveChanges();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #endregion

        #region Type

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

        [HttpDelete]
        [Route("type", Name = "delete_type")]
        public IActionResult DeleteType(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var result = _context.Types.FirstOrDefault(type => type.Id == id);
                if (result == null)
                {
                    return NotFound();
                }

                _context.Types.Remove(result);
            }
            catch
            {
                return BadRequest();
            }

            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpPut]
        [Route("type", Name = "update_type")]
        public IActionResult UpdateType(int? id, string identifier, string description)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                
                var entity = _context.Types.Where(p => p.Id == id).First();
                entity.Identifier = !string.IsNullOrEmpty(identifier) ? identifier : entity.Identifier;
                entity.Description = !string.IsNullOrEmpty(description) ? description : entity.Description;
                _context.SaveChanges();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        #endregion

        #region Entry

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
        
        [HttpDelete]
        [Route("entry", Name = "delete_entry")]
        public IActionResult DeleteEntry(int? cid)
        {
            if (!cid.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var result = _context.Entries.FirstOrDefault(type => type.CollectionId == cid);
                if (result == null)
                {
                    return NotFound();
                }

                _context.Entries.Remove(result);
            }
            catch
            {
                return BadRequest();
            }

            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpPut]
        [Route("entry", Name = "update_entry")]
        public IActionResult UpdateEntry(int? cid, int? tid, int? value)
        {
            try
            {
                if (!cid.HasValue)
                {
                    return BadRequest();
                }
                
                var entity = _context.Entries.Where(p => p.CollectionId == cid).First();
                entity.TypeId = !tid.HasValue ? tid.Value : entity.TypeId;
                entity.Value = !value.HasValue ? value.Value : entity.Value;
                _context.SaveChanges();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #endregion

        #region Collection

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
        
        [HttpDelete]
        [Route("collection", Name = "delete_collection")]
        public IActionResult DeleteCollection(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var result = _context.Collections.FirstOrDefault(type => type.Id == id);
                if (result == null)
                {
                    return NotFound();
                }

                _context.Collections.Remove(result);
            }
            catch
            {
                return BadRequest();
            }

            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpPut]
        [Route("collection", Name = "update_collection")]
        public IActionResult UpdateCollection(int? id, int? pid)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                
                var entity = _context.Collections.Where(p => p.Id == id).First();
                entity.PlayerId = !pid.HasValue ? pid.Value : entity.PlayerId;
                _context.SaveChanges();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #endregion
    }
}

