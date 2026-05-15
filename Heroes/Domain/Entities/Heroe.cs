using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Heroe
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public String HeroeName { get; set; }
        public int Age { get; set; }

        public Guid LeagueId { get; set; }


        public Heroe() { }

        public Heroe(String name, String heroeName, int age, Guid leagueId)
        {
            Id = Guid.NewGuid(); ;
            Name = name;
            HeroeName = heroeName;
            Age = age;
            LeagueId = leagueId;
        }
    }
}

