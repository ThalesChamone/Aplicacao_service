using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public double Numero { get; set; }
        public Convenio Convenio { get; set; }
        public int? ConvenioId { get; set; }
        public Procedimento Procedimento { get; set; }
        public int? ProcedimentoId { get; set; }

        public Paciente(int id, string nome, string cPF, string email, string cEP, string rua, string bairro, double numero, Convenio convenio, int? convenioId, Procedimento procedimento, int? procedimentoId)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            Email = email;
            CEP = cEP;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Convenio = convenio;
            ConvenioId = convenioId;
            Procedimento = procedimento;
            ProcedimentoId = procedimentoId;
        }

        public Paciente()
        {
        }
    }
}
