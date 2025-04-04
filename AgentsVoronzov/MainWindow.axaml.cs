using System;
using System.Collections.Generic;
using System.Linq;
using AgentsVoronzov.Context;
using AgentsVoronzov.Models;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;

namespace AgentsVoronzov;

public partial class MainWindow : Window
{
    public List<AgentsList> agents = DbHelper.context.Agents
        .Include(x => x.AgentType)
        .Include(x => x.ProductSales)
        .Select(x => new AgentsList
        {
            Title = x.Title,
            Phone = x.Phone,
            AgentsType = x.AgentType.Title,
            SellsPerYear = x.ProductSales
                // .Where(ps => ps.SaleDate >= DateOnly.FromDateTime(DateTime.Now).AddDays(-365)) // взятие торгов за последний год
                .Sum(ps => ps.ProductCount),  
            Skidka = CalculateDiscount(x.ProductSales.Sum(ps => ps.ProductCount)) 
        }).ToList();

    public MainWindow()
    {
        InitializeComponent();
        Agentslistbox.ItemsSource = agents;
        // Agentslistbox.ItemsSource
    }

    private void CreateAgent_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void EditButton_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RealizButton_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    // private void PrevButton_Click(object? sender, RoutedEventArgs e)
    // {
    //     throw new System.NotImplementedException();
    // }
    //
    // private void NextButton_Click(object? sender, RoutedEventArgs e)
    // {
    //     throw new System.NotImplementedException();
    // }

    private void TypeComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    private void Sorting_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var sortType = Sorting_Combobox.SelectedValue as string;
        switch (sortType)
        {
            case "Наименование":
            {
                agents.OrderBy(a=> a.Title);
                Agentslistbox.ItemsSource = agents;
                break;
            }
            
        }
    }
    
    private static decimal CalculateDiscount(int sum)
    {
        if (0 <= sum && sum < 10000) return 0;
        if (10000 <= sum && sum < 50000) return 5;
        if (50000 <= sum && sum < 150000) return 10;
        if (150000 <= sum && sum < 500000) return 20;
        return 25;
    }
}