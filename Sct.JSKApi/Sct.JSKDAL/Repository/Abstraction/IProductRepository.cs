﻿using Sct.JSKDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsByCategory(string category);
    }
}