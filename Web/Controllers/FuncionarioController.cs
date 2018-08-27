using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Models;

namespace Web.Controllers
{
    public class FuncionarioController : Controller
    {
        public static List<Funcionario> Funcionarios { get; }

        static FuncionarioController()
        {
            Funcionarios = new List<Funcionario>();

            Funcionarios.Add(new Funcionario()
            {
                Id = 1,
                ChefeImediato = FuncionarioController.Funcionarios.Find(f => f.Id == 2),
                Cargo = CargoController.Cargos.Find(c => c.Id == 1),
                Nome = "Thiago",
                Cpf = "1315642",
                Rg = "161646146",
                Matricula = "2414253",
                Salario = 1500.0,
                IsAtivo = true,
                Sexo = 'M',
                Unidade = UnidadeController.Unidades.Find(u => u.Id == 1)
            });

            Funcionarios.Add(new Funcionario()
            {
                Id = 2,
                ChefeImediato = FuncionarioController.Funcionarios.Find(f => f.Id == 1),
                Cargo = CargoController.Cargos.Find(c => c.Id == 3),
                Nome = "Weslley",
                Cpf = "1315642",
                Rg = "161646146",
                Matricula = "2414253",
                Salario = 1500.0,
                IsAtivo = true,
                Sexo = 'M',
                Unidade = UnidadeController.Unidades.Find(u => u.Id == 2)
            });
        }
        // GET: Funcionario
        public ActionResult Index()
        {
            var model = Funcionarios;
            if (model.Count == 0)
                model = null;
            return View(model);
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            ViewBag.Cargos = new SelectList(CargoController.Cargos, "Id", "Nome");
            ViewBag.Unidades = new SelectList(UnidadeController.Unidades, "Id", "Nome");
        
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid && funcionario.IdUnidade != -1 && funcionario.IdCargo != -1)
            {
                funcionario.Unidade = UnidadeController.Unidades.Find(u => u.Id == funcionario.Unidade.Id);
                funcionario.Cargo = CargoController.Cargos.Find(u => u.Id == funcionario.Cargo.Id);
                Funcionarios.Add(funcionario);
                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var model = Funcionarios.FirstOrDefault(f => f.Id == id);
                if (model != null)
                {
                    ViewBag.Cargos = new SelectList(CargoController.Cargos, "Id", "Nome", model.Cargo);
                    ViewBag.Unidades = new SelectList(UnidadeController.Unidades, "Id", "Nome", model.Unidade);
                    return View(model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Funcionario funcionario)
        {
            if (ModelState.IsValid && funcionario.IdCargo != -1 && funcionario.IdUnidade != -1)
            {
                funcionario.Unidade = UnidadeController.Unidades.Find(u => u.Id == funcionario.Unidade.Id);
                funcionario.Cargo = CargoController.Cargos.Find(c => c.Id == funcionario.IdCargo);
                int idx = Funcionarios.FindIndex(f => f.Id == funcionario.Id);
                Funcionarios[idx] = funcionario;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Cargos = new SelectList(CargoController.Cargos, "Id", "Nome", funcionario.Cargo);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id.HasValue)
            {
                var model = Funcionarios.FirstOrDefault(f => f.Id == id);
                if (model != null)
                    return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Funcionario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var existe = Funcionarios.Exists(f => f.Id == id);
            if (existe)
                Funcionarios.RemoveAll(f => f.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}