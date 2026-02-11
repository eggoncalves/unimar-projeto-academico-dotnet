using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;
using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.Interface;

namespace Unimar.ProjetoAcademico.ApplicationService.DTOs;

public class CommandResponse<T> where T : class
{
    public bool Sucesso { get; set; }
    public T? Items { get; set; }
    public IReadOnlyCollection<Notification> Notificacoes { get; set; }

    public CommandResponse(T items, INotifiable notificacoes)
    {
        Sucesso = notificacoes.IsValid();
        Items = items;
        Notificacoes = notificacoes.Notifications;
    }

    public CommandResponse(INotifiable notificacoes)
    {
        Sucesso = false;
        Items = null;
        Notificacoes = notificacoes.Notifications;
    }
}