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

        [HttpGet("TipoActivos")]

        public async Task<IActionResult> GetATipoActivos()
        {
        
            var ShowItem = await _context.CategoriaTis.ToListAsync();
            var TipoActivo_CategoriaTI = await _context.CategoriaTiTpas.OrderBy(item => item.IdTipoActivo).ToListAsync();
            var TipoActivo = await _context.TipoActivoTis.OrderBy(item => item.Id).ToListAsync();

            var categoria_tipoActivo = from itemActivo in ShowItem
                                       join itemCategoria in TipoActivo_CategoriaTI
                         on itemActivo.Id equals itemCategoria.IdCategoriaTi
                         select new
                         {
                             Id = itemCategoria.IdTipoActivo,
                             Nombre = itemActivo.Nombre
                         };

            //var Activos = await _context.Activos.OrderBy(item => item.IdTipo).ToListAsync();
            var data_activos = from itemActivo in TipoActivo
                               join itemCategoria in categoria_tipoActivo
                                on itemActivo.Id equals itemCategoria.Id
                                select new
                                {
                                    Id = itemCategoria.Id,
                                    Nombre = itemActivo.Nombre
                                };


            /*if (Tipo == "Consumibles")
           {
               var Consumibles = await _context.Consumibles.OrderBy(item => item.IdTipo).ToListAsync();
               var data_consumibles = from itemActivo in Consumibles
                                      join itemCategoria in categoria_tipoActivo
                                  on itemActivo.IdTipo equals itemCategoria.Id
                                  select new
                                  {
                                      Id = itemActivo.Id,
                                      NombreTipoActivo = itemCategoria.Nombre,
                                      NombreInventario = itemActivo.Nombre
                                  };
           }

           if (Tipo == "Perifericos")
           {
               var Perifericos = await _context.Perifericos.OrderBy(item => item.IdTipo).ToListAsync();
               var data_activos = from itemActivo in Perifericos
                                  join itemCategoria in categoria_tipoActivo
                                  on itemActivo.IdTipo equals itemCategoria.Id
                                  select new
                                  {
                                      Id = itemActivo.Id,
                                      NombreTipoActivo = itemCategoria.Nombre,
                                      NombreInventario = itemActivo.Nombre,
                                      Serial = itemActivo.Serial
                                  };
           }*/


            if (ShowItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data_activos);
            }
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActivo(int Id)
        {
            try
            {
                var tipoAcvoTi = _context.TipoActivoTis.Where(item => Id == item.Id).FirstOrDefault();
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
