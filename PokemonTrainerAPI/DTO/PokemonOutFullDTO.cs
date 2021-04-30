using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.DTO
{
    public class PokemonOutFullDTO
    {
        public string Nome { get; set; }
        public IList<string> Tipo { get; set; }
        public IList<string> Abilities { get; set; }

        public IList<string> Moves { get; set; }
        public PokemonOutFullDTO()
        {
            Tipo = new List<string>();
            Abilities = new List<string>();
            Moves = new List<string>();
        }
    }
}
