using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingTest;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingTest.Services;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;

namespace ShoppingTest.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Caracteristics : ContentPage
    {
        public Caracteristics()
        {
            InitializeComponent();

            ServiceStorage.Products = new ObservableCollection<Product>();
        }

        //Liste chaque caractéristique du produit
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LabelName.Text = ServiceStorage.SelectedProduct.Name;
            LabelPrice.Text = ServiceStorage.SelectedProduct.Price.ToString();
            LabelQuantity.Text = ServiceStorage.SelectedProduct.Quantity.ToString();
            LabelBrand.Text = ServiceStorage.SelectedProduct.Brand;
            LabelPlace.Text = ServiceStorage.SelectedProduct.Place;
        }

        private void ListofDetails_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void ListofDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

    }
}