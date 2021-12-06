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
    public class ConvenioController : Controller
    {
        private readonly ConvenioService _convenioService;

        public ConvenioController(ConvenioService convenioService)
        {
            _convenioService = convenioService;
        }
        // GET: ConvenioController
        public ActionResult Index()
        {
            var list = _convenioService.FindAll();
            return View(list);
        }

        // GET: ConvenioController/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var obj = _convenioService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // GET: ConvenioController/Create
        public ActionResult Create()
        {
            return View(nameof(Create));
        }

        // POST: ConvenioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Convenio convenio)
        {
            try
            {
                _convenioService.Insert(convenio);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConvenioController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _convenioService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ConvenioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Convenio convenio)
        {
            if(id != convenio.Id)
            {
                return BadRequest();
            }            
            try
            {
                _convenioService.Update(convenio);
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

        // GET: ConvenioController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _convenioService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ConvenioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _convenioService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
