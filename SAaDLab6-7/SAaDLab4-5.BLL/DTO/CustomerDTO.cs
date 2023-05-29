namespace SAaDLab4_5.BLL.DTO;
// Data Transder Object
public class CustomerDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }

    public override string ToString()
    {
        string res = $"\nName : {FirstName} {LastName};" +
            $"\nEmail Address : {EmailAddress};" +
            $"\nPhone Number : {PhoneNumber}";

        return res;
    }
}
