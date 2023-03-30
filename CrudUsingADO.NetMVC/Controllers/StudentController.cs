using CrudUsingADO.NetMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingADO.NetMVC.Controllers
{
    public class StudentController : Controller
    {
        StudentCRUD crud;
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new StudentCRUD(configuration);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var list = crud.GetallStudents();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var stu = crud.GetStudentbyId(id);
            return View(stu);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stu)
        {
            try
            {
                int result = crud.AddStudent(stu);
                if (result == 1)

                    return RedirectToAction(nameof(Index));
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var stu = crud.GetStudentbyId(id);
            return View(stu);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stu)
        {
            try
            {
                int result = crud.UpdateStudent(stu);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var stu = crud.GetStudentbyId(id);
            return View(stu);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteStudent(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
