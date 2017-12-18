namespace XamarinForm_Fifa.ViewModels
{
    using Client;
    using Models;
    using MVVM;
    using Xamarin.Forms;

    public class MatchDetailPageViewModel : ViewModelBase
    {
        private MatchDetail _matchDetail;

        public MatchDetail MatchDetail
        {
            get => _matchDetail;
            private set
            {
                if (_matchDetail == value) return;
                _matchDetail = value;
                OnPropertyChanged();
            }
        }

        public override async void Init(object param = null)
        {
            base.Init(param);

            if (!(param is Match matchDetail)) return;
            Title = "Match Details";
            IsBusy = true;
            var result = await FifaClient.CurrentClient.MatchAsync(matchDetail.MatchId.ToString());
            if (result.Success)
            {
                MatchDetail = result.Data;
            }
            IsBusy = false;
        }
    }

    public class ActionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StartEndTemplate { get; set; }
        public DataTemplate GoalHomeTemplate { get; set; }
        public DataTemplate GoalAwayTemplate { get; set; }
        public DataTemplate SubstituteAwayTemplate { get; set; }
        public DataTemplate SubstituteHomeTemplate { get; set; }
        public DataTemplate CardHomeTemplate { get; set; }
        public DataTemplate CardAwayTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Action action)
            {
                if (action.ActionShort == "Y" || action.ActionShort == "R")
                {
                    return action.HomeOrAway == "H" ? CardHomeTemplate : CardAwayTemplate;
                }
                else if (action.ActionShort == "OG" || action.ActionShort == "G" || action.ActionShort == "PG")
                {
                    return action.HomeOrAway == "H" ? GoalHomeTemplate : GoalAwayTemplate;
                }
                else if (action.ActionShort == "Sub")
                {
                    return action.HomeOrAway == "H" ? SubstituteHomeTemplate : SubstituteAwayTemplate;
                }
                else if (action.ActionShort == "Start" || action.ActionShort == "End")
                {
                    return StartEndTemplate;
                }
            }

            return DefaultTemplate;
        }
    }
}
