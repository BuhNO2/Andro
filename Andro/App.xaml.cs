using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Andro
{
    public partial class App : Application
    {
        public App()
        {
            Xamarin.Forms.DataGrid.DataGridComponent.Init();

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
