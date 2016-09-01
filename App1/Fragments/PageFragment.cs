using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;

namespace App1.Fragments
{
    class PageFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var view =  inflater.Inflate(Resource.Layout.Pagelayout, container, false);
            var button = view.FindViewById<Button>(Resource.Id.BtnPage);
            button.Click += NavigateToPage;
            return view;
        }

        private void NavigateToPage(object sender, EventArgs e)
        {
            var instance = (this.Activity as AppCompatActivity).SupportFragmentManager.BeginTransaction();
            instance.AddToBackStack("");
            instance.Add(Resource.Id.HomeFrameLayout, new FinalFragment());
            instance.Commit();
        }
    }
}