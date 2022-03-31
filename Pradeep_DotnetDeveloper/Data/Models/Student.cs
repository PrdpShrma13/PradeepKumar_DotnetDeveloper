using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pradeep_DotnetDeveloper.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public ICollection<StudentMark> StudentMarks { get; set; }
    }
}