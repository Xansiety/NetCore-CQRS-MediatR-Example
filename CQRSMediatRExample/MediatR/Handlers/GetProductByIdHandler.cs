using CQRSMediatRExample.Context;
using CQRSMediatRExample.Entities;
using CQRSMediatRExample.MediatR.Queries;
using MediatR;

namespace CQRSMediatRExample.MediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProductById(request.Id);
        }
    }
}
