using System.Threading.Tasks;

namespace PAT.Portable.Services.Interfaces
{
    public interface IAlertService
    {
        Task DisplayDismissiveAlert(string message, string dismissiveAction);
        Task DisplayDismissiveAlert(string title, string message, string dismissiveAction);

        Task<bool> DisplayStandardAlert(string title, string confirmationAction, string dismissiveAction);
        Task<bool> DisplayStandardAlert(string title, string message, string confirmationAction, string dismissiveAction);

        Task<string> DisplayTwoActionAlert(string title, string destructiveAction, string confirmationAction);
        Task<string> DisplayTwoActionAlert(string title, string message, string destructiveAction, string confirmationAction);

        Task<string> DisplayContextMenu(string destructiveAction = null, params string[] confirmationActions);

        Task<string> DisplayAlertWithInput(string title, string placeholder, string confirmationAction);
    }
}
