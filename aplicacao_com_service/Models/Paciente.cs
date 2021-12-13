using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
        public string CPF { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail não tem formato valido")]
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }

        [Required]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Nome inválido")]
        public string Bairro { get; set; }
        public double Numero { get; set; }
        public Convenio Convenio { get; set; }

        [Display(Name = "Convenio Cadastrado")]
        public int? ConvenioId { get; set; }
        public Procedimento Procedimento { get; set; }

        [Display(Name = "Procedimento")]
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
