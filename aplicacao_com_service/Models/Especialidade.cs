using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Especialidade
    {
        public int Id { get; set; }

        [Display(Name = "Especialidade Médica")]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Nome inválido")]
        public string NomeEspecialidade { get; set; }

        public Especialidade(int id, string nomeEspecialidade)
        {
            Id = id;
            NomeEspecialidade = nomeEspecialidade;
        }

        public Especialidade()
        {
        }
    }
}
