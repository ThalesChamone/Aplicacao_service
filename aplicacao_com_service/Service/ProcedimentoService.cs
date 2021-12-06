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
    public class ProcedimentoService
    {
        private readonly aplicacao_com_serviceContext _context;

        public ProcedimentoService(aplicacao_com_serviceContext context)
        {
            _context = context;
        }

        public async Task<List<Procedimento>> FindAllAsync()
        {
            return await _context.Procedimento.ToListAsync();
        }

        public async Task<Procedimento> FindByIdAsync(int id)
        {
            return await _context.Procedimento.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Procedimento obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Procedimento.FindAsync(id);
            _context.Procedimento.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Procedimento obj)
        {
            if(!await _context.Procedimento.AnyAsync(x=>x.Id == obj.Id))
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
