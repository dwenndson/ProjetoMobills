using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoMobills.Data.Respository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> List();
        Task<T> GeyById(int id);
        Task<int> Add(T t);
        Task<int> Update(T t);
        void Delete(int id);
    }
}
