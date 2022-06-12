using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekt_Sii_WK.Entities;
using Projekt_Sii_WK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Services
{
    public interface ISerwisService
    {
        SerwisDto GetId(int id);

        IEnumerable<SerwisDto> GetAll();

        int Create(UtworzserwisDto dto);

        bool Delete(int id);
        bool Update(int id, UpdateSerwisDto dto);
    }
    public class SerwisServices: ISerwisService
    {
        private readonly SerwisDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<SerwisServices> _logger;
        public SerwisServices(SerwisDbContext dbContext, IMapper mapper, ILogger<SerwisServices> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public SerwisDto GetId(int id)
        {
            var serwis = _dbContext
                .Serwis
                .FirstOrDefault(s => s.Id == id);

            if (serwis is null) return null;
            
            var result = _mapper.Map<SerwisDto>(serwis);
            
            return result;
        }
        public IEnumerable<SerwisDto>GetAll()
        {
            var serwis = _dbContext
                .Serwis
                .Include(s => s.Klient)
                .ToList();

            var serwisdto = _mapper.Map<List<SerwisDto>>(serwis);

            return serwisdto;
        }
        public int Create(UtworzserwisDto dto)
        {
            var serwis = _mapper.Map<Serwis_samoch>(dto);
            _dbContext.Serwis.Add(serwis);
            _dbContext.SaveChanges();

            return serwis.Id;
        }
        public bool Delete (int id)
        {
            _logger.LogWarning($"Serwis o id: {id} został usuniety.");
            var serwis = _dbContext
            .Serwis
            .FirstOrDefault(s => s.Id == id);


            if (serwis is null)
            {
                return false;
            }

            _dbContext.Serwis.Remove(serwis);
            _dbContext.SaveChanges();

            return true;

        }

        public bool Update(int id, UpdateSerwisDto dto)
        {
            var serwis = _dbContext
            .Serwis
            .FirstOrDefault(s => s.Id == id);

            if (serwis is null)
            {
                return false;
            }

            serwis.Garaz = dto.Garaz;
            serwis.Pracownik = dto.Pracownik;

            _dbContext.SaveChanges();
            return true;


        }
    }
}
