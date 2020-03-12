using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyDepartment.Server.Model
{
    public class Jurnal
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int StudyPlanId { get; set; }
        public StudyPlan StudyPlan { get; set; }
        public int InTime { get; set; }
        public int Count { get; set; }
        public int MarkId { get; set; }
        public Mark Mark { get; set; }

    }
}
