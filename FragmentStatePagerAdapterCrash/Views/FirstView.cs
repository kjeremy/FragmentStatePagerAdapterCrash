using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using FragmentStatePagerAdapterCrash.Core.ViewModels;

namespace FragmentStatePagerAdapterCrash.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            this.FragmentManager.BeginTransaction()
                .Replace(Android.Resource.Id.Content, new PagerContainer() { ViewModel = new PagerContainerViewModel()})
                .Commit();
        }
    }
}