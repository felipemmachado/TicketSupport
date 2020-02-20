using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TicketSupport.Shared.Commands
{
    public interface ICommand
    {
        void Validate();
    }
}
