using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.DTO
{
    public class NovoUserDTO
    {
        [Required(ErrorMessage = "O username é obrigatório")]
        public string username { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string email { get; set; }
    }
}
