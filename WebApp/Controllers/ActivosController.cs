using Microsoft.AspNetCore.Http;
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
    public class ActivosController : ControllerBase
    {
        private readonly ActivosTIContext _context;

        public ActivosController(ActivosTIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivos()
        {
            var ShowList = await _context.TipoActivoTis.OrderBy(item => item.Nombre).ToListAsync();

            return Ok(ShowList);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetActivos(int Id)
        {
            var ShowItem = await _context.TipoActivoTis.FirstOrDefaultAsync(item => item.Id == Id);

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
        public async Task<IActionResult> AddActivos([FromBody] TipoActivoTi tipoActivoTi)
        {


            if (tipoActivoTi == null)
            {
                return BadRequest(ModelState);
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(tipoActivoTi);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateActivo(int Id , TipoActivoTi tipoActivoTi)
        {
           /* if (Id == tipoActivoTi.Id)
            {
                _context.Entry(tipoActivoTi).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();*/

            if (Id != tipoActivoTi.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoActivoTi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (tipoActivoTi.Id==0)
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

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteActivo(int Id, [FromQuery] TipoActivoTi tipoActivoTi)
        {


            if (tipoActivoTi == null)
            {
                return BadRequest();
            }
            if (Id == tipoActivoTi.Id)
            {

                var tipoAcvoTi = _context.TipoActivoTis.Where(item => Id == item.Id).FirstOrDefault();
                _context.Remove(tipoAcvoTi);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return Ok();
        }
    }
}
