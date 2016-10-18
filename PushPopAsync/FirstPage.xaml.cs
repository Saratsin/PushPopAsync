using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PushPopAsync
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();

            CurrentListView.ItemsSource = new string[]
            {
                "First element",
                "Second element"
            };
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await IsBusyHandler.Handle(DoNavigationAction);
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await IsBusyHandler.Handle(DoNavigationAction);
        }

        async Task DoNavigationAction()
        {
            System.Diagnostics.Debug.WriteLine("Navigation started");
            await Navigation.PushModalAsync(new SecondPage(), false);
            System.Diagnostics.Debug.WriteLine("Navigation ended");
        }
    }
}
