﻿using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Services.Interfaces
{
    public interface IUserService
    {
        void AdicionarUsuario(NovoUserDTO novoUser);
        void MudarNick(string novoNick, int id);
        IList<Pokemon> ListarPokemonsDoUser(int id);

    }
}