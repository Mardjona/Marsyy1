using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Marsyy1.Models;
using Metsys.Bson;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
            if (onoff == null) return;


            List<Client> clients = Helper.Database.Clients.Include(x => x.Visits).Include(x => x.Tags).ToList();

            if (!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                clients = clients.Where(t =>
                    t.Firstname.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    t.Lastname.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    t.Patronymic.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    t.Email.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    t.Phone.ToLower().Contains(SearchTextBox.Text!.ToLower()))
                    .ToList();
            }

            switch (PageNavig.SelectedIndex)
            {
                case 0:
                    clients = clients.ToList(); break;
                case 1:
                    clients = clients.Where(x => x.Id >= 510 && x.Id < 520).ToList();
                    break;

                case 2:
                    clients = clients.Where(x => x.Id >= 510 && x.Id < 550).ToList();
                    break;
                case 3:
                    clients = clients.Where(x => x.Id >= 510 && x.Id < 710).ToList();
                    break;
            }



            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    clients = clients.ToList();
                    break;
                case 1:
                    clients = clients.Where(x => x.Gender == "м").ToList();
                    break;
                case 2:
                    clients = clients.Where(x => x.Gender == "ж").ToList();
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

            if (onoff.IsChecked == true)
            {
                clients = clients.Where(x => x.Birthday.Month == DateAndTime.Now.Month).ToList();
            }
            else
            {
                clients = clients.ToList();
            }

            ClientListBox.ItemsSource = clients.ToList();


        }
        private void DeliteServices_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)(sender as Button).Tag;
            var client = Helper.Database.Clients.Find(id);

        

            if (client != null)
            {
                if (client.Visits.Count <= 0)
                {
                    Helper.Database.Clients.Remove(client);
                    Helper.Database.SaveChanges();
                    Loadservices();
                }
                else
                {
                    Console.WriteLine("”даление кллиентов с посещени€ми запрещено");
                }
            }
            
            

            
        }
        public void Edit(object? sender, PointerReleasedEventArgs e)
        {


            RedandAdd redandAdd = new RedandAdd();
            redandAdd.Show();
            Close();
        }
       




        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => Loadservices();
        private void SortCombobox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => Loadservices();
        private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loadservices();
        private void CheckBox_Checked(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => Loadservices();

        private void CheckBox_Unchecked(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => Loadservices();
        private void PageNavig_Selection(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => Loadservices();

    }
}
