using Avalonia.Controls;
using Marsyy1.Models;
using System.Collections.Generic;
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
            List<Client> Client = Helper.Database.Clients.ToList();
           ClientListBox.ItemsSource = Client.Select(x => new
           {
               x.Firstname,
               x.Lastname,
               x.Patronymic,
               x.Gender,
               x.Birthday,
               x.Email,
               x.Phone,
               x.Dataofvisit,
               x.Countofvisit,
               x.Photopath



           });
        }
    }
}