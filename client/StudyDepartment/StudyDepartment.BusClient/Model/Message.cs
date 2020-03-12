using StudyDepartment.BusClient.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyDepartment.BusClient.Model
{
    public class Message<T>
    {
        public string from { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public T data { get; set; }

        public Message(string from, string to, Subjects subjects, T data)
        {
            this.from = from;
            this.to = to;
            this.subject = subjects.ToString();
            this.data = data;
        }
    }
}
