﻿using ApiSln.Application.Bases;
using ApiSln.Application.İnterface.UnitOfWorks;
using ApiSln.Application.İnterfaces.AutoMapper;
using ApiSln.Domain.Entitys;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Entities;

namespace ApiSln.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GettAsync(x => x.Id == request.Id && !x.İsDeleted);

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().GettAllAsync(x=>x.ProductId == product.Id);
            // product ıd im eğer 3 ise yada başka bir şey ona ait olan tüm category ıd leri alır.

            await unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds) 
            await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new() { CategoryId = categoryId , ProductId = product.Id});

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
 
        }
    }
}
