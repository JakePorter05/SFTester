using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SFTester.Services;
using SFTester.Views;
using Syncfusion.Licensing;

namespace SFTester
{
    public partial class App : Application
    {

        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MTgzMTQxQDMxMzcyZTM0MmUzMFV2UXBpcmZiRXFSbmR5b0Z1cERRdklNc1FqbFJGUzR6NmJzazdJaGZtbWs9");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
