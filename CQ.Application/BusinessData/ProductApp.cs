﻿using CQ.Domain.IRepository.BusinessData;
using CQ.Repository.BusinessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQ.Application.BusinessData
{
    public class ProductApp
    {
        private IProductRepository service = new ProductRepository();
    }
}
