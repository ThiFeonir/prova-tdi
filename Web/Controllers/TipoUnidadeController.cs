using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Web.Controllers
{
    public class TipoUnidadeController : Controller
    {
        public static List<TipoUnidade> TiposUnidades { get; }

        static TipoUnidadeController()
        {
            TiposUnidades = new List<TipoUnidade>()
            {
                new TipoUnidade() { Id = 0, Descricao = "Finanças" }
            };
        }

        // GET: Unidade
        public ActionResult Index()
        {
            return View(TiposUnidades);
        }

        // GET: Unidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoUnidade Tipo)
        {
            if (ModelState.IsValid)
            {
                Tipo.Id = TiposUnidades.Count + 1;
                TiposUnidades.Add(Tipo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Unidade/Edit/5
        public ActionResult Edit(int id)
        {
            return View(TiposUnidades.Find(u => u.Id == id));
        }

        // POST: Unidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoUnidade Tipo)
        {

            if (ModelState.IsValid)
            {
                int idx = TiposUnidades.FindIndex(m => m.Id == Tipo.Id);
                TiposUnidades[idx] = Tipo;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Unidade/Delete/5
        public ActionResult Delete(int id)
        {
            return View(TiposUnidades.Find(u => u.Id == id));
        }

        // POST: Unidade/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                TiposUnidades.RemoveAt(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }

}    
