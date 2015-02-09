using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using FragmentStatePagerAdapterCrash.Core;
using FragmentStatePagerAdapterCrash.Core.ViewModels;

namespace FragmentStatePagerAdapterCrash.Views
{
    public class PagerView<T> : MvxFragment<PagerViewModelBase<T>> where T : IGenericObject
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.PagerView, container, false);
        }
    }

    public class FirstPagerView : PagerView<FirstGenericObject>
    { }

    public class SecondPagerView : PagerView<SecondGenericObject>
    { }

    public class ThirdPagerView : PagerView<ThirdGenericObject>
    { }

    public class FourthPagerView : PagerView<FourthGenericObject>
    { }

    public class FifthPagerView : PagerView<FifthGenericObject>
    { }
}