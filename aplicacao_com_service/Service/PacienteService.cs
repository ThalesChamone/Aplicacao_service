using aplicacao_com_service.Data;
using aplicacao_com_service.Models;
using aplicacao_com_service.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Service
{

    public class PacienteService
    {
        private readonly aplicacao_com_serviceContext _context;

        public PacienteService(aplicacao_com_serviceContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> FindAllAsync()
        {
            var listIndex = _context.Paciente.Include(x => x.Convenio).Include(x => x.Procedimento);
            return await listIndex.ToListAsync();
        }

        public async Task<Paciente> FindByIdAsync(int id)
        {
            return await _context.Paciente.Include(obj => obj.Convenio).
                Include(obj => obj.Procedimento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(Paciente obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente obj)
        {
            if(!await _context.Paciente.AnyAsync(x=>x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}

