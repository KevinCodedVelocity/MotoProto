
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoProto.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        const string AnimationName = "splash";
        const int AnimationDuration = 3000; // MS

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
            var animation = new Animation(OnAnimationUpdate);
            animatedControl.Animate(AnimationName, animation, length: AnimationDuration, finished: (a,b) => OnAnimationFinished());
        }

        void OnAnimationUpdate(double elapsedTimeDelta)
        {
            FadeInFadeOutControl(elapsedTimeDelta);

            ScaleControl(elapsedTimeDelta);
        }

        private void FadeInFadeOutControl(double elapsedTimeDelta)
        {
            // Fade in first half of animation
            if (elapsedTimeDelta <= 0.5)
            {
                animatedControl.Opacity = elapsedTimeDelta * 2;
            }

            // Fade out second half of animation
            else // elapsedTimeDelta > 0.5
            {
                var elapsedSecondHalfTime = elapsedTimeDelta - 0.5;
                animatedControl.Opacity = 1.0 - elapsedSecondHalfTime * 2;
            }
        }

        private void ScaleControl(double elapsedTimeDelta)
        {
            animatedControl.Scale = elapsedTimeDelta * 4;
        }

        async void OnAnimationFinished()
        {
            await Navigation.PushAsync(new GaragePage());
            Navigation.RemovePage(this);
        }
    }
}