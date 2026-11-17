using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAPI_SQL_Connect.Data;

namespace RouteAPI_SQL_Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SyncController : ControllerBase
    {
        private readonly RouteDbContext _context;

        public SyncController(RouteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMapData()
        {
            var locals = await _context.Locals.AsNoTracking().ToListAsync();
            var subLocals = await _context.SubLocals.AsNoTracking().ToListAsync();
            var pointsOfInterest = await _context.PointsOfInterest.AsNoTracking().ToListAsync();
            var beacons = await _context.Beacons.AsNoTracking().ToListAsync();

            return Ok(new
            {
                SincronizadoEm = DateTime.UtcNow,
                Locals = locals,
                SubLocals = subLocals,
                PointsOfInterest = pointsOfInterest,
                Beacons = beacons
            });
        }
    }
}