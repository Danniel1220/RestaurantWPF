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
        OrderManager orderManager;

        List<List<Order>> orderItems = new List<List<Order>>();

        public MainWindow()
        {
            Trace.WriteLine("App starting...");
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            tabPanel = new TabPanel(TABS_FILE_NAME_PATH, itemsTabPanel, Button_Click);
            listPanel = new ListPanel(NUMBER_OF_TABLES, itemsListPanel, orderItems);
            orderManager = new OrderManager(orderItems, orderListPanel);

            itemsListPanel.SelectedIndex = 0;

        }

        private void itemsListPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            Trace.WriteLine(list.SelectedIndex);

            orderManager.setItemsInList(list.SelectedIndex);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Trace.WriteLine(b.Name);

            orderManager.addItemToOrder(itemsListPanel.SelectedIndex, b.Content.ToString());
        }
    }
}
