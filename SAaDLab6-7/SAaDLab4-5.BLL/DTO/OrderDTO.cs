namespace SAaDLab4_5.BLL.DTO;
public class OrderDTO
{
    public int Id { get; set; }

    public int QuestId { get; set; }
    public QuestDTO QuestDTO { get; set; }

    public int CustomerId { get; set; }
    public CustomerDTO CustomerDTO { get; set; }

    public DateTime Date { get; set; }
    public bool GiftCertificate { get; set; }
    public decimal Total { get; set; }

    public override string ToString()
    {
        string res = $"\nId : {Id};" +
            $"\nQuestId : {QuestId};" +
            $"\nCustomerId : {CustomerId};" +
            $"\nDate : {Date};" +
            $"\nGift certificate : {GiftCertificate};" +
            $"\nTotal : {Total}.";

        return res;
    }
}
