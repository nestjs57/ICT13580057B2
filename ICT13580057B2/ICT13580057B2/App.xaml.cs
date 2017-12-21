using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICT13580057B2.Helpers;

using Xamarin.Forms;

namespace ICT13580057B2
{
    public partial class App : Application
    {
        public static DbHelper DbHelper { get; set; }
        public App(string dbpath)
        {
            InitializeComponent();
            DbHelper = new DbHelper(dbpath);
            MainPage = new NavigationPage(new ICT13580057B2.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
