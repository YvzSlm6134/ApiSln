using ApiSln.Application.Bases;
using ApiSln.Application.Features.Products.Rules;
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

namespace ApiSln.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler , IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(ProductRules productRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GettAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            foreach (var item in products)
            {
                if (item.Title == request.Title) { }
                
            }

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
    

