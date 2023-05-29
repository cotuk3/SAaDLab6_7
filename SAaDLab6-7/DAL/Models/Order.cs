namespace SAaDLab4_5.DAL.Models;
public class Order
{
    public int Id { get; set; }

    public int QuestId { get; set; }
    public Quest Quest { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public DateTime Date { get; set; }
    public bool GiftCertificate { get; set; }
    public decimal Total { get; set; }
}
