namespace ProductSearch.Data
{
    public class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public Product(string title, decimal price, string image)
        {
            Title = title;
            Price = price;
            Image = image;
        }
    }
}
