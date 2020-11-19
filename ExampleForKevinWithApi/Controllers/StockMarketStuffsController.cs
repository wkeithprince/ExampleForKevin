#region References

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleForKevin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#endregion

namespace ExampleForKevinWithApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMarketStuffsController : ControllerBase
    {
        private readonly ExampleKevinDbContext _context;

        public StockMarketStuffsController(ExampleKevinDbContext context)
        {
            _context = context;
        }

        // DELETE: api/StockMarketStuffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockMarketStuff>> DeleteStockMarketStuff(int id)
        {
            var stockMarketStuff = await _context.StockMarketStuff.FindAsync(id);
            if (stockMarketStuff == null)
            {
                return NotFound();
            }

            _context.StockMarketStuff.Remove(stockMarketStuff);
            await _context.SaveChangesAsync();

            return stockMarketStuff;
        }

        // GET: api/StockMarketStuffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockMarketStuff>>> GetStockMarketStuff()
        {
            return await _context.StockMarketStuff.ToListAsync();
        }

        // GET: api/StockMarketStuffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockMarketStuff>> GetStockMarketStuff(int id)
        {
            var stockMarketStuff = await _context.StockMarketStuff.FindAsync(id);

            if (stockMarketStuff == null)
            {
                return NotFound();
            }

            return stockMarketStuff;
        }

        // POST: api/StockMarketStuffs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StockMarketStuff>> PostStockMarketStuff(StockMarketStuff stockMarketStuff)
        {
            _context.StockMarketStuff.Add(stockMarketStuff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockMarketStuff", new {id = stockMarketStuff.StockMarketStuffId}, stockMarketStuff);
        }

        // PUT: api/StockMarketStuffs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockMarketStuff(int id, StockMarketStuff stockMarketStuff)
        {
            if (id != stockMarketStuff.StockMarketStuffId)
            {
                return BadRequest();
            }

            _context.Entry(stockMarketStuff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockMarketStuffExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        private bool StockMarketStuffExists(int id)
        {
            return _context.StockMarketStuff.Any(e => e.StockMarketStuffId == id);
        }
    }
}