using Microsoft.EntityFrameworkCore;
using ContactManager.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add controller support - this enables our ContactsController to work
builder.Services.AddControllers();

// Add Swagger UI so we can test our API visually in the browser
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Tell the app to use SQLite with a file called contacts.db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=contacts.db"));

var app = builder.Build();

// Automatically create the database and tables on startup if they don't exist
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Enable Swagger only in development (not in production)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Tell the app to use our controllers (like ContactsController)
app.MapControllers();

app.Run();
