using CQRSMediatRExample.Entities;
using MediatR;

namespace CQRSMediatRExample.MediatR.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
