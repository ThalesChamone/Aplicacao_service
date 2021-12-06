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
    public class MedicoService
    {
        private readonly aplicacao_com_serviceContext _context;        

        public MedicoService(aplicacao_com_serviceContext context)
        {
            _context = context;   
        }

        public async Task<List<Medico>> FindAllAsync()
        {
            return await _context.Medico.Include(med=>med.Especialidade).ToListAsync();
        }

        public async Task<Medico> FindByIdAsync(int id)
        {
            return await _context.Medico.Include(obj => obj.Especialidade).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(Medico obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Medico.FindAsync(id);
            _context.Medico.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medico obj)
        {
            if (!await _context.Medico.AnyAsync(x => x.Id == obj.Id))
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
