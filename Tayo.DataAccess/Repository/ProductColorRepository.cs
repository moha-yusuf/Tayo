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
    public class ProductColorRepository : Repository<ProductColor>, IProductColorRepository
    {
        private ApplicationDbContext _db;
        public ProductColorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductColor obj)
        {
            _db.ProductColors.Update(obj);
        }
    }
}
