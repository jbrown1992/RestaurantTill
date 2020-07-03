namespace RestaurantTill
{
    class FoodItem
    {
        private decimal price;
        private string meal;

        public decimal Price { get => price; set => price = value; }
        public string Meal { get => meal; set => meal = value; }

    }
}