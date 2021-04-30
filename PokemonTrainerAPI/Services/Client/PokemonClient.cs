using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Services.Client
{
    public class PokemonClient
    {
        HttpClient cliente = new HttpClient();

        public PokemonClient()
        {
            cliente.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<PokemonFull> GetPokemonAsync(string nomePokemon)
        {
            HttpResponseMessage response = await cliente.GetAsync($"{nomePokemon.ToLower()}/");
            PokemonFull pokemonResultado = new PokemonFull();

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                pokemonResultado = JsonConvert.DeserializeObject<PokemonFull>(dados);
                return pokemonResultado;
            }
            return pokemonResultado;
        }

    }
}
