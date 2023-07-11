using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Models.Domain;
using SchoolManagementSystem.Repositories.Abstract;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class GradesUserController : Controller
    {
        private readonly IGradeUserService gradeuService;
        private readonly IStudentService studentService;//εδω δανειστικες μεταβλητες
        private readonly IGradeService gradeService;
        private readonly ISubjectService subjectService;
        public GradesUserController(IGradeUserService gradeuService, IGradeService gradeService, ISubjectService subjectService, IStudentService studentService)
        {
            this.gradeuService = gradeuService;
            this.gradeService = gradeService;
            this.subjectService = subjectService;
            this.studentService = studentService;
            
        }
        public IActionResult Add()
        {
            var model = new GradeUser();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString() }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString() }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfFrstname, Value = a.Id.ToString() }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfLastName, Value = a.Id.ToString() }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.GradesProf, Value = a.Id.ToString() }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString() }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString() }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString() }).ToList();



            return View(model);
        }

        [HttpPost]
        public IActionResult Add(GradeUser model)
        {
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfFrstname, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfLastName, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.GradesProf, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = gradeuService.Add(model);
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
            var model = gradeuService.FindById(id);
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfFrstname, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfLastName, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.GradesProf, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(GradeUser model)
        {
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentName, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.StudentList = studentService.GetAll().Select(a => new SelectListItem { Text = a.StudentAM, Value = a.Id.ToString(), Selected = a.Id == model.StudentId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfFrstname, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.ProfLastName, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();
            model.GradeList = gradeService.GetAll().Select(a => new SelectListItem { Text = a.GradesProf, Value = a.Id.ToString(), Selected = a.Id == model.GradesId }).ToList();

            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectName, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectYear, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();
            model.SubjectList = subjectService.GetAll().Select(a => new SelectListItem { Text = a.SubjectSemester, Value = a.Id.ToString(), Selected = a.Id == model.SubjectId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = gradeuService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Delete(int id)
        {

            var result = gradeuService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = gradeuService.GetAll();
            return View(data);
        }
    }
}
