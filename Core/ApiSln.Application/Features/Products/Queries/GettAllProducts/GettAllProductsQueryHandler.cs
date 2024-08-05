using ApiSln.Application.DTOs;
using ApiSln.Application.İnterface.UnitOfWorks;
using ApiSln.Application.İnterfaces.AutoMapper;
using ApiSln.Domain.Entitys;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;

        public GettAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GettAllProductsQueryResponse>> Handle(GettAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GettAllAsync(include: x => x.Include(b => b.Brand));
            var brand = mapper.Map<BrandDto, Brand>(new Brand()); 

            var map = mapper.Map<GettAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);


            //return map;
            throw new Exception("hata mesajı");
        }
    }
}
