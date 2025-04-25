using System.Linq;
using AgentsVoronzov.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AgentsVoronzov;

public partial class AddOrEditAgent : Window
{
    public AgentType type;
    public AddOrEditAgent()
    {
        InitializeComponent();
        Type_Combobox.ItemsSource = DbHelper.context.AgentTypes.Select(x=> x.Title).ToList();
    }

    private void SelectedType_ComboBox(object? sender, SelectionChangedEventArgs e)
    {
        var selectedType = Type_Combobox.ToString();
        type = new AgentType { Title = selectedType };
    }

    private void ReturnHome_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void CreateAgent_OnClick(object? sender, RoutedEventArgs e)
    {
        var newAgent = new Agent
        {
            Title = Name_TextBox.Text,
            AgentTypeId = DbHelper.context.AgentTypes.Find(type.Title).Id,
            Address = Adress_TextBox.Text,
            Inn = INN_TextBox.Text,
            Kpp = KPP_TextBox.Text,
            DirectorName = FIODirector_TextBox.Text,
            Phone = PhoneNumber_TextBox.Text,
            Email = Email_TextBox.Text
        };
        
        DbHelper.context.Agents.Add(newAgent);
        DbHelper.context.SaveChanges();
        
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}