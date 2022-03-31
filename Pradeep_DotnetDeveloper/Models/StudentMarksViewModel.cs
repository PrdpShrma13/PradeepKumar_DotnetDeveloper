using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pradeep_DotnetDeveloper.Models
{
    public class StudentMarksViewModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int Marks { get; set; }
        public SubjectViewModel Subject { get; set; }
    }
}