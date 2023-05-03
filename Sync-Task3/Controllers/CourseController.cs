using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Sync_Task3.Models;
using Sync_Task3.Models.Repository;
using Sync_Task3.ViewsModels;
using System.Collections.Generic;
using System.Linq;

namespace Sync_Task3.Controllers
{
    public class CourseController : Controller
    {
        private readonly ITaskRepo<Course> courseRepo;
        private readonly ITaskRepo<Teacher> teacherRepo;
        private readonly ITaskRepo<Student> studentRepo;
        CourseTeacherViewModel teacherviewmodel = new CourseTeacherViewModel();
        CourseStudentViewModel studentViewModel = new CourseStudentViewModel();

        public CourseController(ITaskRepo<Course> courseRepo , ITaskRepo<Teacher> teacherRepo, ITaskRepo<Student> studentRepo)
        {
            this.courseRepo = courseRepo;
            this.teacherRepo = teacherRepo;
            this.studentRepo = studentRepo;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var list = courseRepo.list();
            return View(list);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = courseRepo.find(id);
            return View(course);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View(getAllTeachers());
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseTeacherViewModel model)
        {
            try
            {
                //check if user didn't choose from drop list
                if (model.TeacherId == -1 )
                {
                    ViewBag.message = "Please enter the valid Teacher";
                    return View(getAllTeachers());
                }

                Course course = new Course()
                {
                    Name = model.Name,
                    Teacher = teacherRepo.find(model.TeacherId)
                };
                courseRepo.add(course);
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = courseRepo.find(id);
            CourseTeacherViewModel model = new CourseTeacherViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                TeacherId = course.Teacher == null ? -1 : course.Teacher.Id,
                Teachers = teacherRepo.list()
            };
            return View(model);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseTeacherViewModel model)
        {
            try
            {
                Course course = new Course()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Teacher = teacherRepo.find(model.TeacherId)
                };
                courseRepo.update(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var course = courseRepo.find(id);
            return View(course);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Course course)
        {
            try
            {
                courseRepo.delete(course.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Addstudent()
        {
            return View(getAllCourses_Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addstudent(CourseStudentViewModel model)
        {
            try
            {
                if (model.CoursesId == -1 || model.StudentId ==-1)
                {
                    ViewBag.message = "Please enter a course and student";
                    return View(getAllCourses_Student());
                }

                var course = courseRepo.find(model.CoursesId);
                var student = studentRepo.find(model.StudentId);

                if (checkDuplicateStudent(course , student))
                {
                    ViewBag.warning = "this student has already enrolled in this course";
                    return View(getAllCourses_Student());
                }
                else
                {
                    course.Students.Add(student);
                }
                

                course.Size = course.Students.Count();
                return RedirectToAction("Control","Teacher");
            }
            catch
            {
                return View();
            }
        }


        public CourseTeacherViewModel getAllTeachers()
        {
            teacherviewmodel.Teachers = teacherRepo.list();
            teacherviewmodel.Teachers.Insert(0, new Teacher { Id = -1, Name = "--- assign an teacher ---" });
            return teacherviewmodel;
        }
        public CourseStudentViewModel getAllCourses_Student()
        {
            studentViewModel.AllCourses = courseRepo.list();
            studentViewModel.AllCourses.Insert(0, new Course { Id = -1, Name = "--- Choose a course ---" });
            studentViewModel.AllStudents = studentRepo.list();
            studentViewModel.AllStudents.Insert(0, new Student { Id = -1, Name = "--- Add a student ---" });
            return studentViewModel;
        }
        public bool checkDuplicateStudent(Course c , Student s)
        {
            if (c.Students.Contains(s)) return true;
            else return false;
        }
        
    }
}
