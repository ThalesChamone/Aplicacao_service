using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aplicacao_com_service.Models;

namespace aplicacao_com_service.Data
{
    public class aplicacao_com_serviceContext : DbContext
    {
        public aplicacao_com_serviceContext (DbContextOptions<aplicacao_com_serviceContext> options)
            : base(options)
        {
        }

        public DbSet<aplicacao_com_service.Models.Especialidade> Especialidade { get; set; }
        public DbSet<aplicacao_com_service.Models.Procedimento> Procedimento { get; set; }
        public DbSet<aplicacao_com_service.Models.Medico> Medico { get; set; }
        public DbSet<aplicacao_com_service.Models.Paciente> Paciente { get; set; }
        public DbSet<aplicacao_com_service.Models.Convenio> Convenio { get; set; }
    }
}
