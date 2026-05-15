using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILeague
    {

        Task Save(League league);
        Task Update(League league);
        Task Delete(League league);
        Task<IEnumerable<League>> FindAll();
        Task<League?> FindById(Guid id);
    }
}
