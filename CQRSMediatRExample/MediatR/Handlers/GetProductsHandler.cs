using CQRSMediatRExample.Context;
using CQRSMediatRExample.Entities;
using CQRSMediatRExample.MediatR.Queries;
using MediatR;

namespace CQRSMediatRExample.MediatR.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetAllProducts();
        }
    }
}
