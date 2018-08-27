using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Web.Controllers
{
    public class UnidadeController : Controller
    {
        public static List<Unidade> Unidades { get; }

        static UnidadeController()
        {
            Unidades = new List<Unidade>();
          
        }

        // GET: Unidade
        public ActionResult Index()
        {
            return View(Unidades);
        }

        // GET: Unidade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Unidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Unidade unidade)
        {
           if(ModelState.IsValid)
            {
                unidade.Id = Unidades.Count + 1;
                unidade.Funcionarios = new List<Model.Funcionario>();
                Unidades.Add(unidade);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Unidade/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Unidades.Find(u => u.Id == id));
        }

        // POST: Unidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Unidade unidade)
        {

            if (ModelState.IsValid)
            {
                Unidades.Insert(id, unidade);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Unidade/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Unidades.Find(u => u.Id == id));
        }

        // POST: Unidade/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if(ModelState.IsValid)
            {
                Unidades.RemoveAt(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}