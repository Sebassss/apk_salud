using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace apk_salud_xf
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void btn_protur_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Mensaje", "OK");
            



        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var imageSender = (Image)sender;
            if(imageSender.ClassId == "x")
            {
                Navigation.PushModalAsync(new CapsInfo());
            }
        }
    }
}
