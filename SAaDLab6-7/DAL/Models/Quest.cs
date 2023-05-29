namespace SAaDLab4_5.DAL.Models;
public class Quest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ParticipantsQuantity { get; set; }
    public decimal Price { get; set; }
    public TimeSpan TimeToComplete { get; set; }
    public ICollection<Order> Orders { get; set; }
}
