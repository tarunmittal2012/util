using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using Utility.Resources.Adapter;

namespace Utility
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TabLayout mTabLayout;
        ViewPager viewPager;
        Toolbar toolbar;
        DrawerLayout drawerLayout;  
        NavigationView navigationView;  
     
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            mTabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);  
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);  
            SupportActionBar.SetDisplayShowTitleEnabled(false);  
            SupportActionBar.SetHomeButtonEnabled(true);  
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);  
            drawerLayout = FindViewById < DrawerLayout > (Resource.Id.drawer_layout);  
            navigationView = FindViewById < NavigationView > (Resource.Id.nav_view);  
            mTabLayout.AddTab(mTabLayout.NewTab().SetText(Resource.String.tab1));
            mTabLayout.AddTab(mTabLayout.NewTab().SetText(Resource.String.tab2));
            mTabLayout.AddTab(mTabLayout.NewTab().SetText(Resource.String.tab3));
            FragmentAdapter fragmentAdapter = new FragmentAdapter(SupportFragmentManager, mTabLayout.TabCount);
            viewPager.Adapter = fragmentAdapter;
            viewPager.AddOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(mTabLayout));
            mTabLayout.TabSelected += MTabLayout_TabSelected; 
        }

        private void MTabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            var tab = e.Tab;
            viewPager.SetCurrentItem(mTabLayout.SelectedTabPosition,true);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)   
        {  
            switch (item.ItemId)   
            {  
                case Android.Resource.Id.Home:  
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);  
                    return true;  
            }  
            return base.OnOptionsItemSelected(item);  
        }  
    }
}
