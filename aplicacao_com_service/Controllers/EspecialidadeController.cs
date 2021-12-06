using aplicacao_com_service.Models;
using aplicacao_com_service.Service;
using aplicacao_com_service.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Controllers
{
    public class EspecialidadeController : Controller
    {
        private readonly EspecialidadeService _especialidadeService;

        public EspecialidadeController(EspecialidadeService especialidade)
        {
            _especialidadeService = especialidade;
        }
        // GET: EspecialidadeController
        public async Task<ActionResult> Index()
        {
            var list = await _especialidadeService.FindAllAsync();
            return View(list);
        }

        // GET: EspecialidadeController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = await _especialidadeService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // GET: EspecialidadeController/Create
        public async Task<ActionResult> Create()
        {          
            return View(nameof(Create));
        }

        // POST: EspecialidadeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Especialidade especialidade)
        {            
            try
            {
                await _especialidadeService.InsertAsync(especialidade);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

        // GET: EspecialidadeController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _especialidadeService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: EspecialidadeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Especialidade especialidade)
        {
            if (id != especialidade.Id)
            {
                return BadRequest();
            }
            try
            {
                await _especialidadeService.UpdateAsync(especialidade);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

        // GET: EspecialidadeController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = await _especialidadeService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: EspecialidadeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _especialidadeService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
