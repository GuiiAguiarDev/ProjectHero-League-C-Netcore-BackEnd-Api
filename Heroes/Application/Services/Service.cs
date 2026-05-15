using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;


namespace Application.Services
{
    public class Service
    {
        private readonly IHeroe _repository;
        private readonly ILeague _repositoryLeague;

        public Service(IHeroe repository, ILeague repositoryLeague)
        {
            _repository = repository;
            _repositoryLeague = repositoryLeague;
        }

        public async Task Save(Heroe heroe)
        {
            var leagueExists = await _repositoryLeague.LeaguesExists(heroe.LeagueId);
            if (!leagueExists)
            {
                throw new Exception("League don't exists");
            }
            await _repository.Save(heroe);
        }

        public async Task<IEnumerable<Heroe>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Heroe?> FindById(Guid id)
        {
            return await _repository.FindById(id);

        }
             

        public async Task Delete(Guid id)
        {
            var h = await _repository.FindById(id);

            await _repository.Delete(h);
        }

        public async Task Update(Guid id, Heroe HeroeUpdate){
           var  h = await _repository.FindById(id);

            h.Name = HeroeUpdate.Name;
            h.HeroeName = HeroeUpdate.HeroeName;
            h.Age = HeroeUpdate.Age;

            await _repository.Update(h);
        }


        //Bbusca trazendo todos os dados a partir do relacionamento
        //de heroe e league junto amarrado (FindAll)

        public async Task<List<HeroeLeagueDtoResponse>> FindAllHeroeLeague()
        {
            var heroes = await _repository.FindAll();
            var result = new List<HeroeLeagueDtoResponse>();

            foreach(var heroe in heroes)
            {
                var league = await _repositoryLeague.GetLeagueById(heroe.LeagueId);

                result.Add(new HeroeLeagueDtoResponse
                {
                    Id = heroe.Id,
                    Name = heroe.Name,
                    HeroeName = heroe.HeroeName,
                    Age = heroe.Age,
                    League = league



                });
            }
            return result;
        }

        //Busca trazendo especifico um por um pelo id
        //os dados a partir do relacionamento
        //de heroe e league junto amarrado (FindById)
        public async Task<HeroeLeagueDtoResponse> FindByIdHeroeLeague(Guid id)
        {
            var heroe = await _repository.FindById(id);

            if (heroe == null)
            {
                throw new Exception("Heroe not found");
            }

            var league = await _repositoryLeague.GetLeagueById(heroe.LeagueId);

            return new HeroeLeagueDtoResponse
            {
                Id = heroe.Id,
                Name = heroe.Name,
                HeroeName = heroe.HeroeName,
                Age = heroe.Age,
                League = league
            };
        }
    }
}
