using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CryptoPerformers.Views
{
	public class CryptoItemPageCS : ContentPage
	{
		public CryptoItemPageCS ()
		{
		    var labelName = new Label
		    {
		        VerticalTextAlignment = TextAlignment.Center,
		        HorizontalOptions = LayoutOptions.StartAndExpand
		    };
		    labelName.SetBinding(Label.TextProperty, "Name");
		    var labelSymbol = new Label
		    {
		        VerticalTextAlignment = TextAlignment.Center,
		        HorizontalOptions = LayoutOptions.StartAndExpand
		    };
		    labelSymbol.SetBinding(Label.TextProperty, "Symbol");

            Content = new StackLayout
		    {
		        Margin = new Thickness(20),
		        VerticalOptions = LayoutOptions.StartAndExpand,
		        Children =
		        {
		            labelName,
		            labelSymbol
		        }
		    };
        }
	}
}