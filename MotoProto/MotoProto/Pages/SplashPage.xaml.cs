using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoProto.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        const string AnimationName = "splash";
        const int AnimationDuration = 2000; // MS

        public SplashPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            StartAnimation();
        }

        void StartAnimation()
        {
            var animation = new Animation(OnAnimationUpdate, finished: OnAnimationFinished);
            animatedControl.Animate(AnimationName, animation, length: AnimationDuration);
        }

        void OnAnimationUpdate(double elapsedTimeDelta)
        {
            FadeInFadeOutControl(elapsedTimeDelta);

            ScaleControl(elapsedTimeDelta);
        }

        private void FadeInFadeOutControl(double elapsedTimeDelta)
        {
            animatedControl.Opacity = elapsedTimeDelta;
        }

        private void ScaleControl(double elapsedTimeDelta)
        {
            animatedControl.Opacity = elapsedTimeDelta * 4;
        }

        void OnAnimationFinished()
        {
            Navigation.PushAsync(new GaragePage());
        }
    }
}