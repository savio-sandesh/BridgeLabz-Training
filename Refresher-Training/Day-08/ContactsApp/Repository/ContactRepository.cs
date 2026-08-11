using System.Data;
using ContactsApp.Data;
using ContactsApp.Interface;
using ContactsApp.Model;
using Microsoft.Data.SqlClient;

namespace ContactsApp.Repository;

/// <summary>
/// Provides contact persistence operations.
/// </summary>
public class ContactRepository : IContactRepository
{
    private readonly DbConnection _dbConnection;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactRepository"/> class.
    /// </summary>
    public ContactRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    /// <summary>
    /// Retrieves all contacts from the database.
    /// </summary>
    public async Task<List<Contact>> GetAllContactsAsync()
    {
        List<Contact> contacts = new();

        using SqlConnection connection = _dbConnection.GetConnection();

        using SqlCommand command = new(
            "sp_GetAllContacts",
            connection
        );

        command.CommandType = CommandType.StoredProcedure;

        await connection.OpenAsync();

        using SqlDataReader reader =
            await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            contacts.Add(MapContact(reader));
        }

        return contacts;
    }

    /// <summary>
    /// Retrieves a contact by identifier.
    /// </summary>
    public async Task<Contact?> GetContactByIdAsync(int contactId)
    {
        using SqlConnection connection = _dbConnection.GetConnection();

        using SqlCommand command = new(
            "sp_GetContactsById",
            connection
        );

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(
            new SqlParameter("@ContactId", SqlDbType.Int)
            {
                Value = contactId
            }
        );

        await connection.OpenAsync();

        using SqlDataReader reader =
            await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return MapContact(reader);
        }

        return null;
    }

    /// <summary>
    /// Inserts a new contact and returns its generated identifier.
    /// </summary>
    public async Task<int> AddContactAsync(Contact contact)
    {
        using SqlConnection connection = _dbConnection.GetConnection();

        using SqlCommand command = new(
            "sp_AddContact",
            connection
        );

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(
            new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
            {
                Value = contact.FirstName
            }
        );

        command.Parameters.Add(
            new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
            {
                Value = contact.LastName
            }
        );

        command.Parameters.Add(
            new SqlParameter("@Email", SqlDbType.VarChar, 150)
            {
                Value = contact.Email
            }
        );

        command.Parameters.Add(
            new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 15)
            {
                Value = contact.PhoneNumber
            }
        );

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        if (result == null || result == DBNull.Value)
        {
            throw new InvalidOperationException(
                "Contact ID was not returned by the database."
            );
        }

        return Convert.ToInt32(result);
    }

    /// <summary>
    /// Maps a database row to a contact model.
    /// </summary>
    private static Contact MapContact(SqlDataReader reader)
    {
        return new Contact
        {
            ContactId = Convert.ToInt32(reader["ContactId"]),

            FirstName = reader["FirstName"].ToString() ?? string.Empty,

            LastName = reader["LastName"].ToString() ?? string.Empty,

            Email = reader["Email"].ToString() ?? string.Empty,

            PhoneNumber = reader["PhoneNumber"].ToString() ?? string.Empty,

            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),

            IsActive = Convert.ToBoolean(reader["IsActive"])
        };
    }

    /// <summary>
    /// Updates an existing contact.
    /// </summary>
    public async Task<bool> UpdateContactAsync(Contact contact)
    {
        using SqlConnection connection = _dbConnection.GetConnection();

        using SqlCommand command = new(
            "sp_UpdateContact",
            connection
        );

        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.Add(
            new SqlParameter("@ContactId", SqlDbType.Int)
            {
                Value = contact.ContactId
            }
        );


        command.Parameters.Add(
            new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
            {
                Value = contact.FirstName
            }
        );


        command.Parameters.Add(
            new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
            {
                Value = contact.LastName
            }
        );


        command.Parameters.Add(
            new SqlParameter("@Email", SqlDbType.VarChar, 150)
            {
                Value = contact.Email
            }
        );


        command.Parameters.Add(
            new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 15)
            {
                Value = contact.PhoneNumber
            }
        );


        await connection.OpenAsync();


        int rowsAffected =
            await command.ExecuteNonQueryAsync();


        return rowsAffected > 0;
    }

    /// <summary>
    /// Deletes a contact by identifier.
    /// </summary>
    public async Task<bool> DeleteContactAsync(int contactId)
    {
        using SqlConnection connection = _dbConnection.GetConnection();


        using SqlCommand command = new(
            "sp_DeleteContact",
            connection
        );


        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.Add(
            new SqlParameter("@ContactId", SqlDbType.Int)
            {
                Value = contactId
            }
        );


        await connection.OpenAsync();


        int rowsAffected =
            await command.ExecuteNonQueryAsync();


        return rowsAffected > 0;
    }
}