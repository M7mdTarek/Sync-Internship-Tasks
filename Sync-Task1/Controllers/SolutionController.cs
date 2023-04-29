using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sync_Task1.Models;
using Sync_Task1.Models.Repositories;
using System;

namespace Sync_Task1.Controllers
{
    public class SolutionController : Controller
    {
        ITask1Repo<Solution> SolutionRepo;

        public SolutionController(ITask1Repo<Solution> SolutionRepo)
        {
            this.SolutionRepo = SolutionRepo;
        }
        // GET: SolutionController
        public ActionResult Index()
        {
            var solution = SolutionRepo.list();
            return View(solution);
        }

        // GET: SolutionController/Details/5
        public ActionResult Details(int id)
        {
            var solution = SolutionRepo.find(id);
            return View(solution);
        }

        // GET: SolutionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolutionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Solution solution )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SolutionRepo.add(solution);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "you must fill all the required data");
            return View();
        }

        // GET: SolutionController/Edit/5
        public ActionResult Edit(int id)
        {
            var solution = SolutionRepo.find(id);
            return View(solution);
        }

        // POST: SolutionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Solution solution)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SolutionRepo.update(solution);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            var sol = SolutionRepo.find(solution.id);
            return View(solution);
        }

        // GET: SolutionController/Delete/5
        public ActionResult Delete(int id)
        {
            var solution = SolutionRepo.find(id);
            return View(solution);
        }

        // POST: SolutionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Solution solution)
        {
            try
            {
                SolutionRepo.delete(solution.id);
                return RedirectToAction(nameof(Index));
            }
            catch(DbUpdateException ex)
            {
                ViewBag.warning = "you can't delete solution when it used in bug";
                var sol = SolutionRepo.find(solution.id);
                return View(sol);
            }
            catch
            {
                return View();
            }
        }
    }
}
