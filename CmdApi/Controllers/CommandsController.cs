using CmdApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase //Extend Controller Base for Controllers without View Support
    {

        private readonly ApplicationDbContext _db;

        public CommandsController(ApplicationDbContext db)
        {
            _db = db;
        } 

        //GET:          api/commands 
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return  _db.CommandItems;
        }

        //GET:          api/commands/5
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var command = _db.CommandItems.Find(id);
            if(command == null)
            {
                return NotFound();
            }
            return command;
        }
        //POST:          api/commands
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _db.CommandItems.Add(command);
            _db.SaveChanges();
            return CreatedAtAction("GetCommandItem",new Command {Id= command.Id},command);
        }

        //PUT:          api/commands/5
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }
            _db.Entry(command).State = EntityState.Modified; 
            _db.SaveChanges();

            return NoContent();
        } 

        //DELETE:          api/commands/5
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var command = _db.CommandItems.Find(id);
            if (command == null)
            {
                return NotFound();
            }
            _db.CommandItems.Remove(command);
            _db.SaveChanges();

            return command;
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> GetString()
        //{
        //    return new string[] { "Array","of","any","strings"};
        //}
    }
}
