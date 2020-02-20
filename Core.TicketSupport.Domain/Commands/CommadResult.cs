using Core.TicketSupport.Shared.Commands;

namespace Core.TicketSupport.Domain.Commands
{
    public class CommadResult : ICommandResult
    {
        public CommadResult() 
        {

        }

        public CommadResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
