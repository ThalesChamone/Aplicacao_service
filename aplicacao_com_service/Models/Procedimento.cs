using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Procedimento
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataProcedimento { get; set; }

        [Display(Name = "Nome Procedimento")]
        [Required]
        [RegularExpression(@"^([a-zA-Z ]*?)*$", ErrorMessage = "Formato Inválido")]
        public string NomeProcedimento { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(10, 99999.99, ErrorMessage = "Valor procedimento deve estar entre {1} e {2}")]
        public double Valor { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z ]*?)*$", ErrorMessage = "Formato Inválido")]
        public string Sexo { get; set; }

        [DisplayName("Exceção")]
        [RegularExpression(@"([\s\S]+?(?=\b[a-z][0-9][)]|$))")]
        public string Observacoes { get; set; }

        public Procedimento(int id, DateTime dataProcedimento, string nomeProcedimento, double valor, string sexo, string observacoes)
        {
            Id = id;
            DataProcedimento = dataProcedimento;
            NomeProcedimento = nomeProcedimento;
            Valor = valor;
            Sexo = sexo;
            Observacoes = observacoes;
        }

        public Procedimento()
        {
        }
    }
}
