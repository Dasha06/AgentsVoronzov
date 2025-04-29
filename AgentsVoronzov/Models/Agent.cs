using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;

namespace AgentsVoronzov.Models;

public partial class Agent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AgentTypeId { get; set; }

    public string? Address { get; set; }

    public string Inn { get; set; } = null!;

    public string? Kpp { get; set; }

    public string? DirectorName { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Logo { get; set; }
    
    
    // public Bitmap GetImage
    // {
    //     get
    //     {
    //         try
    //         {
    //             string baseDirectory = AppContext.BaseDirectory;
    //             string defaultImagePath = Path.Combine(baseDirectory, "agents", "agent_0.png");
    //
    //             if (!string.IsNullOrEmpty(Logo))
    //             {
    //                 string logoPath = Path.Combine(baseDirectory, Logo);
    //                 if (File.Exists(logoPath))
    //                 {
    //                     return new Bitmap(logoPath);
    //                 }
    //             }
    //
    //             if (File.Exists(defaultImagePath))
    //             {
    //                 return new Bitmap(defaultImagePath);
    //             }
    //
    //             // Если ничего не найдено, возвращаем пустое изображение или кидаем исключение
    //             return new Bitmap(defaultImagePath);
    //         }
    //         catch (Exception ex)
    //         {
    //             // Логирование ошибки (для отладки)
    //             Console.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
    //             return null;
    //         }
    //     }
    // }
    

    public int Priority { get; set; }

    public virtual ICollection<AgentPriorityHistory> AgentPriorityHistories { get; set; } = new List<AgentPriorityHistory>();

    public virtual AgentType AgentType { get; set; } = null!;

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
