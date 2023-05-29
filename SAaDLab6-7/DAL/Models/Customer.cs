namespace SAaDLab4_5.DAL.Models;
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public ICollection<Order> Orders { get; set; }
}
