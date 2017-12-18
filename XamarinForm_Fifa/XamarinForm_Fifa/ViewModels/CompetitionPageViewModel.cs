namespace XamarinForm_Fifa.ViewModels
{
    using Client;
    using Models;
    using MVVM;
    using Views;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CompetitionPageViewModel : ViewModelBase
    {
        private CompetitionDetail _competition;
        public ICommand MatchCommand { get; }
        public ICommand TeamCommand { get; }

        public CompetitionPageViewModel()
        {
            IsBusy = true;

            MatchCommand = new Command<Match>(ViewMatch);
            TeamCommand = new Command<int>(ViewTeam);
        }

        private async void ViewTeam(int teamId)
        {
            var team = new Team { TeamId = teamId };
            await NavigateToPageAsync<TeamDetailPage>(team);
        }

        private async void ViewMatch(Match match) 
        {
            await NavigateToPageAsync<MatchDetailPage>(match);
        }

        public CompetitionDetail Competition
        {
            get => _competition;
            private set
            {
                if (_competition == value) return;
                _competition = value;
                OnPropertyChanged();
            }
        }

        public override async void Init(object param = null)
        {
            base.Init(param);

            if (!(param is Competition competition)) return;
            Title = competition.CompetitionEn;
            IsBusy = true;
            var result = await FifaClient.CurrentClient.CompetitionAsync(competition.CompetitionId.ToString());
            if (result.Success)
            {
                if (result.Data != null && result.Data.Matches.Any())
                {
                    foreach (var item in result.Data.Matches)
                    {
                        if (item.Score == "-:-") item.Score = "N/A : N/A";
                    }
                }

                Competition = result.Data;
            }
            IsBusy = false;
        }
    }
} 