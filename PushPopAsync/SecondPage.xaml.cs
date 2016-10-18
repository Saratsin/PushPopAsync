using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PushPopAsync
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            System.Diagnostics.Debug.WriteLine("Second page appeared");
        }
    }
}
