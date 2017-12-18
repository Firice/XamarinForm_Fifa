namespace XamarinForm_Fifa.MVVM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Models;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region IsBusy
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value) return;
                _isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy => !IsBusy;
        #endregion

        #region Title
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Refresh
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value) return;
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region IsLoadingInfinite
        private bool _isLoadingInfinite;
        public bool IsLoadingInfinite
        {
            get => _isLoadingInfinite;
            set
            {
                if (_isLoadingInfinite == value) return;
                _isLoadingInfinite = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Competition
        private List<Competition> _competitions;

        public List<Competition> Competitions
        {
            get => _competitions;
            set
            {
                if (_competitions == value) return;
                _competitions = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public virtual void Init(object param = null)
        {

        }

        protected Task NavigateToPageAsync<T>(Object param) where T : ViewBase
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PushAsync((ViewBase)Activator.CreateInstance(typeof(T), param));
            }

            return Task.FromResult((object)null);
        }

        protected Task NavigateToPageAsync<T>() where T : Page
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PushAsync(Activator.CreateInstance<T>());
            }

            return Task.FromResult((object)null);
        }
    }
}