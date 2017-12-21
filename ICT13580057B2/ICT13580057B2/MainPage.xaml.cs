using ICT13580057B2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13580057B2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;
        }

        protected override void OnAppearing()
        {
            LoadData();
        }
        void LoadData()
        {
            productListView.ItemsSource = App.DbHelper.GetProduct();
        }
        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewPage());
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductNewPage(product));
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isok = await DisplayAlert("Â×¹ÂÑ¹", "µéÍ§¡ÒÃÅºãªèËÃ×ÍäÁè", "ãªè", "äÁèãªè");
            if (isok)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Product;
                App.DbHelper.DeleteProduct(product);
                await DisplayAlert("ÅºÊÓàÃç¨", "Åº¢éÍÁÙÅÊÔ¹¤éÒàÃÕÂºÃéÍÂ", "µ¡Å§");
                LoadData();

            }
        }
    }
}
