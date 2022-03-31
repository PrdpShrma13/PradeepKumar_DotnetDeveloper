using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pradeep_DotnetDeveloper.Models
{
    public class StudentListViewModel
    {
        public StudentViewModel Student { get; set; }
        public IEnumerable <StudentViewModel> Students { get; set; }
        public IEnumerable<SubjectViewModel> Subjects { get; set; }
    }
}