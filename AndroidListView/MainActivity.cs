using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

namespace AndroidListView
{
    [Activity(Label = "MyFirstAndroidApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Person> mItems;
        private ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.myListView);
            mItems = new List<Person>();
            mItems.Add(new Person() { FirstName = "Tamás", LastName = "Takács", Age = "30", Gender = "Férfi" });
            mItems.Add(new Person() { FirstName = "Gabriella", LastName = "Takács-Tar", Age = "30", Gender = "Nő" });

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;
            mListView.ItemClick += mListView_ItemClick;
            mListView.ItemLongClick += mListView_ItemLongClick;
        }

        private void mListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].LastName);
        }

        private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].FirstName);
        }
    }
}

