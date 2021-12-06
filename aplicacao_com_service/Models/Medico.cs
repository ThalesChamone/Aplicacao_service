using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public double Numero { get; set; }
        public Especialidade Especialidade { get; set; }
        public int EspecialidadeId { get; set; }

        public Medico(int id, string nome, string cPF, string email, string cEP, string rua, string bairro, double numero, Especialidade especialidade, int especialidadeId)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            Email = email;
            CEP = cEP;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Especialidade = especialidade;
            EspecialidadeId = especialidadeId;
        }

        public Medico()
        {
        }
    }
}
