using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository : IHeroe
    {

        private readonly AppDbContext _AppContext;

        public Repository(AppDbContext appContext)
        {
            _AppContext = appContext;
        }

        public async Task Save(Heroe heroe)
        {
             _AppContext.SuperHeroes.Add(heroe);
             await _AppContext.SaveChangesAsync();
        }

        public async Task <Heroe?>FindById(Guid id)
        {
            return await _AppContext.SuperHeroes.FindAsync(id);
        }

        public async Task<IEnumerable<Heroe>>FindAll()
        {
            return await _AppContext.SuperHeroes.ToListAsync();
        }

        public async Task Update(Heroe heroe)
        {
            _AppContext.SuperHeroes.Update(heroe);
             await _AppContext.SaveChangesAsync();
        }

        public async Task Delete(Heroe hero)
        {
            _AppContext.SuperHeroes.Remove(hero);
            await _AppContext.SaveChangesAsync();

        }

        public Task<List<Heroe>> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }


}
