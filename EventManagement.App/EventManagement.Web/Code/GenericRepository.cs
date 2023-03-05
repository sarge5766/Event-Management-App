using EventManagement.Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace EventManagement.Web {
    public abstract class GenericRepository<T> : IRepository<T> where T : class {
       public string _baseUrl = @"https://localhost:44331/";

        public virtual void Add(T entity) { }

        public virtual void Delete(int id,string serviceUrl) {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Delete);
            request.RequestFormat = DataFormat.Json;
            client.Execute(request);
        }

        public virtual IEnumerable<T> GetAll(string serviceUrl) {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<T>>(response.Content);
        }

        public virtual T GetById(int id, string serviceUrl) {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public virtual void Update(T entity) {
            throw new NotImplementedException();
        }
    }
}