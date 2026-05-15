using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class League
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public Boolean IsActive { get; set; }
        public int NumberOfHeroes { get; set; }
        public String Country { get; set; }

        public League()
        {
        }


        public League(String name, Boolean isActive, int numberOfHeroes, String country)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsActive = isActive;
            NumberOfHeroes = numberOfHeroes;
            Country = country;
        }

       
    }
}
