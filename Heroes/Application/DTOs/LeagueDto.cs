using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LeagueDto
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public Boolean IsActive { get; set; }
        public int NumberOfHeroes { get; set; }
        public String Country { get; set; }
    }
}
