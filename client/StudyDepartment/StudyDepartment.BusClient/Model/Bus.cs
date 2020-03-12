using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyDepartment.BusClient.Enum;

namespace StudyDepartment.BusClient.Model
{
    public class Bus : IDisposable
    {
        bool disposed = false;
        private HttpClient httpClient;
        public string Instanse { get; private set; }
        public Uri Uri { get; private set; }
        public Bus(string instanse, Uri uri)
        {
            this.Uri = uri;
            this.Instanse = instanse;
            httpClient = new HttpClient();
        }

        public async Task ConnectAsync()
        {
            Uri address = new Uri(Uri, "bus");
            var message = new Message<string>(Instanse, "dean", Subjects.INIT_INSTANCE, null);
            string myJson = JsonConvert.SerializeObject(message);
            var response = await httpClient.PostAsync(address, new StringContent(myJson, Encoding.UTF8, "application/json"));
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

        public async Task UpdateSubscription()
        {
            Uri address = new Uri(Uri, "bus");
            var message = new Message<Subscription>(Instanse, "dean", Subjects.UPDATE_SUBSCRIPTION, new Subscription("alword", "student", Subscriptions.COMMON));
            string myJson = JsonConvert.SerializeObject(message);
            var response = await httpClient.PostAsync(address, new StringContent(myJson, Encoding.UTF8, "application/json"));
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

        public async Task RemoveInstance()
        {
            Uri address = new Uri(Uri, "bus");
            var message = new Message<string>(Instanse, "dean", Subjects.REMOVE_ROW,"mark");
            string myJson = JsonConvert.SerializeObject(message);
            var response = await httpClient.PostAsync(address, new StringContent(myJson, Encoding.UTF8, "application/json"));
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        public async Task Get(string requests)
        {
            Uri address = new Uri(Uri, $"bus{requests}");
            var response = await httpClient.GetAsync(address);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            httpClient.Dispose();
            disposed = true;
        }

        ~Bus()
        {
            Dispose(false);
        }
    }
}
