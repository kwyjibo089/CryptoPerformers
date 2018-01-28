using System;
using System.Collections.Generic;
using CryptoPerformers.Models;
using Xamarin.Forms;

namespace CryptoPerformers.Views
{
    public partial class CryptoPage : ContentPage
    {
        private readonly AppSettingsService appSettingsService;

        public CryptoPage()
        {
            InitializeComponent();
            appSettingsService = new AppSettingsService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            var data = await App.Database.GetItemsAsync();

            var viewModel = new List<CryptoOverviewViewModel>();
            foreach (var cryptoData in data)
            {
                var vm = new CryptoOverviewViewModel();
                vm.Id = cryptoData.Id;
                vm.Name = cryptoData.Name;
                vm.Symbol = cryptoData.Symbol;
                vm.PercentChange1H = decimal.Parse(cryptoData.PercentChange1H);
                vm.PercentChange24H = decimal.Parse(cryptoData.PercentChange24H);
                vm.PercentChange7D = decimal.Parse(cryptoData.PercentChange7D);
                vm.PriceUsd = decimal.Parse(cryptoData.PriceUsd);
                vm.ImgSrc = string.Format(appSettingsService.IconPath, cryptoData.Symbol);
                viewModel.Add(vm);
            }

            listView.ItemsSource = viewModel;
        }

        //async void OnItemAdded(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new TodoItemPage
        //    {
        //        BindingContext = new TodoItem()
        //    });
        //}

        private void OnRefresh(object sender, EventArgs e)
        {
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
                await Navigation.PushAsync(new CryptoDetailPage
                {
                    BindingContext = e.SelectedItem as CryptoData
                });
        }
    }
}