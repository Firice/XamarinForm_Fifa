using System.Collections.Generic;
using System.Linq;

namespace XamarinForm_Fifa.ViewModels
{
    using MVVM;
    using System.Threading.Tasks;
    using Client;
    using Models;
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class HomePageViewModel : ViewModelBase
    {
        private readonly FifaClient _fifaClient;

        public ICommand SelectedCompetition { get; }
        public ICommand LoadingCommand { get; }
        public ICommand RefreshCommand { get; }

        public HomePageViewModel()
        {
            IsBusy = true;
            _fifaClient = new FifaClient();

            SelectedCompetition = new Command<Competition>(OnCompetitionSelected);
            LoadingCommand = new Command(ExecuteLoading);
            RefreshCommand = new Command(ExecuteRefresh);
        }

        private async void OnCompetitionSelected(Competition obj)
        {
            await NavigateToPageAsync<CompetitionPage>(obj);
        }

        #region Loading
        private async void ExecuteLoading()
        {
            var result = await _fifaClient.CurrentAsync();
            if (result.Success)
            {
                var data = new List<Competition>();
                data.AddRange(result.Data.Competitions.ToList());
                data.AddRange(Competitions);
                Competitions = data;
            }
            IsLoadingInfinite = false;
        }
        #endregion

        #region Refresh
        private async void ExecuteRefresh()
        {
            Competitions.Clear();
            await LoadAsync();
            IsRefreshing = false;
        }
        #endregion

        #region Load Data
        public override async void Init(object param = null)
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            if (Competitions?.Count > 0) return;
            IsBusy = true;
            var result = await _fifaClient.CurrentAsync();
            IsBusy = false;
            if (result.Success) Competitions = result.Data.Competitions;
        }
        #endregion
    }

    public class MainTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }

        public DataTemplate LiveTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Competition competition && competition.Live)
            {
                return LiveTemplate;
            }
            return DefaultTemplate;
        }
    }
}