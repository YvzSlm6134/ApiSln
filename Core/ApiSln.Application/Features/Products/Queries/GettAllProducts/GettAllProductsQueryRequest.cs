using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Queries.GettAllProducts
{
    public class GettAllProductsQueryRequest : IRequest<IList<GettAllProductsQueryResponse>>

    {
    }
}
