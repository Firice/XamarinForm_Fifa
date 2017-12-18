using Android.App;
using Android.Content.PM;
using Android.OS;
using DLToolkit.Forms.Controls;

namespace XamarinForm_Fifa.Droid
{
    [Activity(Label = "XamarinForm_Fifa", Icon = "@drawable/fifa", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            FlowListView.Init();
            LoadApplication(new App());
        }
    }
}

