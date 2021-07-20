using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumiblesController : Controller
    {
        private readonly ActivosTIContext _context;

        public ConsumiblesController(ActivosTIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetConsumibles()
        {
            var ShowList = await _context.Consumibles.OrderBy(item => item.Nombre).ToListAsync();

            return Ok(ShowList);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetConsumibles(int Id)
        {
            var ShowItem = await _context.Consumibles.FirstOrDefaultAsync(item => item.Id == Id);

            if (ShowItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ShowItem);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddConsumibles([FromBody] Consumible consumible)
        {


            if (consumible == null)
            {
                return BadRequest(ModelState);
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(consumible);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateConsumibles(int Id, Consumible consumible)
        {

            if (Id != consumible.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (consumible.Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteConsumibles(int Id)
        {
            try
            {
                var tipoAcvoTi = _context.Consumibles.Where(item => Id == item.Id).FirstOrDefault();
                _context.Remove(tipoAcvoTi);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
