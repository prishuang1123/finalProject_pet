using myShoppingCart.DataAccess.Repository.IRepository;
using myShoppingCart.Models;
using myShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShoppingCart.DataAccess.Repository
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly CartContext _db;
        public ProductRepository(CartContext db):base(db)
        {
            _db = db;
        }
    }
}
