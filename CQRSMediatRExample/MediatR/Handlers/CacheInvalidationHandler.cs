using CQRSMediatRExample.Context;
using CQRSMediatRExample.MediatR.Notifications;
using MediatR;

namespace CQRSMediatRExample.MediatR.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotificacion>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(ProductAddedNotificacion notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidate");
            await Task.CompletedTask;
        }
    }
}
