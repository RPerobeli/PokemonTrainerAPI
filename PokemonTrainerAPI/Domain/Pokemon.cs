using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Domain
{
    public class Pokemon
    {
        private int id { get; set; }
        public string nome { get; set; }
        private int idTrainer { get; set; }

        public string Atributo { get; set; }

        //ToDo, adicionar os ataques vindos da pokeapi
    }
}
