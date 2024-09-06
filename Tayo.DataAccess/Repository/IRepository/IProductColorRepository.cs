using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayo.Models;

namespace Tayo.DataAccess.Repository.IRepository
{
    public interface IProductColorRepository : IRepository<ProductColor>
    {
        void Update(ProductColor obj);
    }
}
