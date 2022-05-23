using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Reflection;

namespace RestaurantPAOOWPF
{
    public partial class MainWindow : Window
    {
        String TABS_FILE_NAME_PATH = @"Resources\MenuTabs.txt";
        int NUMBER_OF_TABLES = 20;

        TabPanel tabPanel;
        ListPanel listPanel;
        ButtonsPanel buttonsPanel;
        OrderManager orderManager;

        List<List<OrderItem>> ordersList = new List<List<OrderItem>>();

        public MainWindow()
        {
            Trace.WriteLine("App starting...");
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            tabPanel = new TabPanel(TABS_FILE_NAME_PATH, itemsTabPanel, Tab_Panel_Button_Click);
            listPanel = new ListPanel(NUMBER_OF_TABLES, itemsListPanel, ordersList);
            buttonsPanel = new ButtonsPanel(buttonsTabPanel, Button_Panel_Button_Click);
            orderManager = new OrderManager(ordersList, orderListPanel);

            itemsListPanel.SelectedIndex = 0;
        }

        private void itemsListPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            Trace.WriteLine(list.SelectedIndex);

            orderManager.refreshItemsInOrderList(list.SelectedIndex);
        }

        public void Tab_Panel_Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Trace.WriteLine(b.Name);

            orderManager.addItemToOrder(itemsListPanel.SelectedIndex, b.Content.ToString());
        }

        public void Button_Panel_Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Trace.WriteLine(b.Name);

            switch (b.Name)
            {
                case "newOrderButton":
                    break;
                case "finishOrderButton":
                    int selectedIndex = itemsListPanel.SelectedIndex;
                    List<OrderItem> orderItems = ordersList[selectedIndex];

                    if(orderItems.Count > 0)
                    {
                        string orderInfo = "";

                        foreach (OrderItem item in orderItems)
                        {
                            orderInfo = orderInfo + item.ToString() + "\n";
                        }

                        Trace.WriteLine(orderInfo);

                        IOManager.printReceipt(orderInfo);
                        orderManager.clearOrder(selectedIndex);

                        statusLabel.Content = "Order Finished. Receipt created...";
                    }
                    else
                    {
                        statusLabel.Content = "Cannot finish an empty order...";
                    }

                    
                    
                    break;
                case "deleteOrderItemButton":
                    break;
                default:
                    break;
            }
        }
    }
}
