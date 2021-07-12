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
    public class mActivosController : Controller
    {

        private readonly ActivosTIContext _context;

        public mActivosController(ActivosTIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetmActivos()
        {
            var ShowList = await _context.Activos.OrderBy(item => item.Nombre).ToListAsync();

            return Ok(ShowList);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetActivos(int Id)
        {
            var ShowItem = await _context.Activos.FirstOrDefaultAsync(item => item.Id == Id);

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
        public async Task<IActionResult> mAddActivos([FromBody] Activo Activo)
        {


            if (Activo == null)
            {
                return BadRequest(ModelState);
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(Activo);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateActivo(int Id, Activo Activo)
        {

            if (Id != Activo.Id)
            {
                return BadRequest();
            }

            _context.Entry(Activo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Activo.Id == 0)
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
        public async Task<IActionResult> DeleteActivo(int Id)
        {
            try
            {
                var tipoAcvoTi = _context.Activos.Where(item => Id == item.Id).FirstOrDefault();
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
