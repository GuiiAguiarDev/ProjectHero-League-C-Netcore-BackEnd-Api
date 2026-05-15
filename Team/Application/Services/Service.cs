using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class Service
    {

        private readonly ILeague _repository;

        public Service(ILeague repository)
        {
            _repository = repository;
        }

        public async Task Save(League league)
        {
            await _repository.Save(league);
        }

        public async Task<IEnumerable<League>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<League?>FindById(Guid id)
        {
            return await _repository.FindById(id);
        }

        public async Task Update(Guid id, League updateLeague)
        {
            var l = await _repository.FindById(id);

            l.Name = updateLeague.Name;
            l.NumberOfHeroes = updateLeague.NumberOfHeroes;
            l.Country = updateLeague.Country;

            await _repository.Update(l);

        }

        public async Task Delete(Guid id)
        {
            var l = await _repository.FindById(id);

            await _repository.Delete(l);
        }
    }
}
