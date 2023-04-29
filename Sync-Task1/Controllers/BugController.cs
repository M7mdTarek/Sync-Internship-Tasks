using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sync_Task1.Models;
using Sync_Task1.Models.Repositories;
using Sync_Task1.ViewsModels;

namespace Sync_Task1.Controllers
{
    public class BugController : Controller
    {
        ITask1Repo<Bug> bugrepo;

        ITask1Repo<Developer> developerRepo;

        ITask1Repo<Solution> solutionRepo;

        BugDeveloperViewModel viewmodel = new BugDeveloperViewModel();

        
        public BugController(ITask1Repo<Bug> bugrepo, ITask1Repo<Developer> developerRepo, ITask1Repo<Solution> solutionRepo)
        {
            this.bugrepo = bugrepo;
            this.developerRepo = developerRepo;
            this.solutionRepo = solutionRepo;
        }
        // GET: BugController
        public ActionResult Index()
        {
            var bug = bugrepo.list();
            return View(bug);
        }

        // GET: BugController/Details/5
        public ActionResult Details(int id)
        {
            var bug = bugrepo.find(id);
            return View(bug);
        }

        // GET: BugController/Create
        public ActionResult Create()
        {
            
            return View(getAllDetails());
        }

        // POST: BugController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BugDeveloperViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //check if user didn't choose from drop list
                    if (model.developerID == -1 || model.solutionID == -1)
                    {
                        ViewBag.message = "Please enter the valid developer & solution";
                        return View(getAllDetails());
                    }
                    var bug = new Bug()
                    {
                        description = model.description,
                        priority = model.priority,
                        state = model.state,
                        title = model.title,
                        solution = solutionRepo.find(model.solutionID),
                        developer = developerRepo.find(model.developerID),

                    };
                    bugrepo.add(bug);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "you must fill all required data");
            return View(getAllDetails());
        }

        // GET: BugController/Edit/5
        public ActionResult Edit(int id)
        {
            var bug = bugrepo.find(id);
            BugDeveloperViewModel model = new BugDeveloperViewModel()
            {
                id = bug.id,
                title = bug.title,
                state = bug.state,
                description = bug.description,
                priority = bug.priority,
                solutionID = bug.solution == null ? -1 : bug.solution.id,
                solutions = solutionRepo.list(),
                developerID = bug.developer == null ? -1 : bug.developer.id,
                developers = developerRepo.list(),
            };
            return View(model);
        }

        // POST: BugController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BugDeveloperViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Bug bug = new Bug()
                    {
                        id = model.id,
                        description = model.description,
                        priority = model.priority,
                        state = model.state,
                        title = model.title,
                        developer = developerRepo.find(model.developerID),
                        solution = solutionRepo.find(model.solutionID),
                    };
                    bugrepo.update(bug);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            //if model not valid act like (get) edit 
            var vbug = bugrepo.find(model.id);
            BugDeveloperViewModel vmodel = new BugDeveloperViewModel()
            {
                id = vbug.id,
                title = vbug.title,
                state = vbug.state,
                description = vbug.description,
                priority = vbug.priority,
                solutionID = vbug.solution == null ? -1 : vbug.solution.id,
                solutions = solutionRepo.list(),
                developerID = vbug.developer == null ? -1 : vbug.developer.id,
                developers = developerRepo.list(),
            };
            return View(vmodel);
        }

        // GET: BugController/Delete/5
        public ActionResult Delete(int id)
        {
            var bug = bugrepo.find(id);
            return View(bug);
        }

        // POST: BugController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Bug bug)
        {
            try
            {
                bugrepo.delete(bug.id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string term)
        {
            var results = bugrepo.search(term);
            return View(results);
        }

        public BugDeveloperViewModel getAllDetails()
        {
            viewmodel.developers = developerRepo.list();
            viewmodel.developers.Insert(0, new Developer { id = -1, Name = "--- assign an developer ---" });
            viewmodel.solutions = solutionRepo.list();
            viewmodel.solutions.Insert(0, new Solution { id = -1, Title = "--- choose an soution ---" });
            return viewmodel;
        }
    }
}
