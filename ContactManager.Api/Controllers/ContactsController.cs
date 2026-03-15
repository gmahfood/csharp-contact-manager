using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Api.Data;
using ContactManager;

namespace ContactManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    // AppDbContext is injected automatically by ASP.NET - this is called "dependency injection"
    // Instead of creating it ourselves, we ask ASP.NET to provide it for us
    // This ensures we always use the same database connection per request
    private readonly AppDbContext _db;

    public ContactsController(AppDbContext db)
    {
        _db = db;
    }

    // ---------------------------------------------
    // GET /api/contacts
    // ---------------------------------------------
    // Fetches all contacts from the database
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.Contacts.ToListAsync());

    // ---------------------------------------------
    // GET /api/contacts/search?name=George
    // ---------------------------------------------
    // Searches contacts by name in the database
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string name)
        => Ok(await _db.Contacts
            .Where(c => c.Name.Contains(name))
            .ToListAsync());

    // ---------------------------------------------
    // POST /api/contacts
    // ---------------------------------------------
    // Creates a new contact and saves it to the database
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ContactRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("Name cannot be empty.");

        var contact = new Contact(request.Name, request.Phone, request.Email);
        _db.Contacts.Add(contact);

        // SaveChangesAsync actually writes to the database
        await _db.SaveChangesAsync();

        return Created("", contact);
    }

    // ---------------------------------------------
    // DELETE /api/contacts/{name}
    // ---------------------------------------------
    // Finds and deletes a contact from the database by name
    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        var contact = await _db.Contacts
            .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

        if (contact == null)
            return NotFound($"Contact '{name}' not found.");

        _db.Contacts.Remove(contact);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}

// Simple container for receiving POST request data as JSON
public record ContactRequest(string Name, string Phone, string Email);
