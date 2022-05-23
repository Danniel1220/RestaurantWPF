using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantPAOOWPF
{
    internal class TabPanel
    {
        TextBlock orderTextBlock;
        RoutedEventHandler button_Click;

        public List<OrderItem> allItems = new List<OrderItem>();

        public TabPanel(string tabsPath, TabControl listBox, RoutedEventHandler button_Click)
        {
            this.orderTextBlock = orderTextBlock;
            this.button_Click = button_Click;

            foreach (string tab in IOManager.readFileByLines(tabsPath))
            {
                listBox.Items.Add(buildTab(IOManager.readFileByLines(@"Resources\" + tab + ".txt"), tab));
            }
        }

        public TabItem buildTab(string[] buttonItems, string tabName)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = tabName;
            ScrollViewer scrollViewer = new ScrollViewer();
            WrapPanel wrapPanel = new WrapPanel();
            scrollViewer.Content = wrapPanel;

            foreach (string buttonItem in buttonItems)
            {
                Button button = new Button();
                string btnName = buttonItem.Replace(" ", "");
                string price = btnName.Substring(btnName.LastIndexOf('-') + 1);
                btnName = btnName.Substring(0, btnName.LastIndexOf("-"));
                button.Name = btnName + "Btn";
                button.Content = btnName;
                button.Margin = new Thickness(4, 4, 4, 4);
                button.Width = 100;
                button.Height = 100;
                button.Click += button_Click;

                Trace.WriteLine(btnName + " " + price);

                OrderItem item = new OrderItem(btnName, 1, float.Parse(price));
                allItems.Add(item);

                wrapPanel.Children.Add(button);
            }
            tabItem.Content = scrollViewer;

            return tabItem;
        }
    }
}
