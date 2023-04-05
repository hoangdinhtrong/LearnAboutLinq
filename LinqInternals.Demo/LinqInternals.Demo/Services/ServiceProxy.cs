using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInternals.Demo.Services
{
    public class ServiceProxy: IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed;
        public ServiceProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        ~ServiceProxy()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_disposed)
            {
                return;
            }

            if(disposing)
            {
                // Dispose managed objects
                _httpClient.Dispose();
            }

            // Dispose unmanaged objects
            _disposed = true;
        }

        public void Get()
        {
            var response = _httpClient.GetAsync("");
        }

        public void Post(string request)
        {
            var response = _httpClient.PostAsync("", new StringContent(request));
        }
    }
}
