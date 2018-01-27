using System;
using Xamarin.Forms;

namespace CryptoPerformers.Views
{
    public partial class CryptoPage : ContentPage
    {
        public CryptoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
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
                await Navigation.PushAsync(new CryptoItemPage
                {
                    BindingContext = e.SelectedItem as CryptoItemPage
                });
        }
    }
}