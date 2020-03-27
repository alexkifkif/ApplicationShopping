using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShoppingTest.Services
{
    public static class ServiceStorage
    {
        public static ObservableCollection<Product> Products { get; set; }

        public static Product SelectedProduct { get; set; }
    }
}
