using Xamarin.Forms;

namespace CryptoPerformers.Views
{
    public class CryptoDetailPageCS : ContentPage
    {
        public CryptoDetailPageCS()
        {
            var nameLabel = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var symbolLabel = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            symbolLabel.SetBinding(Label.TextProperty, "Name");

            Content = new StackLayout
            {
                Children =
                {
                    nameLabel,symbolLabel
                }
            };
        }
    }
}