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
    public class ProcedimentoController : Controller
    {
        private readonly ProcedimentoService _procedimentoService;

        public ProcedimentoController(ProcedimentoService procedimentoService)
        {
            _procedimentoService = procedimentoService;
        }
        // GET: ProcedimentoController
        public async Task<IActionResult> Index()
        {
            var list = await _procedimentoService.FindAllAsync();
            return View(list);
        }

        // GET: ProcedimentoController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            var obj = await _procedimentoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                NotFound();
            }
            return View(obj);
        }

        // GET: ProcedimentoController/Create
        public ActionResult Create()
        {
            return View(nameof(Create));
        }

        // POST: ProcedimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Procedimento procedimento)
        {
            try
            {
                await _procedimentoService.InsertAsync(procedimento);
                return Redirect("~/Procedimento");
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

        // GET: ProcedimentoController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _procedimentoService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ProcedimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                if (id != procedimento.Id)
                {
                    return BadRequest();
                }
                try
                {
                    await _procedimentoService.UpdateAsync(procedimento);
                    return Redirect("~/Procedimento");
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
            return View(procedimento);            
        }

        // GET: ProcedimentoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _procedimentoService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ProcedimentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _procedimentoService.RemoveAsync(id);
                return Redirect(nameof(Index));
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
