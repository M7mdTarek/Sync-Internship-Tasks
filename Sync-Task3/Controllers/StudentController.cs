using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sync_Task3.Models;
using Sync_Task3.Models.Repository;

namespace Sync_Task3.Controllers
{
    public class StudentController : Controller
    {
        private readonly ITaskRepo<Student> studentRepo;

        public StudentController(ITaskRepo<Student> studentRepo)
        {
            this.studentRepo = studentRepo;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var list = studentRepo.list();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = studentRepo.find(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                studentRepo.add(student);
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = studentRepo.find(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                studentRepo.update(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = studentRepo.find(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
                studentRepo.delete(student.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
