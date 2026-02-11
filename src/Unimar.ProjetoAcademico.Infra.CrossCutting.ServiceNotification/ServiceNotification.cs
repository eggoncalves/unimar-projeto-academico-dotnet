using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern;
using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interfaces;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

public class ServiceNotification : Notifiable, IServiceNotification
{
    public bool IsServiceValid  => IsValid();
    public bool IsServiceInvalid => IsInvalid();
    public IReadOnlyCollection<Notification> ServiceNotifications => Notifications;
}