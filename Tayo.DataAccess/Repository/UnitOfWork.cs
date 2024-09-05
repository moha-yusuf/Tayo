using Tayo.DataAccess.Data;
using Tayo.DataAccess.Repository.IRepository;
using TayoBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayo.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public ICollectionRepository Collection { get; private set; }
        public IProductSizeRepository ProductSize { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Collection = new CollectionRepository(_db);
            ProductSize = new ProductSizeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
