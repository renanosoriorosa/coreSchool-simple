using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreSchoolSimple.Models;
using coreSchoolSimple.Models.ViewModels;
using coreSchoolSimple.Services;
using Microsoft.AspNetCore.Mvc;

namespace coreSchoolSimple.Controllers
{
    public class AlunosController : Controller
    {
        public readonly AlunosService _contextAluno;
        public readonly ProfessorService _contextProfessor;
        public readonly TurmasController _contextTurma;

        public AlunosController(AlunosService contextAluno)
        {
            _contextAluno = contextAluno;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _contextAluno.FindAllAsync();
            return View(lista);
        }

        //GET
        public async Task<IActionResult> Create()
        {
            var professores = await _contextProfessor.FindAllAsync();
            var turmas = await _contextTurma.FindAllAsync();
            var viewModel = new AlunoViewModel {
                Professores = professores,
                Turmas = turmas
            };
            return View(viewModel);
        }
    }
}