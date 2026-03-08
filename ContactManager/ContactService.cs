namespace ContactManager;

// Program logic for add/view/search/delete.
// ContactService owns ALL contact logic. 

// This separation is called the Single Responsibility Principle (SRP) - each class should have one responsibility.
// each class has one job. 
// Program.cs job is running the UI loop.

public class ContactService
{
    private readonly List<Contact> _contacts = new(); 

    // ---------------------------------------------
    // ADD CONTACT
    // ---------------------------------------------
    // This is where we will implement the logic for adding, viewing, searching, and deleting contacts.

    public bool AddContact(string name, string phone, string email)
    {
        // Validate before creating - guard at the top keep the path clean and readable.
        if (string.IsNullOrWhiteSpace(name))
        return false;

        _contacts.Add(new Contact (name, phone, email));
        return true;
    }

    // ---------------------------------------------
    // VIEW 
    // ---------------------------------------------
    // Return a list of contacts. We can return the actual list, but that would allow the caller to modify it. 
    // Instead, we can return a copy of the list. This way, the caller can read the contacts, but not modify the original list.
    public IReadOnlyList<Contact> GetContacts() => _contacts;
    
    // ---------------------------------------------
    // SEARCH
    // ---------------------------------------------
    // Search for contacts by name. We can return a list of contacts that match the search term.
    // The caller (Program.cs) can then display the results.
    public IReadOnlyList<Contact> SearchByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return new List<Contact>();

            return _contacts
                .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
    }

    // ---------------------------------------------
    // DELETE
    // ---------------------------------------------
    // Delete a contact by name. We can return a boolean to indicate if the contact was
    // successfully deleted or not.
    // The caller can use this to show the right message ("Deleted" vs "Not found"), without needing to know how the list works internally.
    public bool DeleteContact(string name)
    {
        var contact = _contacts.FirstOrDefault(c => 
            c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        
        if (contact == null)
            return false;

        _contacts.Remove(contact);
        return true;
    }

}