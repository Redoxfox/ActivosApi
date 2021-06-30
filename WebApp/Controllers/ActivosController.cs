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
            var ShowItem = await _context.TipoActivoTis.FirstOrDefaultAsync(item => item.Id==Id);

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
        public async Task<IActionResult> AddActivos([FromBody]TipoActivoTi tipoActivoTi)
        {
            

            if (tipoActivoTi == null)
            {
                return BadRequest(ModelState);
            }


            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(tipoActivoTi);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
