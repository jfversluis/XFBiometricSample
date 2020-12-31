using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace XFBiometricSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var availability = await CrossFingerprint.Current.IsAvailableAsync();

            if (!availability)
            {
                await DisplayAlert("Warning!", "No biometrics available", "OK");

                return;
            }

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Heads up!", "I would like to use your biometrics, please!"));

            if (authResult.Authenticated)
            {
                await DisplayAlert("Yaay!", "Here is the secrets", "Thanks!");
            }
        }
    }
}
