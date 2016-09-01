
using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace App1.Activities
{
    [Activity(Label = "PageActivity")]
    public class PageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Pagelayout);
            //Display Back button
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            // Create your application here
        }

        //Fires when we click on back button on Actionbar menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}