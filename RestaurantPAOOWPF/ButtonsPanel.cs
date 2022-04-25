using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantPAOOWPF
{
    internal class ButtonsPanel
    {
        ScrollViewer scrollViewer;
        RoutedEventHandler button_Click;

        public ButtonsPanel(ScrollViewer buttonsTabPanel, RoutedEventHandler button_Click)
        {
            this.scrollViewer = buttonsTabPanel;
            this.button_Click = button_Click;

            WrapPanel wrapPanel = new WrapPanel();

            scrollViewer.Content = wrapPanel;

            Button newOrderButton = new Button();
            newOrderButton.Name = "newOrderButton";
            newOrderButton.Content = "New Order";
            newOrderButton.Margin = new Thickness(4, 4, 4, 4);
            newOrderButton.Width = 100;
            newOrderButton.Height = 100;
            newOrderButton.Click += button_Click;

            Button finishOrderButton = new Button();
            finishOrderButton.Name = "finishOrderButton";
            finishOrderButton.Content = "Finish Order";
            finishOrderButton.Margin = new Thickness(4, 4, 4, 4);
            finishOrderButton.Width = 100;
            finishOrderButton.Height = 100;
            finishOrderButton.Click += button_Click;

            Button deleteOrderItemButton = new Button();
            deleteOrderItemButton.Name = "deleteOrderItemButton";
            deleteOrderItemButton.Content = "Delete Order Item";
            deleteOrderItemButton.Margin = new Thickness(4, 4, 4, 4);
            deleteOrderItemButton.Width = 100;
            deleteOrderItemButton.Height = 100;
            deleteOrderItemButton.Click += button_Click;

            wrapPanel.Children.Add(newOrderButton);
            wrapPanel.Children.Add(finishOrderButton);
            wrapPanel.Children.Add(deleteOrderItemButton);

            buttonsTabPanel.Content = wrapPanel;
        }
    }
}
