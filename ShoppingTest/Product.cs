using SQLite;

namespace ShoppingTest
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Place { get; set; }
        public string Brand { get; set; }
        public double TotalPrice
        {
            get { return Quantity * Price; }
        }
        public string Temperature { get; set; }
    }
}