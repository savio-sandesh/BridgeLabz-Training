namespace Models.Exception;

/// <summary>
/// Represents an exception thrown when a requested contact cannot be found.
/// </summary>
public class ContactNotFoundException : System.Exception
{
    public ContactNotFoundException(int contactId)
        : base($"Contact with ID {contactId} was not found.")
    {
    }
}