using order.service.domain.Dtos;
using order.service.domain.Enums;
namespace order.service.domain.Models;

public class Order(string customer)
{
    public int Id { get; private set; }
    public string Customer { get; private set; } = customer;
    public List<OrderItem> Items { get; private set; } = [];
    public decimal Total => Items.Sum(i => i.Subtotal);
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public List<OrderStatusHistoryItem> History { get; private set; } = [];

    public class OrderStatusHistoryItem(OrderStatus status)
    {
        public int Id { get; private set; }
        public OrderStatus Status { get; private set; } = status;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }

    public class OrderItem
    {
        public int Id { get; private set; }
        public int ItemId { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int Quantity { get; private set; }
        public DateTime AddedAt { get; private set; }
        public decimal Subtotal => ItemPrice * Quantity;
        public virtual ItemDto Item { get; private set; }

        public OrderItem(int itemId, decimal itemPrice, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
            ItemPrice = itemPrice;
            AddedAt = DateTime.UtcNow;
        }

        public OrderItem(ItemDto item, int quantity)
        {
            Item = item;
            Quantity = quantity;
            ItemId = item.Id;
            ItemPrice = item.Price;
            AddedAt = DateTime.UtcNow;
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            Quantity -= quantity;
        }
    }

    public void Proccess()
    {
        Status = OrderStatus.Processing;
        AddStatus(Status);
    }

    public void AddStatus(OrderStatus status)
    {
        History.Add(new OrderStatusHistoryItem(status));
    }

    public void AddItem(ItemDto item, int quantity)
    {
        var existingItem = Items.FirstOrDefault(i => i.Item.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.IncreaseQuantity(quantity);
        }
        else
        {
            Items.Add(new OrderItem(item, quantity));
        }
    }

    public void RemoveItem(ItemDto item, int quantity)
    {
        var existingItem = Items.FirstOrDefault(i => i.Item.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.DecreaseQuantity(quantity);
            if (existingItem.Quantity <= 0)
            {
                Items.Remove(existingItem);
            }
        }
    }

}
