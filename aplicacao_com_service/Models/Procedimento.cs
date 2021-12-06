using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Procedimento
    {
        public int Id { get; set; }
        public DateTime DataProcedimento { get; set; }
        public string NomeProcedimento { get; set; }
        public double Valor { get; set; }
        public string Sexo { get; set; }
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
