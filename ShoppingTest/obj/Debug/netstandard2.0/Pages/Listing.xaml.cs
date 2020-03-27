using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingTest.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingTest.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listing : ContentPage
    {        
        public Listing()
        {
            InitializeComponent();

            ServiceStorage.Products = new ObservableCollection<Product>();
        }

        //Bouton qui retourne vers la page où on enregistre les produits
        public async void OnToolbarClicked(object sender, EventArgs e)
        {   
            await Navigation.PushAsync(new MainPage());
        }

        //Liste les produits enregistrés
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var productList = await App.Database.GetAllProductAsync();

            if (productList != null)
            {
                ListofItems.ItemsSource = productList;
            }
        }

        //Lorsqu'on clique sur l'item on navigue vers une page avec ses caractéristiques
        private void ListofItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ServiceStorage.SelectedProduct =  (Product)e.SelectedItem;

            Navigation.PushAsync(new Caracteristics());
        }
        
        //Methode de suppression dans le menu du swipe
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;

            Product product = (Product)menuItem.CommandParameter;

            await App.Database.DeleteProductAsync(product);
            
            await DisplayAlert("Success", "Produit supprimé", "OK");

            var productList = await App.Database.GetAllProductAsync();

            if (productList != null)
            {
                ListofItems.ItemsSource = productList;
            }
        }
    }
}