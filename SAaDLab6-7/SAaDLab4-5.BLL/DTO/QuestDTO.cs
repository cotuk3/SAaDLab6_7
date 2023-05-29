namespace SAaDLab4_5.BLL.DTO;
public class QuestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ParticipantsQuantity { get; set; }
    public decimal Price { get; set; }
    public TimeSpan TimeToComplete { get; set; }

    public override string ToString()
    {
        string res = $"\nName : {Name};" +
            $"\nParticipants : {ParticipantsQuantity};" +
            $"\nTime : {TimeToComplete};" +
            $"\nPrice : {Price}.";

        return res;
    }
}
