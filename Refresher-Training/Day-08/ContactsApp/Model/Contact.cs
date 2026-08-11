namespace ContactsApp.Model;

/// <summary>
/// Represents a contact record.
/// </summary>
public class Contact
{
    public int ContactId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }
}