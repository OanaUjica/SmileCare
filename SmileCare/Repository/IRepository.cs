using SmileCare.Domain;
using System.Collections.Generic;

namespace SmileCare.Repository
{
    public interface IRepository<T> /*where T : Entity*/
    {
        void Create(T entity);
        List<T> ReadAll();
        T ReadById(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
