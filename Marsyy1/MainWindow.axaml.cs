using Avalonia.Controls;
using Marsyy1.Models;
using Metsys.Bson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Marsyy1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loadservices();
          
        }
      


        private void Loadservices()


        {
            if (FilterComboBox == null) return;
            if (SortCombobox == null) return;
            if (SearchTextBox == null) return;

            List<Client> clients = Helper.Database.Clients.Include(x => x.Visits).ToList();

          


            if(!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                clients = clients.Where(t =>
                    t.Firstname.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    t.Lastname.ToLower().Contains(SearchTextBox.Text!.ToLower() ) ||
                    t.Patronymic.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    t.Email.ToLower().Contains(SearchTextBox.Text!.ToLower()) || 
                    t.Phone.ToLower().Contains(SearchTextBox.Text!.ToLower()))
                    .ToList();
            }

           
          
            

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
        private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loadservices();
    }
}
