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
    public class EspecialidadeService
    {
        private readonly aplicacao_com_serviceContext _context;

        public EspecialidadeService(aplicacao_com_serviceContext context)
        {
            _context = context;
        }

        public async Task<List<Especialidade>> FindAllAsync()
        {
            return await _context.Especialidade.OrderBy(x=>x.NomeEspecialidade).ToListAsync();
        }

        public async Task<Especialidade> FindByIdAsync(int id)
        {
            return await _context.Especialidade.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(Especialidade obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Especialidade.FindAsync(id);
            _context.Especialidade.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Especialidade obj)
        {
            if (!await _context.Especialidade.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("ID não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
