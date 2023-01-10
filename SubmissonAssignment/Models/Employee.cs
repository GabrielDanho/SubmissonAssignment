using System;

namespace SubmissonAssignment.Models;

internal interface IEmployee
{   
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
}


internal class Employee : IEmployee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string DisplayName => $"{FirstName} {LastName}";
}
