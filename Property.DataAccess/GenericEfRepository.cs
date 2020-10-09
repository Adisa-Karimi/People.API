using People.DataAccess.DataContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.DataAccess
{
    public class GenericEfRepository<TEntity> : IGenericEfRepository<TEntity>
       where TEntity : class
    {
        private readonly MyDbContext _db;
        public GenericEfRepository(MyDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await Task.FromResult(_db.Set<TEntity>());
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public void Add(TEntity item)
        {
            _db.Add(item);
        }
    }
}
