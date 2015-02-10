using System;
using Android.App;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using FragmentStatePagerAdapterCrash.Core;
using FragmentStatePagerAdapterCrash.Core.ViewModels;
using Java.Lang;
using Java.Lang.Reflect;

namespace FragmentStatePagerAdapterCrash.Views
{
    public class PagerView<TViewModel> : MvxFragment<TViewModel> where TViewModel : MvxViewModel
    {
        protected bool IsMenuVisible = true;
        private Fragment _childFragment;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.PagerView, container, false);
        }
        
        public override void SetMenuVisibility(bool menuVisible)
        {
            this.IsMenuVisible = menuVisible;
            base.SetMenuVisibility(menuVisible);

            var child = this.ChildFragment;
            if (child != null)
                child.SetMenuVisibility(menuVisible);
        }
        
        public override bool UserVisibleHint
        {
            get { return base.UserVisibleHint; }
            set
            {
                base.UserVisibleHint = value;
                var child = this.ChildFragment;
                if (child != null)
                    child.UserVisibleHint = value;
            }
        }
        
        protected Fragment ChildFragment
        {
            get { return this._childFragment; }
            set
            {
                this._childFragment = value;
                if (value != null)
                {
                    value.UserVisibleHint = this.UserVisibleHint;
                    value.SetMenuVisibility(this.IsMenuVisible);
                }
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            this.ChildFragment = null;
        }

        public override void OnDetach()
        {
            base.OnDetach();

            this.ChildFragment = null;

            // Fix nested fragment's being put into an invalid state.
            // See: https://stackoverflow.com/questions/18977923/viewpager-with-nested-fragments
            // See: https://stackoverflow.com/questions/15207305/getting-the-error-java-lang-illegalstateexception-activity-has-been-destroyed/15656428#15656428
            // See: https://code.google.com/p/android/issues/detail?id=42601
            try
            {
                Class fragmentClass = Class.FromType(typeof(Fragment));
                Field childFragmentManager = fragmentClass.GetDeclaredField("mChildFragmentManager");
                childFragmentManager.Accessible = true;
                childFragmentManager.Set(this, null);
            }
            catch (NoSuchFieldException e)
            {
                throw new InvalidOperationException(e.Message);
            }
            catch (IllegalAccessException e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }

    public class FirstPagerView : PagerView<FirstPagerViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var child = new NestedView {ViewModel = ViewModel};
            this.ChildFragmentManager.BeginTransaction().Replace(Resource.Id.child_container, child).Commit();
            this.ChildFragment = child;

            return view;
        }
    }

    public class SecondPagerView : PagerView<SecondPagerViewModel>
    { }

    public class ThirdPagerView : PagerView<ThirdPagerViewModel>
    { }

    public class FourthPagerView : PagerView<FourthPagerViewModel>
    { }

    public class FifthPagerView : PagerView<FifthPagerViewModel>
    { }


    public class NestedView : MvxFragment<PagerViewModelBase<FirstGenericObject>>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}