﻿using System.Threading.Tasks;
using static Xamarin.Essentials.Permissions;

namespace PAT.Portable.Services
{
    public interface IPermissionService
    {
        Task<bool> CheckAndRequestPermissionAsync<TPermission>() where TPermission : BasePermission, new();
    }
}