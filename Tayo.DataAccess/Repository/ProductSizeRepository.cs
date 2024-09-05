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
    public class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
    {
        private ApplicationDbContext _db;
        public ProductSizeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(ProductSize size)
        {
            _db.ProductSizes.Update(size);
        }
    }
}
