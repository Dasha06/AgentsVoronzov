namespace AgentsVoronzov.Models;

public class AgentsList
{
    
    public string Title { get; set; }           // Наименование
    public string Phone { get; set; }          // Телефон
    public string AgentsType { get; set; }           // Тип (МФО, ЗАО и т.д.)
    public int SellsPerYear { get; set; }      // Количество продаж в год
    public decimal Skidka { get; set; }        // Размер скидки (например, 10.5%)
}