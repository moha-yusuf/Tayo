using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayo.DataAccess.Data;
using Tayo.DataAccess.Repository.IRepository;
using Tayo.Models;

namespace Tayo.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            //_db.Products.Update(obj);

            // Manually update each field.
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.IsAvailable = obj.IsAvailable;
                objFromDb.DisplayOrder = obj.DisplayOrder;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.CollectionId = obj.CollectionId;
                objFromDb.ProductColorId = obj.ProductColorId;
                objFromDb.ProductSizeId = obj.ProductSizeId;
                objFromDb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}
