using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Models
{
    public class Convenio
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string NomeEmpresa { get; set; }
        public string URL { get; set; }
        public string NomeContato { get; set; }
        public string Email { get; set; }
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
