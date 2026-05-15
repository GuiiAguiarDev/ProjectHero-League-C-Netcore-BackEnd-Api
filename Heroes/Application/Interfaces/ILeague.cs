using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILeague
    {
        //Verifica se existe o Id Do League para fazer o relacionamento referencial
        Task<bool> LeaguesExists(Guid LeagueID);

        //Fazer a busca e trazer os dados amarrados quando buscar por heroe trazer a liga dele
        Task<LeagueDto> GetLeagueById(Guid LeagueId);

    }
}
