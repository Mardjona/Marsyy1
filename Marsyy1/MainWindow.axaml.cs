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
        private string _searchQuery;
          


        public MainWindow()
        {
            InitializeComponent();
            Loadservices();
          
        }



        private void Loadservices()
        {
            List<Client> clients = Helper.Database.Clients.Include(x => x.Visits).ToList();
           
          if (FilterComboBox == null) return;
          if (SortCombobox == null) return;
            

            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    clients = clients.ToList();
                    break;
                case 1:
                    clients = clients.Where(x => x.Gender == "ì").ToList();
                    break;
                case 2:
                    clients = clients.Where(x => x.Gender == "æ").ToList();
                    break;
                default: clients = clients.ToList(); break;
            }

            switch (SortCombobox.SelectedIndex)
            {
                case 0:
                    clients = clients.ToList();
                    break;
                case 1:
                    clients = clients.OrderBy(x => x.Firstname).ToList();
                    break;
                case 2:
                    clients = clients.OrderBy(x => x.Dataofvisit).ToList();
                    break;
                case 3:
                    clients = clients.OrderByDescending(x => x.Countofvisit).ToList();
                    break;
                default: clients = clients.ToList(); break;

            }

            ClientListBox.ItemsSource = clients.ToList();


        }


       

        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => Loadservices();
        private void SortCombobox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => Loadservices();

    }
}
