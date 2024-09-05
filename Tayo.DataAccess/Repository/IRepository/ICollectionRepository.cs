﻿using Tayo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayo.DataAccess.Repository.IRepository
{
    public interface ICollectionRepository : IRepository<Collection>
    {
        void Update(Collection obj);
    }
}
