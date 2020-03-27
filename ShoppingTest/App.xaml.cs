using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingTest.Services;
using ShoppingTest.Pages;

namespace ShoppingTest
{
    public partial class App : Application
    {

        static ProductDatabase database;

        public static ProductDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Listing());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
