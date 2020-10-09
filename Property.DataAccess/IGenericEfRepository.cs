using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.DataAccess
{
    public interface IGenericEfRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get();
        bool Save();
        void Add(TEntity item);
    }
}
