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

        public OrderManager(List<List<OrderItem>> orderItems, ListBox orderListBox)
        {
            this.orderItems = orderItems;
            this.orderListBox = orderListBox;
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
            if (!isItemAlreadyInOrder(index, new OrderItem(itemToAdd, 0, 0)))
            {


                orderItems[index].Add(new OrderItem(itemToAdd, 1, 0));
            }
            else
            {
                List<OrderItem> order = orderItems[index];
                foreach (OrderItem item in order)
                {
                    if (item.name == itemToAdd)
                    {
                        item.amount++;
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
