using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository : ILeague
    {
        private readonly AppDbContext _AppContext;

        public Repository(AppDbContext appContext)
        {
            _AppContext = appContext;
        }

       public async Task Save(League league)
        {
            _AppContext.Leagues.Add(league);
            await _AppContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<League>> FindAll()
        {
            return await _AppContext.Leagues.ToListAsync();
        }

        public async Task<League?>FindById(Guid id)
        {
            return await _AppContext.Leagues.FindAsync(id);
        }

        public async Task Update(League league)
        {
            _AppContext.Leagues.Update(league);
            await _AppContext.SaveChangesAsync();
        }

        public async Task Delete(League league)
        {
            _AppContext.Leagues.Remove(league);
            await _AppContext.SaveChangesAsync();
        }
    }
}
