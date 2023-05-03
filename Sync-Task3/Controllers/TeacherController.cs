using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sync_Task3.Models;
using Sync_Task3.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sync_Task3.Controllers
{
    public class TeacherController : Controller
    {
        ITaskRepo<Teacher> teacherRepo;
        private readonly ITaskRepo<Course> courseRepo;
        private readonly ITaskRepo<Student> studentRepo;

        public TeacherController(ITaskRepo<Teacher> teacherRepo , ITaskRepo<Course> courseRepo, ITaskRepo<Student> studentRepo)
        {
            this.teacherRepo = teacherRepo;
            this.courseRepo = courseRepo;
            this.studentRepo = studentRepo;
        }
        // GET: TeacherController
        public ActionResult Index()
        {
            var list = teacherRepo.list();
            return View(list);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            var teacher = teacherRepo.find(id);
            return View(teacher);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                teacherRepo.add(teacher);
                return RedirectToAction("Index","Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = teacherRepo.find(id);
            return View(teacher);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            try
            {
                teacherRepo.update(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            var teacher = teacherRepo.find(id);
            return View(teacher);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Teacher teacher)
        {
            try
            {
                teacherRepo.delete(teacher.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Control()
        {

            return View(courseRepo.list());
        }
        public ActionResult TakeAttend(int id)
        {
            var course = courseRepo.find(id);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeAttend(Course course)
        {
            
            //List<Student> attendstudents = new List<Student>();
            
            for (int i = 0; i < course.Students.Count; i++)
            {
                if (course.Students[i].Attendance == 0)
                {
                    course.Students[i].NumofAbsence += 1;
                }
                
            }
            return View("DisplayGoodStudent", course.Students);
            
        }
    }
}
