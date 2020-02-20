using Core.TicketSupport.Shared.Commands;

namespace Core.TicketSupport.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T Commad);
    }
}
