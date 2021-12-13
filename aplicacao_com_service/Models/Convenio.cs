using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Convenio
    {
        public int Id { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required]
        public string NomeFantasia { get; set; }

        [Display(Name = "Nome Empresa")]
        [Required]
        [RegularExpression(@"^([a-zA-Z ]*?)*$", ErrorMessage = "Formato Inválido")]
        public string NomeEmpresa { get; set; }
        public string URL { get; set; }

        [Display(Name = "Nome Contato")]
        [Required]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Nome inválido")]
        public string NomeContato { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail não tem formato valido")]
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$", ErrorMessage = "Formato inválido")]
        public string Telefone { get; set; }

        public Convenio(int id, string nomeFantasia, string nomeEmpresa, string uRL, string nomeContato, string email, string telefone)
        {
            Id = id;
            NomeFantasia = nomeFantasia;
            NomeEmpresa = nomeEmpresa;
            URL = uRL;
            NomeContato = nomeContato;
            Email = email;
            Telefone = telefone;
        }

        public Convenio()
        {
        }

    }
}
