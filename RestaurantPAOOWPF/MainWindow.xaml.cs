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
            orderManager = new OrderManager(ordersList, orderListPanel, tabPanel.allItems);

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
                case "finishOrderButton":
                    int selectedIndexFinish = itemsListPanel.SelectedIndex;
                    List<OrderItem> orderItemsFinish = ordersList[selectedIndexFinish];

                    if(orderItemsFinish.Count > 0)
                    {
                        string orderInfo = "";

                        foreach (OrderItem item in orderItemsFinish)
                        {
                            orderInfo = orderInfo + item.ToStringReceipt() + "\n";
                        }

                        Trace.WriteLine(orderInfo);

                        IOManager.printReceipt(orderInfo);
                        orderManager.clearOrder(selectedIndexFinish);

                        statusLabel.Content = "Order Finished. Receipt created...";
                    }
                    else
                    {
                        statusLabel.Content = "Cannot finish an empty order...";
                    }
                    break;
                case "deleteOrderItemButton":
                    int selectedIndexDelete = orderListPanel.SelectedIndex;

                    if (selectedIndexDelete != -1)
                    {
                        Trace.WriteLine(selectedIndexDelete);
                        List<OrderItem> orderItemsDelete = ordersList[itemsListPanel.SelectedIndex];
                        if (orderItemsDelete.Count > 0)
                        {
                            Trace.WriteLine(selectedIndexDelete);
                            if (orderItemsDelete.ElementAt(selectedIndexDelete).amount == 1)
                            {
                                orderItemsDelete.RemoveAt(selectedIndexDelete);
                            }
                            else
                            {
                                orderItemsDelete.ElementAt(selectedIndexDelete).amount--;
                                orderItemsDelete.ElementAt(selectedIndexDelete).price -= (orderItemsDelete.ElementAt(selectedIndexDelete).price / (orderItemsDelete.ElementAt(selectedIndexDelete).amount + 1));
                            }
                            orderManager.refreshItemsInOrderList(itemsListPanel.SelectedIndex);
                        }
                        else
                        {
                            Trace.WriteLine("reeee-er");
                        }
                        
                    }
                    else
                    {
                        Trace.WriteLine("reeee");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
