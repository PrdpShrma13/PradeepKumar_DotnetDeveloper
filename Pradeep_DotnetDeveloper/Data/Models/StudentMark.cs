using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pradeep_DotnetDeveloper.Data.Models
{
    public class StudentMark
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int Marks { get; set; }
        public Subject Subject { get; set; }

    }
}