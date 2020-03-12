using StudyDepartment.BusClient.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyDepartment.BusClient.Model
{
    class Subscription
    {
        public string address;
        public string entityName;
        public string type;

        public Subscription(string address, string entityName, Subscriptions subscription)
        {
            this.address = address;
            this.entityName = entityName;
            this.type = $"{subscription}";
        }
    }
}
