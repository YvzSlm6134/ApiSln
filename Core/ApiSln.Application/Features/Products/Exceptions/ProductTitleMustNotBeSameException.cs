﻿using ApiSln.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseException
    {
        public ProductTitleMustNotBeSameException() : base("Ürün Başlığı Zaten Var!") { }
    }
}
