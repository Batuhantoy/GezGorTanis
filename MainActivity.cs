using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using GezGorTaniss.Views;
using Android.Content;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace GezGorTaniss
{
    [Activity(Label = "GezGorTaniss", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        private ViewPager mViewPager;
        private SlidingTabScrollView mScrollView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.girisayfasi);


            Button btnkayitol = FindViewById<Button>(Resource.Id.btnKayitOl);
            Button btngiris = FindViewById<Button>(Resource.Id.btnGiris);
            Button tamamlar = FindViewById<Button>(Resource.Id.btnTamamla);
            EditText login = FindViewById<EditText>(Resource.Id.txtLogin);
            EditText passaword = FindViewById<EditText>(Resource.Id.txt_passaword);
            EditText kayitadsoyadgir = FindViewById<EditText>(Resource.Id.txt_adsoyad);
            EditText kayitlogingir = FindViewById<EditText>(Resource.Id.txt_logingir);
            EditText kayitsifregir = FindViewById<EditText>(Resource.Id.txt_passaword);

            TextView textview = FindViewById<TextView>(Resource.Id.textView1);

            btnkayitol.Click += delegate
            {
                StartActivity(typeof(KayitOlmaSayfasi));
            };

            btngiris.Click += delegate
            {
                /*SetContentView(Resource.Layout.Main);
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                SlidingTabFragment fragment = new SlidingTabFragment();
                transaction.Replace(Resource.Id.sample_content_fragment, fragment);
                transaction.Commit();*/
                SetContentView(Resource.Layout.Main);
                mScrollView = FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
                mViewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

                mViewPager.Adapter = new SlidingTabFragment.SamplePagerAdapter(SupportFragmentManager);
                mScrollView.ViewPager = mViewPager;
            };

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Resource.Id.googleMap:
                    var mapIntent = new Intent(this, typeof(GoogleMapsPage));
                    StartActivity(mapIntent);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}


