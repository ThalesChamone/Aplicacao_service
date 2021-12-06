using aplicacao_com_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Data
{
    public class SeedingService
    {
        private aplicacao_com_serviceContext _context;

        public SeedingService(aplicacao_com_serviceContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Convenio.Any() ||
                _context.Especialidade.Any() ||
                _context.Paciente.Any() ||
                _context.Medico.Any() ||
                _context.Procedimento.Any())
            {
                return;
            }

            Procedimento p1 = new Procedimento(1, new DateTime(2021, 4, 26), "Cirurgia Bariátrica", 5789.90, "Ambos", "");
            Procedimento p2 = new Procedimento(2, new DateTime(2021, 11, 19), "Cateterismo Vesical", 2145.65, "Ambos", "");

            Convenio c1 = new Convenio(1, "Te curo e te Cobro", "Curando Amém", "", "Maria De Jesus", "curandoAmem@gmail.com", "3498761534");
            Convenio c2 = new Convenio(2, "Adoença e me Enriqueça", "Na Doença vem a Fortuna", "", "Maria Dólares USA", "dinheiro@gmail.com", "3498761534");

            Especialidade ep1 = new Especialidade(1, "Cirurgião Geral");
            Especialidade ep2 = new Especialidade(2, "Clínico Geral");

            Medico m1 = new Medico(1, "Heni Pereira", "45609832145","heniDCOTOR@gmail.com", "20013456", "Jarniz", "Centro", 200, ep1, 1);
            Medico m2 = new Medico(2, "Pedro Marques", "12376589000","pedroCLINICA@gmail.com","31245689", "Machado", "Cidade Nova", 1245, ep2, 2);

            Paciente pac1 = new Paciente(1, "Nilson Arrancar", "08745612345", "niilson@gmail.com" , "23451178", "Carnaval", "Horto", 789, c1, 1, p2, 2);

            _context.Procedimento.AddRange(p1, p2);

            _context.Convenio.AddRange(c1, c2);

            _context.Especialidade.AddRange(ep1, ep2);

            _context.Medico.AddRange(m1, m2);

            _context.Paciente.AddRange(pac1);

            _context.SaveChanges();
        }
    }
}
