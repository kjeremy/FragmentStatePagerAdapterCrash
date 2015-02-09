using System;
using Android.App;
using Android.OS;
using Android.Support.V13.App;
using Android.Support.V4.View;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using FragmentStatePagerAdapterCrash.Core.ViewModels;
using Java.Lang;

namespace FragmentStatePagerAdapterCrash.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var pager = this.FindViewById<ViewPager>(Resource.Id.pager);
            pager.Adapter = new PagerAdapter(this.FragmentManager, this.ViewModel);

        }


        public class PagerAdapter : FragmentStatePagerAdapter
        {

            private readonly WeakReference<FirstViewModel> _parentViewModel;

            private static readonly Java.Lang.String[] Titles =
            {
                new Java.Lang.String("First"),
                new Java.Lang.String("Second"),
                new Java.Lang.String("Third"),
                new Java.Lang.String("Fourth"),
                new Java.Lang.String("Fifth"),
            };

            public PagerAdapter(FragmentManager fm, FirstViewModel parentViewModel)
                : base(fm)
            {
                this._parentViewModel = new WeakReference<FirstViewModel>(parentViewModel);
            }

            public override int Count
            {
                get { return 5; }
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return Titles[position];
            }

            public override Fragment GetItem(int position)
            {
                FirstViewModel parentViewModel;
                if (this._parentViewModel.TryGetTarget(out parentViewModel))
                {
                    switch (position)
                    {
                        case 0:
                            return new FirstPagerView { ViewModel = new FirstPagerViewModel() };
                        case 1:
                            return new SecondPagerView { ViewModel = new SecondPagerViewModel() };
                        case 2:
                            return new ThirdPagerView { ViewModel = new ThirdPagerViewModel() };
                        case 3:
                            return new FourthPagerView { ViewModel = new FourthPagerViewModel() };
                        case 4:
                            return new FifthPagerView { ViewModel = new FifthPagerViewModel() };
                    }
                }
                return null;
            }

            public override void SetPrimaryItem(ViewGroup container, int position, Java.Lang.Object @object)
            {
                this.CurrentFragment = (Fragment)@object;
                base.SetPrimaryItem(container, position, @object);
            }

            public Fragment CurrentFragment { get; private set; }
        }
    }
}