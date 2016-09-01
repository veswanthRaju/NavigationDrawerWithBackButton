using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App1.Fragments;
using System;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content.Res;

namespace App1.Activities
{
    [Activity(Label = "App1", Theme = "@style/MyTheme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        Android.Support.V4.App.FragmentTransaction ft;
        ActionBarDrawerToggle drawerToggle;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            SetSupportActionBar(toolbar);
            SupportActionBar?.SetTitle(Resource.String.title);

            //Display Home button in toolbar add add backbutton once we click on home
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Attach item selected handler to navigation view
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);

            //It will show the home and back button when it is opened and closed
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            //Adding default Home_Layout to Frame layout using fragment
            ft = SupportFragmentManager.BeginTransaction();
            ft.Add(Resource.Id.HomeFrameLayout, new HomeFragment());
            ft.Commit();
            
            SupportFragmentManager.BackStackChanged += SupportFragmentManager_BackStackChanged;
        }

        //To display back button when we have back instances
        //We are  Hiding Hamburger button so that it will display Back button..
        private void SupportFragmentManager_BackStackChanged(object sender, EventArgs e)
        {
            //Showing back button only if : we have and back stack count, else : back button
            drawerToggle.DrawerIndicatorEnabled = SupportFragmentManager.BackStackEntryCount == 0;
            //SupportActionBar.SetDisplayHomeAsUpEnabled(SupportFragmentManager.BackStackEntryCount == 1);
        }
        
        //define action for navigation menu selection
        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_home):
                    Toast.MakeText(this, "Home selected!", ToastLength.Short).Show();
                    //TO display default home fragment.
                    ft = SupportFragmentManager.BeginTransaction();

                    //Adding fragment to the Framelayout to include in main.axml
                    ft.Add(Resource.Id.HomeFrameLayout, new HomeFragment());
                    ft.Commit();
                    SupportActionBar.SetTitle(Resource.String.home_title);
                    break;

                case (Resource.Id.nav_messages):
                    Toast.MakeText(this, "Message selected!", ToastLength.Short).Show();
                    ft = SupportFragmentManager.BeginTransaction();
                    ft.Add(Resource.Id.HomeFrameLayout, new MsgFragment());
                    ft.Commit();
                    
                    SupportActionBar.SetTitle(Resource.String.msg_title);
                    break;

                case (Resource.Id.nav_friends):
                    ft = SupportFragmentManager.BeginTransaction();
                    ft.Add(Resource.Id.HomeFrameLayout, new MemberFragment());
                    ft.Commit();
                    SupportActionBar.SetTitle(Resource.String.member_title);
                    // React on 'Friends' selection
                    break;

                case (Resource.Id.rating):
                case (Resource.Id.post):
                    StartActivity(typeof(PageActivity));
                    break;

                default:
                    SupportActionBar.SetTitle(Resource.String.title);
                    break;
            }
            // Close drawer
            drawerLayout.CloseDrawers();
        }

        //define action for tolbar icon press
        public override bool OnOptionsItemSelected(IMenuItem item)
        {      
            //To make Hamburger button work properly bcz we not passed tool bar in costructor..
            if (drawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }

            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    SupportFragmentManager.PopBackStack();
                    return true;
                //case Resource.Id.action_attach:
                //    //FnAttachImage();
                //    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        //to avoid direct app exit on backpreesed and to show fragment from stack
        //public override void OnBackPressed()
        //{
        //    if (FragmentManager.BackStackEntryCount != 0)
        //    {
        //        FragmentManager.PopBackStack();
        //    }
        //    else
        //    {
        //        base.OnBackPressed();
        //    }
        //}

        //define custom title text
        //protected override void OnResume()
        //{
        //    SupportActionBar.SetTitle(Resource.String.title);
        //    base.OnResume();
        //}

        //protected override void OnPostCreate(Bundle savedInstanceState)
        //{
        //    base.OnPostCreate(savedInstanceState);
        //    drawerToggle.SyncState();
        //}

        //add custom icon to toolbar
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.action_menu, menu);
        //    if (menu != null)
        //    {
        //        menu.FindItem(Resource.Id.action_refresh).SetVisible(true);
        //        menu.FindItem(Resource.Id.action_attach).SetVisible(false);
        //    }
        //    return base.OnCreateOptionsMenu(menu);
        //}
    }
}

