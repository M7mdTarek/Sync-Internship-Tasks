using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sync_Task1.Models;
using Sync_Task1.Models.Repositories;
using System;
using System.IO;

namespace Sync_Task1.Controllers
{
    public class DeveloperController : Controller
    {
        ITask1Repo<Developer> developerRepo;
        IHostingEnvironment hosting;
        // GET: DeveloperController
        public DeveloperController(ITask1Repo<Developer> developerRepo , IHostingEnvironment hosting)
        {
            this.developerRepo = developerRepo;
            this.hosting = hosting;
        }
        public ActionResult Index()
        {
            var developers = developerRepo.list();
            return View(developers);
        }

        // GET: DeveloperController/Details/5
        public ActionResult Details(int id)
        {
            var developer = developerRepo.find(id);
            return View(developer);
        }

        // GET: DeveloperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeveloperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Developer developer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (developer.file != null)
                    {
                        //to make evry file name unique
                        string name = developer.file.FileName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + Path.GetExtension(developer.file.FileName);

                        //save new file then release the resources
                        FileStream f;
                        developer.file.CopyTo(f = new FileStream(preppath(name), FileMode.Create));
                        f.Dispose();

                        developer.imgUrl = name;
                    }

                    developerRepo.add(developer);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "you must fill all required data");
            return View();
        }
       
        // GET: DeveloperController/Edit/5
        public ActionResult Edit(int id)
        {
            var developer = developerRepo.find(id);

            return View(developer);
        }

        // POST: DeveloperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Developer developer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (developer.file != null)
                    {
                        //to make evry file name unique
                        string name = developer.file.FileName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + Path.GetExtension(developer.file.FileName);

                        string newpath = preppath(name);
                        //imgUrl is old one
                        string oldpath = preppath(developer.imgUrl);
                        //delete the old file
                        System.IO.File.Delete(oldpath);

                        //save new file then release the resources
                        FileStream f;
                        developer.file.CopyTo(f = new FileStream(newpath, FileMode.Create));
                        f.Dispose();

                        //now imgUrl is new one
                        developer.imgUrl = name;

                    }
                    developerRepo.update(developer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View();
                }
            }

            var dev = developerRepo.find(developer.id);
            return View(dev);

        }

        // GET: DeveloperController/Delete/5
        public ActionResult Delete(int id)
        {
            var developer = developerRepo.find(id);
            return View(developer);
        }

        // POST: DeveloperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Developer developer)
        {
            try
            {
                string path = developerRepo.find(developer.id).imgUrl;
                path = preppath(path);
                
                developerRepo.delete(developer.id);

                //delete file only when delete the developer successfully 
                System.IO.File.Delete(path);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ViewBag.warning = "you can't delete developer when he work on bug";
                var dev = developerRepo.find(developer.id);
                return View(dev);
            }
            catch
            {
                return View();
            }
        }
        //handle the path
        string preppath(string name)
        {
            //handle the root path
            string uploads = Path.Combine(hosting.WebRootPath, "uploads");

            string fullpath = Path.Combine(uploads, name);

            return fullpath;
        }
    }
}
