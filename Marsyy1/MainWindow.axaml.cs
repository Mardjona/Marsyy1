using Avalonia.Controls;
using Marsyy1.Models;
using Metsys.Bson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsyy1
{
    public partial class MainWindow : Window
    {
        private EventHandler<SelectionChangedEventArgs> ClientCombobox_Lostfocus;

        public MainWindow()
        {
            InitializeComponent();

            Loadservices();
            Loadservice();
        }



        private void Loadservices()
        {
            if (FilterComboBox == null) return;
            List<Client> clients;

            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    clients = Helper.Database.Clients.ToList();
                    break;
                case 1:
                    clients = Helper.Database.Clients.Where(x => x.Gender == "ì").ToList();
                    break;
                case 2:
                    clients = Helper.Database.Clients.Where(x => x.Gender == "æ").ToList();
                    break;
                default: clients = Helper.Database.Clients.ToList(); break;
            }

            ClientListBox.ItemsSource = clients.ToList();


        }


        private void Loadservice ()
        {

            if (SortCombobox == null) return;
            List<Client> clients;
            switch (SortCombobox.SelectedIndex)
            {
                case 0:
                    clients = Helper.Database.Clients.ToList();
                    break;
                case 1:
                    clients = Helper.Database.Clients.OrderBy(x => x.Firstname).ToList();
                    break;
                case 2:
                    clients = Helper.Database.Clients.OrderBy(x => x.Dataofvisit).ToList();
                    break;
                case 3:
                    clients = Helper.Database.Clients.OrderBy(x => x.Countofvisit).ToList();
                    break;
                default: clients = Helper.Database.Clients.ToList(); break;

            }
            ClientListBox.ItemsSource = clients;
        }

        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => Loadservices();
        private void SortCombobox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => Loadservice();

    }
}
