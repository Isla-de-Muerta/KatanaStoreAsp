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
    public class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(KatanaDbContext context) : base(context) { }
        public async Task<Price> GetByAmount(decimal amount)
        {
            var newContext = (KatanaDbContext)context;
            var result = await newContext.Prices
                .Where(p => p.Amount == amount).ToListAsync();

            var result0 = from p in newContext.Prices
                          where p.Amount == amount
                          select p;

            return result0.FirstOrDefault();
        }
    }
}
