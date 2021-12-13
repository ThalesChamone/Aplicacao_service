using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
        public string CPF { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail não tem formato valido")]
        [Required]
        public string Email { get; set; }
        public string CEP { get; set; }

        [Required]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Nome inválido")]
        public string Rua { get; set; }

        [Required]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Nome inválido")]
        public string Bairro { get; set; }
        public double Numero { get; set; }
        public Especialidade Especialidade { get; set; }

        [Display(Name = "Especialidade")]
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
