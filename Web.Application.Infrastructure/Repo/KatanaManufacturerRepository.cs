using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Domain;
using Web.Application.Infrastructure.Data;
using Web.Application.Infrastructure.Interfaces;

namespace Web.Application.Infrastructure.Repo
{
    public class KatanaManufacturerRepository : GenericRepository<KatanaManufacturer>, IKatanaManufacturerRepository
    {
        public KatanaManufacturerRepository(KatanaDbContext context) : base(context) { }

        public async Task<KatanaManufacturer> GetByKatanaId(int id)
        {
            var newContext = (KatanaDbContext)context;
            var result = await newContext.KatanaManufacturers
                .Where(p => p.Katana.Id == id).ToListAsync();

            var result0 = from p in newContext.KatanaManufacturers
                          where p.Katana.Id == id
                          select p;

            return result0.FirstOrDefault();
        }
        public async Task<KatanaManufacturer> GetByManufacturerId(int id)
        {
            var newContext = (KatanaDbContext)context;
            var result = await newContext.KatanaManufacturers
                .Where(p => p.Manufacturer.Id == id).ToListAsync();

            var result0 = from p in newContext.KatanaManufacturers
                          where p.Manufacturer.Id == id
                          select p;

            return result0.FirstOrDefault();
        }
    }
}
