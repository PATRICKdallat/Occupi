using System;
using System.Threading.Tasks;
using PAT.Portable.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace PAT.Portable.Services
{
    public class PermissionService : IPermissionService
    {
        public async Task<bool> CheckAndRequestPermissionAsync<TPermission>() where TPermission : BasePermission, new()
        {
            try
            {
                var checkedStatus = await Permissions.CheckStatusAsync<TPermission>();
                if (checkedStatus != PermissionStatus.Granted)
                {
                    var requestStatus = await Permissions.RequestAsync<TPermission>();
                    if (requestStatus != PermissionStatus.Granted)
                    {
                        if (checkedStatus == PermissionStatus.Denied)
                        {
                            await GrantPermissions();
                        }
                        return false;
                    }
                }

                return true;
            }
            catch (ObjectDisposedException)
            {
                await GrantPermissions();
            }

            return false;
        }

        private async Task GrantPermissions()
        {
            var grantPermision = await DependencyService.Get<IAlertService>().DisplayStandardAlert("Permissions Denied", $"Grant permission for app to gain access to this feature.", "Grant Permission", "Cancel");

            if (grantPermision)
            {
                DependencyService.Get<ISystemService>().OpenAppSettings();
            }
        }
    }
}
