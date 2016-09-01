using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.App;

namespace App1.Fragments
{
    class MsgFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var view = inflater.Inflate(Resource.Layout.msgLayout, container, false);
            var button = view.FindViewById<Button>(Resource.Id.BtnMsg);
            button.Click += Button_Click;

            return view;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var ft = (this.Activity as AppCompatActivity).SupportFragmentManager.BeginTransaction();
            ft.AddToBackStack("");
            ft.Add(Resource.Id.HomeFrameLayout, new PageFragment());
            ft.Commit();
        }
    }
}