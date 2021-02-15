using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingsPigs.Mobile.Services
{
    public interface INotification
    {
        Task CreateNotification(string title, string message);
    }
}
