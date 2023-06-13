using CQRSMediatRExample.Entities;
using MediatR;

namespace CQRSMediatRExample.MediatR.Notifications
{
    public record ProductAddedNotificacion(Product Product) : INotification;
}
