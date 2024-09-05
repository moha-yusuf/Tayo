using Tayo.DataAccess.Data;
using Tayo.DataAccess.Repository.IRepository;
using Tayo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayo.DataAccess.Repository
{
    public class CollectionRepository : Repository<Collection>, ICollectionRepository
    {
        private ApplicationDbContext _db;
        public CollectionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Collection obj)
        {
            _db.Collections.Update(obj);
        }
    }
}
