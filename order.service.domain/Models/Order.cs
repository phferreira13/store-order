using order.service.domain.Dtos;
using order.service.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Models
{
    public class Order(string customer)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Customer { get; private set; } = customer;
        public OrderItemList ItemList { get; private set; } = new();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public OrderStatusHistory StatusHistory { get; private set; } = new();

        public void Proccess()
        {
            Status = OrderStatus.Processing;
            StatusHistory.AddStatus(Status);
        }

        public class OrderStatusHistory
        {
            public List<OrderStatusHistoryItem> History { get; private set; } = [];

            public void AddStatus(OrderStatus status)
            {
                History.Add(new OrderStatusHistoryItem(status));
            }
        }

        public class OrderStatusHistoryItem(OrderStatus status)
        {
            public OrderStatus Status { get; private set; } = status;
            public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        }

        public class OrderItem
        {
            public ItemDto Item { get; private set; }
            public int Quantity { get; private set; }
            public DateTime AddedAt { get; private set; }
            public decimal Subtotal => Item.Price * Quantity;

            public OrderItem(ItemDto item, int quantity)
            {
                Item = item;
                Quantity = quantity;
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

        public class OrderItemList
        {
            public List<OrderItem> Items { get; private set; } = [];
            public decimal Total => Items.Sum(i => i.Subtotal);

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

    }
}
