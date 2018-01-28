using CryptoPerformers.Models;
using Xamarin.Forms;

namespace CryptoPerformers.Views
{
    public class CryptoPageCS : ContentPage
    {
        ListView listView;

        public CryptoPageCS()
        {
            Title = "Cryptos";

            var toolbarItem = new ToolbarItem
            {
                Text = "Refresh",
                //Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                //await Navigation.PushAsync(new CryptoItemPageCS
                //{
                //    BindingContext = new CryptoItemPage()
                //});
            };
            ToolbarItems.Add(toolbarItem);

            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();

                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    var topLeft = new Label { Text = "Top Left" };
                    var topRight = new Label { Text = "Top Right" };
                    var bottomLeft = new Label { Text = "Bottom Left" };
                    var bottomRight = new Label { Text = "Bottom Right" };

                    grid.Children.Add(topLeft, 0, 0);
                    grid.Children.Add(topRight, 0, 1);
                    grid.Children.Add(bottomLeft, 1, 0);
                    grid.Children.Add(bottomRight, 1, 1);

                    return new ViewCell { View = grid };
                })
            };
            listView.ItemSelected += async (sender, e) =>
            {
                //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
                //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new CryptoDetailPageCS
                    {
                        BindingContext = e.SelectedItem as CryptoData
                    });
                }
            };

            Content = listView;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}