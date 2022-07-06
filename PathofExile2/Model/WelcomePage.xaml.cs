using PathofExile2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PathofExile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        async void GoToCollection(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        async void GoToSkillTree(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SkillTreePage());
        }
        async void GoToMarketWatcher(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MarketWatcherPage());
        }
        async void GoToExpedition(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ExpeditionLeaguePage());
        }

        async void GoToLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginSignupPage());
        }
    }
}