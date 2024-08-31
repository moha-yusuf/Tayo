using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
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
