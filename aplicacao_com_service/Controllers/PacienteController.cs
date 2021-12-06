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
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;
        private readonly ConvenioService _convenioService;
        private readonly ProcedimentoService _procedimentoService;
        private readonly aplicacao_com_serviceContext _context;

        public PacienteController(PacienteService pacienteService, ConvenioService convenioService, ProcedimentoService procedimentoService, aplicacao_com_serviceContext context)
        {
            _pacienteService = pacienteService;
            _convenioService = convenioService;
            _procedimentoService = procedimentoService;
            _context = context;
        }
        // GET: PacienteController
        public async Task<IActionResult> Index()
        {
            var list = await _pacienteService.FindAllAsync();
            return View(list);
        }

        // GET: PacienteController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                NotFound();
            }
            var obj = await _pacienteService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                NotFound();
            }
            return View(obj);
        }

        // GET: PacienteController/Create
        public IActionResult Create()
        {
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "NomeEmpresa");
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "Id", "NomeProcedimento");           
            return View(nameof(Create));
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _pacienteService.InsertAsync(paciente);
                    return Redirect("~/Paciente");
                }
                catch (NotFoundException)
                {
                    return BadRequest();
                }
            }
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Id", paciente.ConvenioId);
            ViewData["ProcidementoId"] = new SelectList(_context.Procedimento, "Id", "Id", paciente.ProcedimentoId);
            return View(paciente);

        }

        // GET: PacienteController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj =await _pacienteService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "NomeEmpresa", obj.ConvenioId);
            ViewData["ProcidementoId"] = new SelectList(_context.Procedimento, "Id", "NomeProcedimento", obj.ProcedimentoId);
            return View(obj);

        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                if (id != paciente.Id)
                {
                    return BadRequest();
                }
                try
                {
                    await _pacienteService.UpdateAsync(paciente);
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
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "NomeEmpresa", paciente.ConvenioId);
            ViewData["ProcidementoId"] = new SelectList(_context.Procedimento, "Id", "NomeProcedimento", paciente.ProcedimentoId);
            return View(paciente);
        }

        // GET: PacienteController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _pacienteService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pacienteService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
