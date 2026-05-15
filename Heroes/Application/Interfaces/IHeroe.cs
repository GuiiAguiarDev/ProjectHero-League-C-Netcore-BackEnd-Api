using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IHeroe
    {
        Task Save(Heroe heroe);
        Task Update(Heroe heroe);
        Task Delete(Heroe heroe);
        Task<Heroe?> FindById(Guid id);
        Task<IEnumerable<Heroe>> FindAll();
        Task<List<Heroe>> FindByName(String name);

    }
}
