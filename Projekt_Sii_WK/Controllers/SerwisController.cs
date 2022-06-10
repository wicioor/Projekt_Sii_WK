using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Sii_WK.Entities;
using Projekt_Sii_WK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Controllers
{
    [Route("api/serwis")]
    public class SerwisController : ControllerBase
    {
        public SerwisController()
        {

        }


        private readonly SerwisDbContext _dbContext;
        private readonly IMapper _mapper;
        public SerwisController(SerwisDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("dto")]
        public ActionResult<IEnumerable<SerwisDto>> GetDto()
        {
            var serwis = _dbContext
                .Serwis
                .Include(s => s.Klient)
                .ToList();

            var serwisdto = _mapper.Map<List<SerwisDto>>(serwis);

            return Ok(serwisdto);

        }

        [HttpGet("{id}")]
        public ActionResult<Serwis_samoch> Get([FromRoute] int id)
        {
            var serwis = _dbContext
                .Serwis
                .FirstOrDefault(s => s.Id == id);
            if (serwis is null)
            {
                return NotFound();
            }

            return Ok(serwis);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Serwis_samoch>> GetAll()
        {
            var serwis = _dbContext
                .Serwis

                .ToList();

            return Ok(serwis);

        }

        [HttpPost]
        public ActionResult Utworzserwis([FromBody] UtworzserwisDto dto)
        {
            var serwis = _mapper.Map<Serwis_samoch>(dto);
            _dbContext.Serwis.Add(serwis);
            _dbContext.SaveChanges();

            return Created($"/api/serwis/{serwis.Id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromBody] UtworzserwisDto dto)
        {
            var isDeleted = _
        }
    }
}
