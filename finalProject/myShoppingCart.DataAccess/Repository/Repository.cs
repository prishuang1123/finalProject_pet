using Microsoft.EntityFrameworkCore;
using myShoppingCart.DataAccess.Data;
using myShoppingCart.DataAccess.Repository.IRepository;
using myShoppingCart.ViewModels;
using System.Linq.Expressions;

namespace myShoppingCart.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        private readonly CartContext _db;

        //public Repository(ApplicationDbContext db)
        //{
        //    _db = db;
        //    this.dbset=_db.Set<T>();
        //    //dbset==_db.categories
        //}

        public Repository(CartContext db)
        {
            _db = db;
            this.dbset=_db.Set<T>();
            //dbset==_db.categories
            _db.products.Include(u => u.Category);
        }

        public void Add(T entity)
        {
           dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
        //T IRepository<T>.GetAsync(Expression<Func<T, bool>> filter)
        //{
        //    IQueryable<T> query = dbset;
        //    query = query.Where(filter);
        //    return query.FirstOrDefaultAsync();
        //}

        //Category,CategoryId,
        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            IQueryable<T> query = dbset;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }

        
    }
}
