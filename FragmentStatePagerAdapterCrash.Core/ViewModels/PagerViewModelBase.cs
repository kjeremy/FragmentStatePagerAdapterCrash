using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;

namespace FragmentStatePagerAdapterCrash.Core.ViewModels
{
    public abstract class PagerViewModelBase<T> : MvxViewModel where T : IGenericObject
    {
        #region Title

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #endregion

        private IMvxMessenger _messenger;

        protected PagerViewModelBase(IMvxMessenger messenger)
        {
            this._messenger = messenger;
        }
    }

    public class FirstPagerViewModel : PagerViewModelBase<FirstGenericObject>
    {
        public FirstPagerViewModel()
            : base(Mvx.Resolve<IMvxMessenger>())
        {
            this.Title = "First";
        }
    }

    public class SecondPagerViewModel : PagerViewModelBase<SecondGenericObject>
    {
        public SecondPagerViewModel()
            : base(Mvx.Resolve<IMvxMessenger>())
        {
            this.Title = "Second";
        }
    }

    public class ThirdPagerViewModel : PagerViewModelBase<ThirdGenericObject>
    {
        public ThirdPagerViewModel()
            : base(Mvx.Resolve<IMvxMessenger>())
        {
            this.Title = "Third";
        }
    }

    public class FourthPagerViewModel : PagerViewModelBase<FourthGenericObject>
    {
        public FourthPagerViewModel()
            : base(Mvx.Resolve<IMvxMessenger>())
        {
            this.Title = "Fourth";
        }
    }

    public class FifthPagerViewModel : PagerViewModelBase<FifthGenericObject>
    {
        public FifthPagerViewModel()
            : base(Mvx.Resolve<IMvxMessenger>())
        {
            this.Title = "Fifth";
        }
    }
}