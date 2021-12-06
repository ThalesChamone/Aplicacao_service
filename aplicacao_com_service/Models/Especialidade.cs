using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
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
