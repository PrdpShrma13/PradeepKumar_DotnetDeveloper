using Pradeep_DotnetDeveloper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pradeep_DotnetDeveloper.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public ICollection<StudentMark> StudentMarks { get; set; }
        public ICollection<SubjectViewModel>subjects  { get; set; }
    }
}