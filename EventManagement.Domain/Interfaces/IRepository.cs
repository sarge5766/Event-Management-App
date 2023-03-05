using System.Collections.Generic;

namespace EventManagement.Domain {
    public interface IRepository<T> where T : class {
        void Add(T entity);

        void Delete(int id, string serviceUrl);

        IEnumerable<T> GetAll(string serviceUrl);

        T GetById(int id, string serviceUrl);

        void Update(T entity);
    }
}
