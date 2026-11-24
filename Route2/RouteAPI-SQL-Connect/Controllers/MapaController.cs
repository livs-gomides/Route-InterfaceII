using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAPI_SQL_Connect.Data;

namespace RouteAPI_SQL_Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapaController : ControllerBase
    {
        private readonly RouteDbContext _context;

        public MapaController(RouteDbContext context)
        {
            _context = context;
        }

        [HttpGet("locais")]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocals()
        {
            return await _context.Locals.ToListAsync();
        }

        [HttpPost("locais")]
        public async Task<ActionResult<Local>> CreateLocal(Local local)
        {
            _context.Locals.Add(local);
            await _context.SaveChangesAsync();
            return Ok(local);
        }

        [HttpPut("locais")]
        public async Task<IActionResult> UpdateLocal(Local local)
        {
            _context.Locals.Update(local);
            await _context.SaveChangesAsync();
            return Ok(local);
        }

        [HttpDelete("locais/{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var item = await _context.Locals.FindAsync(id);
            if (item == null) return NotFound();

            _context.Locals.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("sublocais")]
        public async Task<ActionResult<IEnumerable<SubLocal>>> GetSubLocals()
        {
            return await _context.SubLocals.ToListAsync();
        }

        [HttpPost("sublocais")]
        public async Task<ActionResult<SubLocal>> CreateSubLocal(SubLocal subLocal)
        {
            _context.SubLocals.Add(subLocal);
            await _context.SaveChangesAsync();
            return Ok(subLocal);
        }

        [HttpPut("sublocais")]
        public async Task<IActionResult> UpdateSubLocal(SubLocal subLocal)
        {
            _context.SubLocals.Update(subLocal);
            await _context.SaveChangesAsync();
            return Ok(subLocal);
        }

        [HttpDelete("sublocais/{id}")]
        public async Task<IActionResult> DeleteSubLocal(int id)
        {
            var item = await _context.SubLocals.FindAsync(id);
            if (item == null) return NotFound();

            _context.SubLocals.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("pontos-interesse")]
        public async Task<ActionResult<IEnumerable<PointOfInterest>>> GetPointsOfInterest()
        {
            return await _context.PointsOfInterest.ToListAsync();
        }

        [HttpPost("pontos-interesse")]
        public async Task<ActionResult<PointOfInterest>> CreatePointOfInterest(PointOfInterest poi)
        {
            _context.PointsOfInterest.Add(poi);
            await _context.SaveChangesAsync();
            return Ok(poi);
        }

        [HttpPut("pontos-interesse")]
        public async Task<IActionResult> UpdatePointOfInterest(PointOfInterest poi)
        {
            _context.PointsOfInterest.Update(poi);
            await _context.SaveChangesAsync();
            return Ok(poi);
        }

        [HttpDelete("pontos-interesse/{id}")]
        public async Task<IActionResult> DeletePointOfInterest(int id)
        {
            var item = await _context.PointsOfInterest.FindAsync(id);
            if (item == null) return NotFound();

            _context.PointsOfInterest.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("beacons")]
        public async Task<ActionResult<IEnumerable<BeaconInfo>>> GetBeacons()
        {
            return await _context.Beacons.ToListAsync();
        }

        [HttpPost("beacons")]
        public async Task<ActionResult<BeaconInfo>> CreateBeacon(BeaconInfo beacon)
        {
            _context.Beacons.Add(beacon);
            await _context.SaveChangesAsync();
            return Ok(beacon);
        }

        [HttpPut("beacons")]
        public async Task<IActionResult> UpdateBeacon(BeaconInfo beacon)
        {
            _context.Beacons.Update(beacon);
            await _context.SaveChangesAsync();
            return Ok(beacon);
        }

        [HttpDelete("beacons/{id}")]
        public async Task<IActionResult> DeleteBeacon(int id)
        {
            var item = await _context.Beacons.FindAsync(id);
            if (item == null) return NotFound();

            _context.Beacons.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}