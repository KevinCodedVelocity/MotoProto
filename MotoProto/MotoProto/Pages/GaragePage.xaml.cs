using System;
using Xamarin.Forms;

namespace MotoProto.Pages
{
    public partial class GaragePage : ContentPage
    {
        public GaragePage()
        {
            InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SplashPage());
        }
    }
}
