using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pradeep_DotnetDeveloper.Models
{
    public class StudentInputViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public List<StudentMarks> StudentMarks { get; set; }

    }
    public class StudentMarks
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int Marks { get; set; }
    }
}