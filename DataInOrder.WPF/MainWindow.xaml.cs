using System.Windows;
using System.Windows.Controls;
using DataInOrder.Domain.Entities;

namespace DataInOrder.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

    }

    private void OnDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
        {
            string filter = selectedItem.Tag?.ToString();
            if (!string.IsNullOrEmpty(filter))
            {
                //(filter);
            }
        }
    }

    private void FilterData(string sortParameter)
    {
        var items = personsGrid.ItemsSource as List<Person>;
        if (items != null)
        {
            switch (sortParameter)
            {
                case "DateAsc":
                    break;
                case "FirstNameAsc":
                    break;
                case "LastNameAsc":
                    break;
                case "SurNameAsc":
                    break;
                case "CityAsc":
                    break;
                case "CountryAsc":
                    break;
                case "DateDesc":
                    break;
                case "FirstNameDesc":
                    break;
                case "LastNameDesc":
                    break;
                case "SurNameDesc":
                    break;
                case "CityDesc":
                    break;
                case "CountryDesc":
                    break;
                case "DateSearch":
                    break;
                case "FirstNameSearch":
                    break;
                case "LastNameSearch":
                    break;
                case "SurNameSearch":
                    break;
                case "CitySearch":
                    break;
                case "CountrySearch":
                    break;
                case "DateClearFilter":
                    break;
                case "FirstNameClearFilter":
                    break;
                case "LastNameClearFilter": 
                    break;
                case "SurNameClearFilter":
                    break;
                case "CityClearFilter":
                    break;
                case "CountryClearFilter":
                    break;
            }
        }
    }

}