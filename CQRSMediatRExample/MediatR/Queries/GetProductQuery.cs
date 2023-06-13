using CQRSMediatRExample.Entities;
using MediatR;

namespace CQRSMediatRExample.MediatR.Queries
{
    public record class GetProductQuery : IRequest<IEnumerable<Product>>;
}
