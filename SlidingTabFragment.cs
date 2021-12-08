using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Interop;
using Java.Lang;
using GezGorTaniss.Views;
using Android.Support.V4.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace GezGorTaniss
{
    public class SlidingTabFragment : Android.App.Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;
        //public SlidingTabFragment(Context context, IAttributeSet attrs) :
        //    base(context, attrs)
        //{
        //    Initialize();
        //}

        //public SlidingTabFragment(Context context, IAttributeSet attrs, int defStyle) :
        //    base(context, attrs, defStyle)
        //{
        //    Initialize();
        //}

        //private void Initialize()
        //{
        //}
        /*public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sample,container,false);
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter();

            mSlidingTabScrollView.ViewPager = mViewPager;
        }*/
        public class SamplePagerAdapter : FragmentPagerAdapter
        {
            /*List<string> items = new List<string>();

            public SamplePagerAdapter() : base()
            {
                items.Add("Harita");
                items.Add("Gezilcek Yerler");
                items.Add("Arkadaşlar");
                //items.Add("");
                //items.Add("");
                //items.Add("");
            }
            public override int Count
            {
                get { return items.Count; }
            }
            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }
            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                container.AddView(view);

                TextView txtTitle = view.FindViewById<TextView>(Resource.Id.item_title);
                int pos = position + 1;
                txtTitle.Text = pos.ToString();

                return view;
            }
            public string GetHeaderTitle(int position)
            {
                return items[position];
            }
            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }*/
            private List<Android.Support.V4.App.Fragment> mFragmentHolder;

            public SamplePagerAdapter(Android.Support.V4.App.FragmentManager fragManager) : base(fragManager)
            {
                mFragmentHolder = new List<Android.Support.V4.App.Fragment>();
                mFragmentHolder.Add(new Fragment1());
                mFragmentHolder.Add(new Fragment2());
            }

            public override int Count
            {
                get { return mFragmentHolder.Count; }
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return mFragmentHolder[position];
            }
        }
        public class Fragment1 : Android.Support.V4.App.Fragment
        {
            //private TextView mTextView;
            /*public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                //var view = inflater.Inflate(Resource.Layout.GoogleMaps, container, false);
                //mTextView = view.FindViewById<TextView>(Resource.Id.textView1);
                //mTextView.Text = "Fragment 1 Class";
                //return view;
                Intent intent = new Intent(this.Activity,typeof(GoogleMapsPage));
                StartActivity(intent);
                //return intent;
            }*/
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                var mapIntent = new Intent(this.Activity, typeof(GoogleMapsPage));
                StartActivity(mapIntent);
            }
            public override void OnStop()
            {
                base.OnStop();
            }
            /*public void OnMapReady(GoogleMap googleMap)
            {
                MarkerOptions markerOptions = new MarkerOptions();
                markerOptions.SetPosition(new LatLng(16.03, 108));
                markerOptions.SetTitle("My Position");

                googleMap.AddMarker(markerOptions);

                googleMap.UiSettings.ZoomControlsEnabled = true;
                googleMap.UiSettings.CompassEnabled = true;
                googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());

                googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(41.889, -87.622), 16));
                googleMap.AddMarker(new MarkerOptions().SetPosition(new LatLng(41.889, -87.622)));
                googleMap.MapType = GoogleMap.MapTypeTerrain;
            }*/

            public override string ToString() //Called on line 156 in SlidingTabScrollView
            {
                return "GoogleMap";
            }
        }
        public class Fragment2 : Android.Support.V4.App.Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.KayitOlmaSayfasii, container, false);
                return view;
            }

            public override string ToString() //Called on line 156 in SlidingTabScrollView
            {
                return "Burası Degişçek";
            }
        }
    }
}