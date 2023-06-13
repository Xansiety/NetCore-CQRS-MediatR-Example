using CQRSMediatRExample.Context;
using CQRSMediatRExample.MediatR.Notifications;
using MediatR;

namespace CQRSMediatRExample.MediatR.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotificacion>
    {
        private FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(ProductAddedNotificacion notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Email Sent");
            await Task.CompletedTask;
        }
    }
}
