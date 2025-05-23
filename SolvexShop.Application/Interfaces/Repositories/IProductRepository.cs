﻿using SolvexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product, Guid>
    {
    }
}
