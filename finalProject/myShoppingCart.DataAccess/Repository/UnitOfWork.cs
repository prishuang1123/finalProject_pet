using myShoppingCart.DataAccess.Repository.IRepository;
using myShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShoppingCart.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CartContext _db;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(CartContext db)
        {
            _db = db;
            Category=new CategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
