namespace StudyDepartment.Web.Model
{
    public class JurnalRecord
    {
        public int Id { get; set; }

        public int Student_Id { get; set; }

        //public int Study_Plan_Id { get; set; }

        //public bool In_Time { get; set; }

        public int Count { get; set; } // количество пересдач

        //public int Mark_Id { get; set; }

        public string Student_Full_Name { get; set; } // 123 123 123

        // public string Subject_Name { get; set; } // Проектирование сисием

        public string Subject_Short_Name { get; set; } // ПрИс

        public string Exam_Type { get; set; } // Экзамен

        public string Mark_Name { get; set; } // Отлично

        public string Mark_Value { get; set; } // "5"

    }
}
