using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Marsyy1.Models;

namespace Marsyy1;

public partial class RedandAdd : Window
{
    private Client CurrentClient;
    public RedandAdd()
    {
        InitializeComponent();

        CurrentClient = new Client();

        // ClientModel.DataContext = CurrentClient;

    }

    public RedandAdd(Client client)
    {
        InitializeComponent();

        CurrentClient = client;

        ClientModel.DataContext = CurrentClient;

    }

    public void Save_Button(object sender, RoutedEventArgs e)
    {
        Helper.Database.Clients.Update(CurrentClient);
        Helper.Database.SaveChanges();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
    public void Back_Button(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}
   