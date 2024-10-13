using PARCIAL._20200112.DOMAIN.Core.Entities;
using PARCIAL._20200112.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PARCIAL._20200112.DOMAIN.Core.Interfaces;

namespace PARCIAL._20200112.DOMAIN.Infrastructure.Repositories
{
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Parcial20240220200112DbContext _dbContext;

        public MechanicRepository(Parcial20240220200112DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Mechanic>> GetMechanic()
        {
            var mechanic = await _dbContext.Mechanic.ToListAsync();
            return mechanic;
        }

        public async Task<Mechanic> GetMechanicById(int id)
        {
            var mechanic = await _dbContext
                            .Mechanic
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();
            return mechanic;
        }

        public async Task<int> Insert(Mechanic mechanic)
        {
            mechanic.IsActive = true;

            await _dbContext.Mechanic.AddAsync(mechanic);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? mechanic.Id : -1;
        }

        public async Task<bool> Update(Mechanic mechanic)
        {
            _dbContext.Mechanic.Update(mechanic);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var mechanic = await GetMechanicById(id);
            if (mechanic == null) return false;

            //_dbContext.Category.Remove(category);
            //int rows = await _dbContext.SaveChangesAsync();
            mechanic.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
