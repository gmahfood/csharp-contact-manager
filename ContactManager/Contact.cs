namespace ContactManager;

public class Contact
{
    // EF Core needs a primary key to identify each row in the database
    // By convention, a property named "Id" is automatically used as the primary key
    public int Id { get; set; }

    // Using set instead of init so we can update properties via UpdateDetails
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    // EF Core also needs a parameterless constructor to create objects when reading from the database
    // "protected" means it can only be used by EF Core internally, not by our own code
    protected Contact() { Name = ""; Phone = ""; Email = ""; }

    public Contact(string name, string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        Phone = phone;
        Email = email;
    }

    // Allows updating contact details - needed for the PUT endpoint
    public void UpdateDetails(string name, string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        Phone = phone;
        Email = email;
    }

    public override string ToString() => $"{Name} | {Phone} | {Email}";
}