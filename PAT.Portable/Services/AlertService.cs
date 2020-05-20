using System.Threading.Tasks;
using PAT.Services;
using Xamarin.Forms;

namespace PAT.Portable.Services
{
    public abstract class AlertService : IAlertService
    {
        protected Page Alerter { get { return Application.Current.MainPage; } }

        public abstract Task<string> DisplayAlertWithInput(string title, string placeholder, string action);

        public abstract Task<string> DisplayTwoActionAlert(string title, string destructiveAction, string confirmationAction);

        public abstract Task<string> DisplayTwoActionAlert(string title, string message, string destructiveAction, string confirmationAction);

        private Task<bool> DisplayAlertImplementation(string title, string message, string confirmationAction, string dismissiveAction)
        {
            var completionSource = new TaskCompletionSource<bool>();

            Device.BeginInvokeOnMainThread(() =>
            {
                Alerter.DisplayAlert(title, message, confirmationAction, dismissiveAction).ContinueWith(task =>
                    completionSource.SetResult(task.Result)
                );
            });

            return completionSource.Task;
        }

        public Task DisplayDismissiveAlert(string message, string dismissiveAction)
        {
            return DisplayAlertImplementation(null, message, null, dismissiveAction);
        }

        public Task DisplayDismissiveAlert(string title, string message, string dismissiveAction)
        {
            return DisplayAlertImplementation(title, message, null, dismissiveAction);
        }

        public Task<bool> DisplayStandardAlert(string title, string confirmationAction, string dismissiveAction)
        {
            return DisplayAlertImplementation(null, title, confirmationAction, dismissiveAction);
        }

        public Task<bool> DisplayStandardAlert(string title, string message, string confirmationAction, string dismissiveAction)
        {
            return DisplayAlertImplementation(title, message, confirmationAction, dismissiveAction);
        }

        public Task<string> DisplayContextMenu(string destructiveAction = null, params string[] confirmationActions)
        {
            var completionSource = new TaskCompletionSource<string>();

            Device.BeginInvokeOnMainThread(() =>
            {
                Alerter.DisplayActionSheet(null, "Cancel", destructiveAction, confirmationActions).ContinueWith(task =>
                    completionSource.SetResult(task.Result)
                );
            });

            return completionSource.Task;
        }
    }
}
