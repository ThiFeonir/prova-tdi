using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Models;

namespace Web.Controllers
{
    public class CargoController : Controller
    {
        public static List<Cargo> Cargos { get; }

        static CargoController()
        {
            Cargos = new List<Cargo>()
            {
                new Cargo() {Id = 1, Descricao = "Cargo 1" },
                new Cargo() {Id = 2, Descricao = "Cargo 2" },
                new Cargo() {Id = 3, Descricao = "Cargo 3" },
                new Cargo() {Id = 4, Descricao = "Cargo 4" },
            };
        }
        // GET: Cargo
        public ActionResult Index()
        {
            var model = Cargos;
            if (model.Count == 0)
                model = null;
            return View(model);
        }

        // GET: Cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cargo.Id = Cargos.Count + 1;
                Cargos.Add(cargo);
                return RedirectToAction(nameof(Index));
            }

           return View(cargo);  
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var model = Cargos.FirstOrDefault(m => m.Id == id);
                if (model != null)
                {
                    return View(model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Cargo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                int idx = Cargos.FindIndex(m => m.Id == cargo.Id);
                Cargos[idx] = cargo;
                return RedirectToAction(nameof(Index));
            }
            return View(cargo);
        }

        // GET: Cargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var model = Cargos.FirstOrDefault(c => c.Id == id);
                if (model != null)
                    return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Cargo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var existe = Cargos.Exists(c => c.Id == id);
            if (existe)
                Cargos.RemoveAll(m => m.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}