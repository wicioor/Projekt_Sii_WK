using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Sii_WK.Entities;
using Projekt_Sii_WK.Models;
using Projekt_Sii_WK.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Controllers
{
    [Route("api/serwis")]
    public class SerwisController : ControllerBase
    {
        private readonly ISerwisService _serwisService;
        public SerwisController(ISerwisService serwisService)
        {
            _serwisService = serwisService;
        }

        //[HttpGet("dto")]
        //public ActionResult<IEnumerable<SerwisDto>> GetDto()
        //{
        //    var serwis = _dbContext
        //        .Serwis
        //        .Include(s => s.Klient)
        //        .ToList();

        //    var serwisdto = _mapper.Map<List<SerwisDto>>(serwis);

        //    return Ok(serwisdto);

        //}

        [HttpGet("{id}")]
        public ActionResult<Serwis_samoch> Get([FromRoute] int id)
        {
            var serwis = _serwisService.GetId(id);
            if (serwis is null)
            {
                return NotFound();
            }

            return Ok(serwis);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Serwis_samoch>> GetAll()
        {
            var serwisDto = _serwisService.GetAll();

            return Ok(serwisDto);

        }

        [HttpPost]
        public ActionResult Utworzserwis([FromBody] UtworzserwisDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _serwisService.Create(dto);
            return Created($"/api/serwis/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _serwisService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateSerwisDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var IsUpdated = _serwisService.Update(id, dto);
            if (!IsUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
