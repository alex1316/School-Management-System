using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Models.Domain;
using SchoolManagementSystem.Repositories.Abstract;
using System.Data;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(Roles = "proffessor,user")]

    public class GradesController : Controller
    {
        private readonly IGradeService gradeService;
        private readonly IStudentService studentService;//εδω δανειστικες μεταβλητες
       
        private readonly ISubjectService subjectService;
        public GradesController(IGradeService gradeService,  ISubjectService subjectService, IStudentService studentService)
        {
            this.gradeService = gradeService;
            
            this.subjectService = subjectService;
            this.studentService = studentService;
        }
        public IActionResult Add()
        {
            var model = new GradeProf();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString() }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString() }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString() }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString() }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString() }).ToList();



            return View(model);
        }

        [HttpPost]
        public IActionResult Add(GradeProf model)
        {
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId}).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = gradeService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var model = gradeService.FindById(id);
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(GradeProf model)
        {
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = gradeService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Delete(int id)
        {

            var result = gradeService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = gradeService.GetAll();
            return View(data);
        }
        public IActionResult GetAll2()
        {

            var data = gradeService.GetAll2();
            return View(data);
        }
    }
}
