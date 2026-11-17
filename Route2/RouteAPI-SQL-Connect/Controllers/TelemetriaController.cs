using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAPI_SQL_Connect.Data;

namespace RouteAPI_SQL_Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetriaController : ControllerBase
    {
        private readonly RouteDbContext _context;

        public TelemetriaController(RouteDbContext context)
        {
            _context = context;
        }

        [HttpGet("devices")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        [HttpPost("devices")]
        public async Task<ActionResult<Device>> RegisterDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return Ok(device);
        }

        [HttpGet("logs")]
        public async Task<ActionResult<IEnumerable<PositioningLog>>> GetLogs()
        {
            return await _context.PositioningLogs.ToListAsync();
        }

        [HttpPost("logs")]
        public async Task<ActionResult<PositioningLog>> CreateLog(PositioningLog log)
        {
            _context.PositioningLogs.Add(log);
            await _context.SaveChangesAsync();
            return Ok(log);
        }

        [HttpPost("logs/lote")]
        public async Task<IActionResult> CreateLogsBatch(List<PositioningLog> logs)
        {
            _context.PositioningLogs.AddRange(logs);
            await _context.SaveChangesAsync();
            return Ok(new { Inseridos = logs.Count });
        }
    }
}