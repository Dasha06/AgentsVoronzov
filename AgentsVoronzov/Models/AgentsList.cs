using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AgentsVoronzov.Models;

public class AgentsList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Phone { get; set; }
    public string AgentsType { get; set; }
    public int SellsPerYear { get; set; }
    public decimal Skidka { get; set; }
    
    public int Priority { get; set; }
    
    public string? ImagePath { get; set; }
    
    public Bitmap? Image { get; set; }
    
    
}