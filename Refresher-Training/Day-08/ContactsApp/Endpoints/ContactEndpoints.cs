using ContactsApp.Interface;
using ContactsApp.Model;

namespace ContactsApp.Endpoints;

/// <summary>
/// Maps contact-related API endpoints.
/// </summary>
public static class ContactEndpoints
{
    /// <summary>
    /// Registers the contact endpoints on the application.
    /// </summary>
    public static void MapContactEndpoints(this WebApplication app)
    {
        app.MapGet("/api/contacts",
            async (IContactService service) =>
            {
                List<Contact> contacts =
                    await service.GetAllContactsAsync();

                return Results.Ok(contacts);
            });

        app.MapGet("/api/contacts/{id:int}",
            async (int id, IContactService service) =>
            {
                Contact? contact =
                    await service.GetContactByIdAsync(id);

                if (contact == null)
                {
                    return Results.NotFound(
                        new
                        {
                            message = "Contact not found."
                        }
                    );
                }

                return Results.Ok(contact);
            });

        app.MapPost("/api/contacts",
            async (Contact contact, IContactService service) =>
            {
                try
                {
                    int contactId =
                        await service.AddContactAsync(contact);

                    return Results.Created(
                        $"/api/contacts/{contactId}",
                        new
                        {
                            contactId,
                            message = "Contact created successfully."
                        }
                    );
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(
                        new
                        {
                            message = ex.Message
                        }
                    );
                }
            });

        app.MapPut("/api/contacts/{id:int}",
async (
    int id,
    Contact contact,
    IContactService service) =>
{
    try
    {
        contact.ContactId = id;

        bool updated =
            await service.UpdateContactAsync(contact);


        if (!updated)
        {
            return Results.NotFound(
                new
                {
                    message = "Contact not found."
                }
            );
        }


        return Results.Ok(
            new
            {
                message = "Contact updated successfully."
            }
        );
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(
            new
            {
                message = ex.Message
            }
        );
    }
});

        app.MapDelete("/api/contacts/{id:int}",
        async (
            int id,
            IContactService service) =>
        {
            try
            {
                bool deleted =
                    await service.DeleteContactAsync(id);


                if (!deleted)
                {
                    return Results.NotFound(
                        new
                        {
                            message = "Contact not found."
                        }
                    );
                }


                return Results.Ok(
                    new
                    {
                        message = "Contact deleted successfully."
                    }
                );
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(
                    new
                    {
                        message = ex.Message
                    }
                );
            }
        });
    }
}