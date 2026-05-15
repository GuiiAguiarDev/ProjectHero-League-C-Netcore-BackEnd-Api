using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class HeroeLeagueDtoResponse
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String HeroeName { get; set; }
        public int Age { get; set; }

        public LeagueDto League { get; set; }
    }
}
