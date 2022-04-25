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
        List<List<Order>> orderItems;
        ListBox orderListBox;

        public OrderManager(List<List<Order>> orderItems, ListBox orderListBox)
        {
            this.orderItems = orderItems;
            this.orderListBox = orderListBox;
        }

        public void setItemsInList(int index)
        {
            orderListBox.Items.Clear();

            List<Order> selectedOrderList = orderItems.ElementAt(index);

            foreach (Order item in selectedOrderList)
            {
                orderListBox.Items.Add(item.ToString());
            }
        }

        public void addItemToOrder(int index, string itemToAdd)
        {
            orderItems[index].Add(new Order(itemToAdd, 0, 0));
            setItemsInList(index);
        }
    }
}
