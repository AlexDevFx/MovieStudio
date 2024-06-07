namespace MovieStudio.Core.Users;

public record NewUser(string FirstName, string SecondName, string UserName, UserRoleType RoleType)
{
    public IEnumerable<string?> Validate()
    {
        foreach (var field in new[] { FirstName, SecondName, UserName})
        {
            string? error = IsStringEmpty(nameof(field), field);
            if (error != null) yield return error;
        }
    }

    private string? IsStringEmpty(string fieldName, string fieldValue)
    {
        if (string.IsNullOrEmpty(fieldValue) || string.IsNullOrWhiteSpace(fieldValue))
        {
            return $"{fieldName} cannot be empty";
        }

        return null;
    }
};