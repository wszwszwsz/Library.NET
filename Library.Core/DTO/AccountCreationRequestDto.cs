namespace Library.Core.DTO;

public class AccountCreationRequestDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }

    public AccountCreationRequestDto(string? firstName, string? lastName, string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}