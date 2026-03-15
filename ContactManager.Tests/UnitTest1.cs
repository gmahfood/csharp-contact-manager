using ContactManager;

namespace ContactManager.Tests;

public class ContactServiceTests
{
    // We create a fresh ContactService for each test
    // This ensures tests don't affect each other
    private readonly ContactService _service = new();

    // NAMING CONVENTION: MethodName_Scenario_ExpectedResult
    // This makes it crystal clear what each test is checking

    [Fact]
    public void AddContact_ValidData_ReturnsTrue()
    {
        // Arrange - set up the data we need
        var name = "George";
        var phone = "123-456-7890";
        var email = "george@example.com";

        // Act - call the method we're testing
        var result = _service.AddContact(name, phone, email);

        // Assert - check the result is what we expected
        Assert.True(result);
    }

    [Fact]
    public void AddContact_EmptyName_ReturnsFalse()
    {
        // Empty name should fail validation and return false
        var result = _service.AddContact("", "123", "test@test.com");
        Assert.False(result);
    }

    [Fact]
    public void GetContacts_AfterAddingOne_ReturnsOneContact()
    {
        _service.AddContact("George", "123", "g@g.com");

        var contacts = _service.GetContacts();

        // Count should be exactly 1
        Assert.Single(contacts);
    }

    [Fact]
    public void SearchByName_ExistingContact_ReturnsMatch()
    {
        _service.AddContact("George", "123", "g@g.com");

        var results = _service.SearchByName("George");

        Assert.Single(results);
        Assert.Equal("George", results[0].Name);
    }

    [Fact]
    public void SearchByName_NoMatch_ReturnsEmpty()
    {
        _service.AddContact("George", "123", "g@g.com");

        var results = _service.SearchByName("Nobody");

        // Should return an empty list, not null
        Assert.Empty(results);
    }

    [Fact]
    public void DeleteContact_ExistingContact_ReturnsTrue()
    {
        _service.AddContact("George", "123", "g@g.com");

        var result = _service.DeleteContact("George");

        Assert.True(result);
    }

    [Fact]
    public void DeleteContact_NonExistentContact_ReturnsFalse()
    {
        // Trying to delete someone who doesn't exist should return false
        var result = _service.DeleteContact("Nobody");
        Assert.False(result);
    }

    [Fact]
    public void DeleteContact_AfterDeleting_ContactIsGone()
    {
        _service.AddContact("George", "123", "g@g.com");
        _service.DeleteContact("George");

        var contacts = _service.GetContacts();

        // List should be empty after deletion
        Assert.Empty(contacts);
    }
}