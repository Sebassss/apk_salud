using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace apk_salud_xf
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CapsInfo : ContentPage 
	{
		public CapsInfo ()
		{
			InitializeComponent();
            //StartListening();
            var map = new Map(MapSpan.FromCenterAndRadius(new Position(36.8961, 10.1865), Distance.FromMiles(0.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,

            };

            var position1 = new Position(37.8961, 10.1865);
            var position2 = new Position(35.8961, 10.1865);
            var position3 = new Position(34.8961, 10.1865);
            var position4 = new Position(33.8961, 10.1865);
            var position5 = new Position(32.8961, 10.1865);
            var position6 = new Position(31.8961, 10.1865);

            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "IntilaQ",
                Address = "www.intilaq.tn",
            };

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "Telnet R&D",
                Address = "www.groupe-telnet.com"
            };

            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "Telnet R&D",
                Address = "www.kromberg-schubert.com"
            };

            var pin4 = new Pin
            {
                Type = PinType.Place,
                Position = position4,
                Label = "Telnet R&D",
                Address = "www.kromberg-schubert.com"
            };

            var pin5 = new Pin
            {
                Type = PinType.Place,
                Position = position5,
                Label = "Telnet R&D",
                Address = "www.kromberg-schubert.com"
            };

            var pin6 = new Pin
            {
                Type = PinType.Place,
                Position = position6,
                Label = "Telnet R&D",
                Address = "www.kromberg-schubert.com"
            };

            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
            map.Pins.Add(pin3);
            map.Pins.Add(pin4);
            map.Pins.Add(pin5);
            map.Pins.Add(pin6);

            Content = map;
        }

    


        async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
                return;

            ///This logic will run on the background automatically on iOS, however for Android and UWP you must put logic in background services. Else if your app is killed the location updates will be killed.
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true, new Plugin.Geolocator.Abstractions.ListenerSettings
            {
                ActivityType = Plugin.Geolocator.Abstractions.ActivityType.AutomotiveNavigation,
                AllowBackgroundUpdates = true,
                DeferLocationUpdates = true,
                DeferralDistanceMeters = 1,
                DeferralTime = TimeSpan.FromSeconds(1),
                ListenForSignificantChanges = true,
                PauseLocationUpdatesAutomatically = false
            });

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var test = e.Position;
                
                listenLabel.Text = "Full: Lat: " + test.Latitude.ToString() + " Long: " + test.Longitude.ToString();
                listenLabel.Text += "\n" + $"Time: {test.Timestamp.ToString()}";
                listenLabel.Text += "\n" + $"Heading: {test.Heading.ToString()}";
                listenLabel.Text += "\n" + $"Speed: {test.Speed.ToString()}";
                listenLabel.Text += "\n" + $"Accuracy: {test.Accuracy.ToString()}";
                listenLabel.Text += "\n" + $"Altitude: {test.Altitude.ToString()}";
                listenLabel.Text += "\n" + $"AltitudeAccuracy: {test.AltitudeAccuracy.ToString()}";
                
                
            });
        }
    }
}