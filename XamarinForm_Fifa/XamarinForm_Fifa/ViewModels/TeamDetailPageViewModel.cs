namespace XamarinForm_Fifa.ViewModels
{
    using Client;
    using Models;
    using MVVM;

    public class TeamDetailPageViewModel : ViewModelBase
    {
        private TeamDetail _teamDetail;
        public TeamDetail TeamDetail
        {
            get => _teamDetail;
            private set
            {
                if (_teamDetail == value) return;
                _teamDetail = value;
                OnPropertyChanged();
            }
        }

        public override async void Init(object param = null)
        {
            base.Init(param);

            if (!(param is Team teamDetail)) return;
            IsBusy = true;
            var result = await FifaClient.CurrentClient.TeamAsync(teamDetail.TeamId.ToString());
            if (result.Success)
            {
                Title = "Team Details";
                TeamDetail = result.Data;
            }
            IsBusy = false;
        }
    }
}