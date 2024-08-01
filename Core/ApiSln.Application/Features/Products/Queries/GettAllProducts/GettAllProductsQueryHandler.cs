using ApiSln.Application.İnterface.UnitOfWorks;
using ApiSln.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Queries.GettAllProducts
{
    public class GettAllProductsQueryHandler : IRequestHandler<GettAllProductsQueryRequest, IList<GettAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GettAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GettAllProductsQueryResponse>> Handle(GettAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GettAllAsync();

            List<GettAllProductsQueryResponse> response = new();

            foreach (var product in products)
                response.Add(new GettAllProductsQueryResponse
                {
                    Title = product.Title,
                    Description = product.Description,           // products lar döndürüldü ve productslar için bir respons listesi oluşturuldu ve her döndüğümüz productsları eşledik
                    Price = product.Price - (product.Price * product.Discount / 100),                               
                    Discount = product.Discount,
                });
            
            return response;    
        }
    }
}
