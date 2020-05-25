﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Occupi.Models;
using PAT.Portable.Services;

namespace Occupi.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IConnectivityService _connectivityService => DependencyService.Get<IConnectivityService>();
        public ILocationService _locationService => DependencyService.Get<ILocationService>();
        public IDataStore<Venue> VenueDataStore => DependencyService.Get<IDataStore<Venue>>();
        public IDataStore<Event> EventDataStore => DependencyService.Get<IDataStore<Event>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public bool IsReachable
        {
            get => _connectivityService?.IsConnected == true;
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
                                      [CallerMemberName]string propertyName = "",
                                      Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
