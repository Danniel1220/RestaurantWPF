using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RestaurantPAOOWPF
{
    internal class OrderManager
    {
        List<List<OrderItem>> orderItems;
        ListBox orderListBox;
        List<OrderItem> allItems;

        public OrderManager(List<List<OrderItem>> orderItems, ListBox orderListBox, List<OrderItem> allItems)
        {
            this.orderItems = orderItems;
            this.orderListBox = orderListBox;
            this.allItems = allItems;
        }

        public void refreshItemsInOrderList(int index)
        {
            orderListBox.Items.Clear();

            List<OrderItem> selectedOrderList = orderItems.ElementAt(index);

            foreach (OrderItem item in selectedOrderList)
            {
                orderListBox.Items.Add(item.ToString());
            }
        }

        public void addItemToOrder(int index, string itemToAdd)
        {
            OrderItem itemObjectToAdd = null;

            foreach (OrderItem item in allItems)
            {
                if (item.name == itemToAdd) itemObjectToAdd = item;
            }

            if (!isItemAlreadyInOrder(index, itemObjectToAdd))
            {
                orderItems[index].Add(new OrderItem(itemToAdd, 1, itemObjectToAdd.price));
            }
            else
            {
                List<OrderItem> order = orderItems[index];
                foreach (OrderItem item in order)
                {
                    if (item.name == itemToAdd)
                    {
                        item.amount++;
                        item.price += itemObjectToAdd.price;
                    }
                }
            }

            refreshItemsInOrderList(index);
        }

        public bool isItemAlreadyInOrder(int index, OrderItem orderItem)
        {
            List<OrderItem> order = orderItems[index];
            foreach (OrderItem item in order)
            {
                if (item.name == orderItem.name) return true;
            }
            return false;
        }

        public void clearOrder(int index)
        {
            orderItems[index].Clear();
            refreshItemsInOrderList(index);
        }
    }
}
