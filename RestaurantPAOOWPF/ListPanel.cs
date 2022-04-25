using System.Collections.Generic;
using System.Windows.Controls;

namespace RestaurantPAOOWPF
{
    internal class ListPanel
    {
        List<List<OrderItem>> orderItems;

        public ListPanel(int amountOfItems, ListBox listBox, List<List<OrderItem>> orderItems)
        {
            this.orderItems = orderItems;

            for (int i = 1; i <= amountOfItems; i++)
            {
                listBox.Items.Add("Table " + i);
                orderItems.Add(new List<OrderItem>());
            }
        }

        public List<List<OrderItem>> getOrderItems()
        {
            return orderItems;
        }
    }
}
