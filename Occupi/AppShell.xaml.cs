using System.Windows.Input;
using Occupi.Views;
using Xamarin.Forms;

namespace Occupi
{
    public partial class AppShell : Shell
    {
        public ICommand BecomeAHostCommand => new Command(async () => await Navigation.PushAsync(new NavigationPage(new VenuesPage())));

        public AppShell()
        {
            InitializeComponent();
        }
    }
}
