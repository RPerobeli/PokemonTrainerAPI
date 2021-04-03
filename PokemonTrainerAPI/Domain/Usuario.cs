using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Domain
{
    public class Usuario
    {
        private int id { get; set; }
        public string username { get;  private set; }
        public string email { get; private set; }

        private List<Pokemon> ListaDePokemons { get; set; }

    }
}
