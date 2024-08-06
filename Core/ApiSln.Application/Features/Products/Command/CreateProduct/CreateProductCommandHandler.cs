﻿using ApiSln.Application.İnterface.UnitOfWorks;
using ApiSln.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Entities;

namespace ApiSln.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId,

                    });

                    await unitOfWork.SaveAsync();
                }
            return Unit.Value;
            }
        }
    }
    

