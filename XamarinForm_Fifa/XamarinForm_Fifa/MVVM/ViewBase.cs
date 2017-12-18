namespace XamarinForm_Fifa.MVVM
{
    using Models;
    using Xamarin.Forms;

    public class ViewBase : ContentPage
    {
        protected object Param { get; set; }
        public ViewBase(object param = null)
        {
            Param = param;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is ViewModelBase viewModelBase)
            {
                viewModelBase.Init(Param);
            }
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
}