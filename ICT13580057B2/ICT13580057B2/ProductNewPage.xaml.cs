using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT13580057B2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580057B2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductNewPage : ContentPage
    {
        Product product;
        public ProductNewPage(Product product = null)
        {
            InitializeComponent();
            this.product = product;

            titleLabel.Text = product == null ? "เพิ่มสืนค้าใหม่ๆ" : "แก้ไขข้อมูลสินค้า";

            categoryPicker.Items.Add("เสื้อ");
            categoryPicker.Items.Add("เสื้อ1");
            categoryPicker.Items.Add("เสื้อ2");
            submitButton.Clicked += SubmitButton_Clicked;
            if (product != null)
            {
                productNameEntry.Text = product.Name;
                productDetailEntry.Text = product.Description;
                categoryPicker.SelectedItem = product.Category;
                productPriceEntry.Text = product.Productprice.ToString();
                sellPriceEntry.Text = product.Sellprice.ToString();
                stockEntry.Text = product.Stock.ToString();
            }
        }

        async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Â×¹ÂÑ¹", "¤Ø³µéÍ§¡ÒÃºÑ¹·Ö¡ãªèËÃ×ÍäÁè", "ãªè", "äÁèãªè");
            if (isOk)
            {
                if (product == null)
                {

                    product = new Product();
                    product.Name = productNameEntry.Text;
                    product.Description = productDetailEntry.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.Productprice = decimal.Parse(productPriceEntry.Text);
                    product.Sellprice = decimal.Parse(sellPriceEntry.Text);
                    product.Stock = int.Parse(stockEntry.Text);
                    var id = App.DbHelper.AddProduct(product);
                    await DisplayAlert("ºÑ¹·Ö¡ÊÓàÃç¨", "ÃËÑÊÊÔ¹¤éÒ¢Í§·èÒ¹¤×Í #" + id, "µ¡Å§");

                }
                else
                {
                    product = new Product();
                    product.Name = productNameEntry.Text;
                    product.Description = productDetailEntry.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.Productprice = decimal.Parse(productPriceEntry.Text);
                    product.Sellprice = decimal.Parse(sellPriceEntry.Text);
                    product.Stock = int.Parse(stockEntry.Text);
                    var id = App.DbHelper.UpdateProduct(product);
                    await DisplayAlert("ºÑ¹·Ö¡ÊÓàÃç¨", "á¡éä¢¢éÍÁÙÅÊÔ¹¤éÒàÃÕÂºÃéÍÂ" + id, "µ¡Å§");
                }
                await Navigation.PopModalAsync();
            }
        }
    }
}