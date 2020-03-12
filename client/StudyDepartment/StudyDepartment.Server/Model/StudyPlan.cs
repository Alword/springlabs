using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyDepartment.Server.Model
{
    public class StudyPlan
    {
        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ExamTypeId { get; set; }
        public ExamType ExamType { get; set; }
    }
}
