using AutoMapper;
using Projekt_Sii_WK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Services
{
    public interface ISerwisServices
    {
        bool Delete(int id);
    }
    public class SerwisServices: ISerwisServices
    {
        private readonly SerwisDbContext _dbContext;
        private readonly IMapper _mapper;
        public SerwisServices(SerwisDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public bool Delete(int id)
        {
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
    }
}
