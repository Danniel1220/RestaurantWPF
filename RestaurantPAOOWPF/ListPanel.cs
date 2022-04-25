using System.Collections.Generic;
using System.Windows.Controls;

namespace RestaurantPAOOWPF
{
    internal class ListPanel
    {
        List<List<Order>> orderItems;

        public ListPanel(int amountOfItems, ListBox listBox, List<List<Order>> orderItems)
        {
            this.orderItems = orderItems;

            for (int i = 1; i <= amountOfItems; i++)
            {
                listBox.Items.Add("Table " + i);
                orderItems.Add(new List<Order>());
            }
        }

        public List<List<Order>> getOrderItems()
        {
            return orderItems;
        }
    }
}
