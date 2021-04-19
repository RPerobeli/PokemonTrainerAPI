using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Domain
{
    public class Pokemon
    {
        public int id { get; set; }
        public string nome { get; set; }

        public int idTrainer { get; set; }
        public Usuario trainer { get; set; }


        //public string Atributo { get; set; }

        //ToDo, adicionar os ataques vindos da pokeapi
    }
}
