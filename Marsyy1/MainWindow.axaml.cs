using Avalonia.Controls;
using Marsyy1.Models;
using Metsys.Bson;
using Microsoft.EntityFrameworkCore;
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
           
           ClientListBox.ItemsSource = Helper.Database.Clients.Include(x => x.Tags).ToList();
        }
    }
}