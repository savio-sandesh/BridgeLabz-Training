/// <summary>
/// Entity Import--Make Contact class available in Program.cs 
/// </summary>
using ContactsApp.Entity;

/// <summary>
/// Create a new object of WebApplicationBuilder class to configure the application and its services.
/// </summary>
var builder = WebApplication.CreateBuilder(args);


/// <summary>
/// Registers services required for API endpoint discovery.
/// </summary>
builder.Services.AddEndpointsApiExplorer();

/// <summary>
/// Registers Swagger generation services.
/// </summary>
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// Enables Swagger middleware and Swagger UI in the development environment.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



/// <summary>
/// Stores contact data in memory for the application.
/// The data will be lost when the application restarts.
/// </summary>
var contacts = new List<Contact>
{
    new Contact
    {
        Id = 1,
        Name = "Rahul",
        Email = "rahul@gmail.com",
        Phone = "9876543210"
    },

    new Contact
    {
        Id = 2,
        Name = "Aman",
        Email = "aman@gmail.com",
        Phone = "9123456780"
    }
};


/// <summary>
/// Retrieves all contacts from the contact list.
/// Returns HTTP 200 OK with the list of contacts.
/// </summary>
app.MapGet("/contacts", () =>
{
    return Results.Ok(contacts);
});


/// <summary>
/// Retrieves a specific contact using its unique ID.
/// Returns HTTP 404 Not Found if the contact does not exist.
/// </summary>
app.MapGet("/contacts/{id}", (int id) =>
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found.");
    }

    return Results.Ok(contact);
});


/// <summary>
/// Creates a new contact and adds it to the contact list.
/// Validates required fields before creating the contact.
/// Returns HTTP 201 Created when the contact is successfully created.
/// </summary>
app.MapPost("/contacts", (Contact contact) =>
{
    if (string.IsNullOrWhiteSpace(contact.Name))
    {
        return Results.BadRequest("Name is required.");
    }

    if (string.IsNullOrWhiteSpace(contact.Email))
    {
        return Results.BadRequest("Email is required.");
    }

    if (string.IsNullOrWhiteSpace(contact.Phone))
    {
        return Results.BadRequest("Phone is required.");
    }

    // assigning a unique ID to the new contact based on the existing contacts in the list
    contact.Id = contacts.Count == 0
        ? 1
        : contacts.Max(c => c.Id) + 1;

    contacts.Add(contact);

    return Results.Created($"/contacts/{contact.Id}", contact);
});


/// <summary>
/// Updates an existing contact using its unique ID.
/// Validates the contact data before updating.
/// Returns HTTP 404 Not Found if the contact does not exist.
/// </summary>
app.MapPut("/contacts/{id}", (int id, Contact updatedContact) =>
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found.");
    }

    if (string.IsNullOrWhiteSpace(updatedContact.Name))
    {
        return Results.BadRequest("Name is required.");
    }

    if (string.IsNullOrWhiteSpace(updatedContact.Email))
    {
        return Results.BadRequest("Email is required.");
    }

    if (string.IsNullOrWhiteSpace(updatedContact.Phone))
    {
        return Results.BadRequest("Phone is required.");
    }

    contact.Name = updatedContact.Name;
    contact.Email = updatedContact.Email;
    contact.Phone = updatedContact.Phone;

    return Results.Ok(contact);
});


/// <summary>
/// Deletes a contact using its unique ID.
/// Returns HTTP 404 Not Found if the contact does not exist.
/// Returns HTTP 204 No Content after successful deletion.
/// </summary>
app.MapDelete("/contacts/{id}", (int id) =>
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found.");
    }

    contacts.Remove(contact);

    return Results.NoContent();
});


app.Run();






    // Current Architecture of the Application

    //          Client
    //             │
    //             ▼
    //     ASP.NET Core API
    //             │
    //             ▼
    //     Minimal API Endpoints
    //             │
    //     ┌───────┼────────┐
    //     ▼       ▼        ▼
    //    GET     POST     PUT
    //             │
    //             ▼
    //       List<Contact>
    //             │
    //             ▼
    //           RAM
    //             │
    //             ▼
    //          DELETE