namespace BlazorApp.Models
{
    public class Product
    {
        //public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price));
            }
            this.Name = name;
            var currentDateTime = DateTime.Now;
            if (currentDateTime.DayOfWeek == DayOfWeek.Sunday)
                this.Price = price * 0.5m;
            else
                this.Price = price;


        }
    }
}

