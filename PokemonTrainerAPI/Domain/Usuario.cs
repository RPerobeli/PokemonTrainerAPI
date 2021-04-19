using System.Collections.Generic;

namespace PokemonTrainerAPI.Domain
{
    public class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public List<Pokemon> ListaDePokemons { get; set; }

        internal void SetUsername(string name)
        {
            username = name;
        }

        internal void SetEmail(string _email)
        {
            email = _email;
        }
    }
}
