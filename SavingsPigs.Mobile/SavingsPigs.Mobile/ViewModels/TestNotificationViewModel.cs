using SavingsPigs.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SavingsPigs.Mobile.ViewModels
{
    public class TestNotificationViewModel : BaseViewModel
    {
        public ICommand PushRandomNotification { get; set; }
        public ICommand PushINGNotification { get; set; }
        public ICommand PushMBankNotification { get; set; }
        public ICommand PushPKONotification { get; set; }
        public TestNotificationViewModel()
        {
            Title = "Test Notifications";
            PushRandomNotification = new Command(async () => await DependencyService.Get<INotification>().CreateNotification("SavingsPig", "Hi, I would help u save yours money!"));
            PushINGNotification = new Command(async () => await DependencyService.Get<INotification>().CreateNotification("Visa zbliżeniowa - ING", "16,58 zł"));
            PushMBankNotification = new Command(async () => await DependencyService.Get<INotification>().CreateNotification("Visa zbliżeniowa - mBank", "100,55 zł"));
            PushPKONotification = new Command(async () => await DependencyService.Get<INotification>().CreateNotification("Visa zbliżeniowa - PKO B.P.", "0,50 zł"));
        }
    }
}
