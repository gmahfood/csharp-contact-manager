// Contact Manager Project 
// Author: George Mahfood
// A simple console application to manage contacts.
// This is a basic implementation to demonstrate clean code principles and separation of concerns.
// The application allows users to add, view, search, and delete contacts.
// The contact logic is separated into a ContactService class, while the Program.cs is responsible for
// running the UI loop and handling user input/output.

using ContactManager;
// CHANGE: Program.cs no longer owns the contact list or any logic. 
// WHY: This way, we can keep all the contact-related logic in one place (ContactService), and Program.cs 
// is only responsible for running the UI loop. This makes our code cleaner and easier to maintain, as we can easily find and update contact-related logic 
// in ContactService without having to search through Program.cs. It also follows the Single Responsibility Principle (SRP), which is a key principle of clean code design.
// It creates a ContactService and delegates all contact-related operations to it. Program.cs is only responsible for handling user input and displaying output, while ContactService 
// is responsible for managing the contacts. This separation of concerns makes our code more modular and easier to maintain.
// WHY: Program.cs is just a thin shell; it reads input, calls the service, and displays results
// Makes the code much easier to read, maintain, and extent - eventually put in a web API.

var service = new ContactService(); 

Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("==================================");
Console.WriteLine("      CONTACT MANAGER");
Console.WriteLine("==================================");

while (true)
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View Contacts");
    Console.WriteLine("3. Search");
    Console.WriteLine("4. Delete");
    Console.WriteLine("5. Exit");
    Console.Write("\nEnter your choice: ");
    
    string? input = Console.ReadLine();

    // int.Parse throws an exception and crashes the app if the user types "abc"
    // or just hits enter. int.TryParse returns false instead, and allows me handle the
    // the wrong input tactically. 
    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Please enter a valid number.");
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
        Console.Clear();
        continue; // Go back to the start of the loop and show the menu again.
    }
    
    switch (choice)
    {
        // ---------------------------------------------
        // ADD CONTACT
        // ---------------------------------------------
        case 1:
            Console.Write("Name: ");
            string? name = Console.ReadLine();
            
            // Fail fast - no point asking for phone/email if the name is blank.
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                break;
            }

            Console.Write("Phone Number: ");
            string? phone = Console.ReadLine();
            Console.Write("Email: ");
            string? email = Console.ReadLine();

            // Check results and show message to user.
#pragma warning disable CS8604 // Possible null reference argument.
            bool added = service.AddContact(name, phone, email);
#pragma warning restore CS8604 // Possible null reference argument.
            Console.WriteLine(added ? "Contact added successfully." : "Failed to add contact. Please try again.");
            break;

        // ---------------------------------------------
        // VIEW CONTACTS
        // ---------------------------------------------
        case 2:
            // CHANGE: Ask the service for data, then display it here.
            var contacts = service.GetContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                Console.WriteLine($"\n{"Name",-20} {"Phone",-15} {"Email"}");
                Console.WriteLine(new string('-', 65));
                foreach (var c in contacts)
                {
                    // Uses the ToString() override defined on Contact
                    // so the display format is defined in one place.
                    Console.WriteLine(c);
                }
            }
            break;

        // -------------------------
        // SEARCH
        // -------------------------
        case 3:
            Console.Write("Enter name to search: ");
            string? searchName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchName))
            {
                Console.WriteLine("Please enter a name to search.");
                break;
            }

            // Service handles the search, just display results.
            var results = service.SearchByName(searchName);

            if (results.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                foreach (var c in results)
                    Console.WriteLine(c);
            }
            break;

        // -------------------------
        // DELETE
        // -------------------------
        case 4:
            Console.Write("Enter name to delete: ");
            string? deleteName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(deleteName))
            {
                Console.WriteLine("Please enter a name.");
                break;
            }

            // Ask the user to confirm before deleting — good UX practice.
            Console.Write($"Are you sure you want to delete '{deleteName}'? (y/n): ");
            string? confirm = Console.ReadLine();

            if (confirm?.ToLower() != "y")
            {
                Console.WriteLine("Delete cancelled.");
                break;
            }

            // Service handles the deletion, returns bool for feedback.
            bool deleted = service.DeleteContact(deleteName);
            Console.WriteLine(deleted ? "Contact deleted." : "Contact not found.");
            break;

        // -------------------------
        // EXIT
        // -------------------------
        case 5:
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option. Please choose 1 – 5.");
            break;
    }

    // Consolidated the "Press Enter to continue" into one place
    // at the bottom of the loop instead of repeating it in every case block.
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("==================================");
    Console.WriteLine("      CONTACT MANAGER");
    Console.WriteLine("==================================");
}

