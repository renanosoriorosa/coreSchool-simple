using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using coreSchool_simple.Models;
using coreSchoolSimple.Models;
using coreSchoolSimple.Services;
using coreSchoolSimple.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreSchoolSimple.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ProfessorService _contextProfessor;

        public ProfessorController(ProfessorService contextProfessor)
        {
            _contextProfessor = contextProfessor;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _contextProfessor.FindAllAsync();
            return View(lista);
        }

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone")] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return View(professor);
            }

            await _contextProfessor.InsertAsync(professor);
            return RedirectToAction(nameof(Index));
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _contextProfessor.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //GET - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _contextProfessor.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST - edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return View(professor);// verificar
            }

            if (id != professor.Id)
            {
                return NotFound();
            }

            try
            {
                await _contextProfessor.UpdateAsync(professor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET - Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _contextProfessor.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _contextProfessor.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // nao precisa ser assincrona
        //FUTURO
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}