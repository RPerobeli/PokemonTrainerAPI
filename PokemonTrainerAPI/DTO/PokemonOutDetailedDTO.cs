using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.DTO
{
    public class PokemonOutDetailedDTO
    {
        public string Nome { get; set; }
        public IList<string> Tipo { get; set; }
        public IList<string> Abilities { get; set; }
        public PokemonOutDetailedDTO()
        {
            Tipo = new List<string>();
            Abilities = new List<string>();
        }
    }
}
