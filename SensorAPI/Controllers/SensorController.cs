using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SensorAPI.Models;
using SensorAPI.Service;


namespace SensorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly SensorContext _context;
        private readonly SensorService _service;

        public SensorController(SensorContext context)
        {
            _context = context;
            _service = new SensorService();

            /*
            if (_context.SensorItems.Count() == 0)
            {
                _context.SensorItems.Add(new SensorItem {Timestamp = 1539112021301,
                                                         Tag = "brasil.sudeste.sensor01",
                                                         Valor = "1"});
                _context.SaveChanges();
            }
            */

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorItem>>> GetSensorItems()
        {
            
            return await _context.SensorItems.ToListAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SensorItem>> GetSensorItem(long id)
        {
            var SensorItem = await _context.SensorItems.FindAsync(id);

            if (SensorItem == null)
            {
                return NotFound();
            }

            return SensorItem;
        }

        [HttpPost]
        public async Task<ActionResult<SensorItem>> PostSensorItem(SensorItem item)
        {
            _context.SensorItems.Add(item);
            _service.Write(item);

            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetSensorItem), new { id = item.Id }, item);
        }
    }
}
