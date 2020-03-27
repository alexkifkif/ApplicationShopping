using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using ShoppingTest.Services;

namespace ShoppingTest.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            /*string produit = String.Format("Le produit choisi est :{0} Le prix est:{1} €, d'une quantité de :{2} chez:{3} de la marque {4}", Name.Text, PriceSlider.Value, QuantityStepper.Value, Place.Text, Brand.Text);
            await DisplayAlert ("Validé", produit,  "Ok");*/

            //Ajout de produit
            Product product = new Product
            {
                Name = Name.Text,
                Price = PriceSlider.Value,
                Brand = Brand.Text,
                Place = CityPicker.SelectedItem.ToString(),
                Quantity = (int)QuantityStepper.Value
            };

            await App.Database.SaveProductAsync(product);

            await Navigation.PopAsync();
        }

        public void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            PriceLabel.Text = String.Format("Prix :{0} €", PriceSlider.Value);
        }
        
        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            QuantityLabel.Text = QuantityStepper.Value.ToString();
        }

        //Si le switch est désactivé le bouton de validation ne fonctionne plus
        void OnToggled(object sender, ToggledEventArgs e)
        {
            if (ToggleButton.IsToggled == true)
            {
                ValidButton.IsEnabled = true;
            }
            else if (ToggleButton.IsToggled == false)
            {
                ValidButton.IsEnabled = false;
            }            
        }
    }
}
