using Microsoft.AspNetCore.Identity;

namespace AICode.Entities;

public class User : IdentityUser
{
    public string? Initials { get; set; }
}