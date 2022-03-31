using Pradeep_DotnetDeveloper.Data.Context;
using Pradeep_DotnetDeveloper.Data.Models;
using Pradeep_DotnetDeveloper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pradeep_DotnetDeveloper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult GetStudents(string filterBy = "FirstName")
        {
            IEnumerable<SubjectViewModel> subjects = _dbContext.Subjects.Select(x => new SubjectViewModel()
            {
                Id = x.Id,
                SubjectName = x.SubjectName
            }).ToList();

            // add subjects if not exist in table for testing purpose
            if (!subjects.Any())
                subjects = addSubjects();

            IEnumerable<StudentViewModel> students = _dbContext.Students.Select(x => new StudentViewModel()
            {
                Id = x.Id,
                Class = x.Class,
                FirstName = x.FirstName,
                LastName = x.LastName,
                StudentMarks = x.StudentMarks
            }).OrderBy(x => filterBy).ToList();

            StudentListViewModel studentList = new StudentListViewModel();
            studentList.Students = students;
            studentList.Subjects = subjects;
            return View(studentList);
        }

        [HttpGet]
        public ActionResult GetStudent(int id)
        {
            try
            {
                IEnumerable<StudentViewModel> students = _dbContext.Students.Where(x=>x.Id == id).Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Class = x.Class,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    StudentMarks = x.StudentMarks
                }).ToList();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult PostStudent(StudentViewModel model)
        {
            try
            {
                Student student = new Student();
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.Class = model.Class;
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                StudentMark studentMark = new StudentMark();
                if (model.StudentMarks != null)
                {
                    foreach (var item in model.StudentMarks)
                    {
                        studentMark.StudentId = student.Id;
                        studentMark.Marks = item.Marks;
                        studentMark.SubjectId = item.SubjectId;
                        _dbContext.StudentMark.Add(studentMark);
                        _dbContext.SaveChanges();
                    }
                }
                return RedirectToAction("GetStudents");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult PutStudent(StudentViewModel model)
        {
            try
            {
                Student student = _dbContext.Students.Where(x => x.Id == model.Id).FirstOrDefault();
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.Class = model.Class;
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                List<StudentMark> studentMark = _dbContext.StudentMark.Where(x => x.SubjectId == model.Id).ToList();
                foreach (var item in model.StudentMarks)
                {
                    var marks = studentMark.Where(x => x.SubjectId == item.SubjectId).FirstOrDefault();
                    if (marks != null)
                    {
                        marks.Marks = item.Marks;
                    }
                }
                _dbContext.SaveChanges();
                return RedirectToAction("GetStudents");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private List<SubjectViewModel> addSubjects()
        {
            Subject subject = new Subject();
            subject.SubjectName = ("Math");
            _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();
            subject.SubjectName = ("Chemistry");
            _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();
            subject.SubjectName = ("Physics");
            _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();
            return _dbContext.Subjects.Select(x => new SubjectViewModel()
            {
                Id = x.Id,
                SubjectName = x.SubjectName
            }).ToList();
        }
    }
}