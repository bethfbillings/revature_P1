namespace P1.Domain.Models
{
    class CustomPizza
    {
        public int Id { get; set; }
        public Crust Crust;
        public Order Order;
        public Size Size;
        public Toppings Toppings;

        public CustomPizza(Crust NewCrust, Order NewOrder, Size NewSize, Toppings NewToppings)
        {
          Crust = NewCrust;
          Order = NewOrder;
          Size = NewSize;
          Toppings = NewToppings;
        }
    }
}