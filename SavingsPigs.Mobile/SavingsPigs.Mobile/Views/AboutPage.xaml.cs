using SavingsPigs.Mobile.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SavingsPigs.Mobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        public void SendNotification_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<INotification>().CreateNotification("SavingsPig", "Hi, I would help u save yours money!");
        }
    }
}