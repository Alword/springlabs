using StudyDepartment.BusClient.Model;
using System;
using System.Threading.Tasks;

namespace StudyDepartment.BusClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Run();
        }

        static void Run() 
        {
            Bus bus = new Bus("test", new Uri("http://up-lab1.mirea.ru"));
            var task = bus.Get("?to=dean&after=0");
            Task.WaitAll(task);
            //var task1 = bus.UpdateSubscription();
        }
    }
}
