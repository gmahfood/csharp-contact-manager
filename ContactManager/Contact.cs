namespace ContactManager;

// CHANGE: Removed unused "Using System.ComponentModel;" directive. Was never needed.
public class Contact
{
    // CHANGE: Made properties read-only. This way, we can only set them in the constructor, and they cannot be modified later. This is a good practice for data models, as it makes them immutable and easier to work with.
    // WHY: In C#, propererites are the standard wayt to expose data from a class. They provide a clean and consistent way to access data, and they can also include logic for validation or transformation if needed. Using public fields is generally discouraged, as it can lead to less maintainable code.
    // CHANGE: Added a constructor to initialize the properties. This way, we can ensure that a contact always has a name, phone, and email when it is created.
    // - {get; set; } > readable and writeable from anywhere.
    // - {get; init;} > readable from anywhere, but can only be set during construction.
    // Using {get; init;} makes the class immutable, which is a good practice for data models.
    // Once a contact is created, its values can't be accidentally changed from outside the class.

    public string Name { get; init; }
    public string Phone { get; init; }
    public string Email { get; init; }

    // Switched from primary constructor to a standard constructor for better readability.
    // The primary constructor syntax is fine for simple classes, but as we add more logic (like validation), it can become less clear. A standard constructor allows us to easily add validation logic in the future if needed.
    // Adding validation logic (like checking for null or empty values) is a good practice to ensure that our Contact objects are always in a valid state and its cleaner to read.

    public Contact(string name, string phone, string email)
    {
        // Basic validation to ensure that a contact always has a name. We can add more validation (like checking for valid phone numbers or email addresses) in the future if needed.
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        Phone = phone;
        Email = email;
    }

    // CHANGE: Added a ToString() override to make it easier to display contact information. This way, we can simply call Console.WriteLine(contact) and it will display the contact's name, phone, and email in a nice format.
    // WHY: Instead of writing $"{contact.Name} | {contact.Phone} | {contact.Email}" every time we want to display a contact, we can just call contact.ToString() and it will return the same string. This makes our code cleaner and more maintainable, as we only need to change the format in one place if we want to update how contacts are displayed.
    // Now anywhere with Console.WriteLine(contact) will print the contact info in the format we defined in ToString(), which is much cleaner and easier to read.
    public override string ToString() => $"{Name} | {Phone} | {Email}";
}
