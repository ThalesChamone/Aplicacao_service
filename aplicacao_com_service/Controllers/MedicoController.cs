using aplicacao_com_service.Data;
using aplicacao_com_service.Models;
using aplicacao_com_service.Service;
using aplicacao_com_service.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacao_com_service.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoService _medicoService;
        private readonly EspecialidadeService _especialidadeService;
        private readonly aplicacao_com_serviceContext _context;

        public MedicoController(MedicoService medicoService, EspecialidadeService especialidade, aplicacao_com_serviceContext context)
        {
            _medicoService = medicoService;
            _especialidadeService = especialidade;
            _context = context;
        }
        // GET: MedicoController
        public async Task<IActionResult> Index()
        {
            var list = await _medicoService.FindAllAsync();
            return View(list);
        }

        // GET: MedicoController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                NotFound();
            }
            var obj = await _medicoService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                NotFound();
            }
            return View(obj);
        }

        // GET: MedicoController/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidade, "Id", "NomeEspecialidade");
            return View(nameof(Create));
        }

        // POST: MedicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _medicoService.InsertAsync(medico);
                    return RedirectToAction(nameof(Index));
                }
                catch (NotFoundException)
                {
                    return BadRequest();
                }
            }            
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidade, "Id", "NomeEspecialidade", medico.EspecialidadeId);
            return View(medico);
        }

        // GET: MedicoController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _medicoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidade, "Id", "NomeEspecialidade", obj.EspecialidadeId);
            return View(obj);
        }

        // POST: MedicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medico medico)
        {
            if (ModelState.IsValid)
            {
                if (id != medico.Id)
                {
                    return BadRequest();
                }
                try
                {
                    await _medicoService.UpdateAsync(medico);
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
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidade, "Id", "NomeEspecialidade", medico.EspecialidadeId);
            return View(medico);
        }

        // GET: MedicoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _medicoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: MedicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _medicoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
