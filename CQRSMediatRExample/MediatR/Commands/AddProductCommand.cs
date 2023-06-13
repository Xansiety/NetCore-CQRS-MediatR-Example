using CQRSMediatRExample.Entities;
using MediatR;

namespace CQRSMediatRExample.MediatR.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
