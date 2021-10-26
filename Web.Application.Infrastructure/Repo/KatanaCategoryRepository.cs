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
    public class KatanaCategoryRepository : GenericRepository<KatanaCategory>, IKatanaCategoryRepository
    {
        public KatanaCategoryRepository(KatanaDbContext context) : base(context) { }

        public async Task<KatanaCategory> GetByKatanaId(int id)
        {
            var newContext = (KatanaDbContext)context;
            var result = await newContext.KatanaCategories
                .Where(p => p.Katana.Id == id).ToListAsync();

            var result0 = from p in newContext.KatanaCategories
                          where p.Katana.Id == id
                          select p;

            return result0.FirstOrDefault();
        }
        public async Task<KatanaCategory> GetByCategoryId(int id)
        {
            var newContext = (KatanaDbContext)context;
            var result = await newContext.KatanaCategories
                .Where(p => p.Category.Id == id).ToListAsync();

            var result0 = from p in newContext.KatanaCategories
                          where p.Category.Id == id
                          select p;

            return result0.FirstOrDefault();
        }
    }
}
