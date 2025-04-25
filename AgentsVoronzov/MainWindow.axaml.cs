using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgentsVoronzov.Context;
using AgentsVoronzov.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.EntityFrameworkCore;

namespace AgentsVoronzov;

public partial class MainWindow : Window
{
    public List<AgentsList> agents = DbHelper.context.Agents
        .Include(x => x.AgentType)
        .Include(x => x.ProductSales)
        .Select(x => new AgentsList
        {
            Id = x.Id,
            Title = x.Title,
            Phone = x.Phone,
            AgentsType = x.AgentType.Title,
            SellsPerYear = x.ProductSales
                .Where(ps => ps.SaleDate >= DateOnly.FromDateTime(DateTime.Now).AddDays(-365)) // взятие торгов за последний год
                .Sum(ps => ps.ProductCount),  
            Skidka = CalculateDiscount(x.ProductSales.Sum(ps => ps.ProductCount)),
            Priority = x.Priority,
            ImagePath = x.Logo,
            Image = x.GetImage
        }).ToList();

    public MainWindow()
    {
        InitializeComponent();
        Agentslistbox.ItemsSource = agents;
        DataContext = this;
        var types = DbHelper.context.AgentTypes.Select(x => x.Title).ToList();
        types.Insert(0, "Все типы");
        Type_ComboBox.ItemsSource = types;
    }

    private void CreateAgent_OnClick(object? sender, RoutedEventArgs e)
    {
        AddOrEditAgent window = new AddOrEditAgent();
        window.Show();
        Close();
    }

    private void EditButton_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RealizButton_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    private void PrevButton_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    private void NextButton_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void TypeComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        ApplyFiltersAndSorting();
    }

    private void Sorting_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        ApplyFiltersAndSorting();
    }

    private void ApplyFiltersAndSorting()
    {
        // Применяем фильтрацию
        var filteredAgents = FilterAgents();
    
        // Применяем сортировку
        var sortedAgents = SortAgents(filteredAgents);
    
        // Обновляем список
        Agentslistbox.ItemsSource = sortedAgents;
    }

    private List<AgentsList> FilterAgents()
    {
        var filterType = Type_ComboBox.SelectionBoxItem as string;
    
        if (filterType == "Все типы" || string.IsNullOrEmpty(filterType))
        {
            return new List<AgentsList>(agents); // Создаем копию списка
        }
    
        return agents.FindAll(x => x.AgentsType == filterType);
    }

    private List<AgentsList> SortAgents(List<AgentsList> agentsToSort)
    {
        var sortType = Sorting_Combobox.SelectionBoxItem as string;
    
        if (string.IsNullOrEmpty(sortType) || sortType == "Сбросить")
        {
            return agentsToSort;
        }
    
        switch (sortType)
        {
            case "Наименование":
                return agentsToSort.OrderBy(a => a.Title).ToList();
            case "Размер скидки":
                return agentsToSort.OrderBy(a => a.Skidka).ToList();
            case "Приоритет":
                return agentsToSort.OrderBy(a => a.Priority).ToList();
            default:
                return agentsToSort;
        }
    }
    
    private static decimal CalculateDiscount(int sum)
    {
        if (sum is >= 0 and < 10000) return 0;
        if (sum is >= 10000 and < 50000) return 5;
        if (sum is >= 50000 and < 150000) return 10;
        if (sum is >= 150000 and < 500000) return 20;
        return 25;
    }
    
    
    
}