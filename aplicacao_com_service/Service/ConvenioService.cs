using aplicacao_com_service.Data;
using aplicacao_com_service.Models;
using aplicacao_com_service.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Service
{
    public class ConvenioService
    {
        private readonly aplicacao_com_serviceContext _context;

        public ConvenioService(aplicacao_com_serviceContext context)
        {
            _context = context;
        }
        public List<Convenio> FindAll()
        {
            return _context.Convenio.ToList();
        }        

        public void Insert(Convenio obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Convenio FindById(int id)
        {
            return _context.Convenio.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Convenio.Find(id);
            _context.Convenio.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Convenio obj)
        {
            if(!_context.Convenio.Any(x=>x.Id == obj.Id))
            {
                throw new NotFoundException("ID não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
       
        }
    }
}
