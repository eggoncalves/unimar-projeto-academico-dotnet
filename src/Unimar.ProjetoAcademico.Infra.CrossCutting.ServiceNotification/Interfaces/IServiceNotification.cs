using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interfaces;

public interface IServiceNotification
{
    bool IsServiceValid { get; }
    bool IsServiceInvalid { get; }
    IReadOnlyCollection<Notification> ServiceNotifications { get; }
}