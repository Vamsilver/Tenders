using Tenders.Core.Enums;
using Tenders.Core.Interfaces;

namespace Tenders.Core.Entities;

public class Customer : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public IndustryType IndustryType { get; set; }

    public Customer(string login, string password, string email, string firstName, string lastName, string patronymic,
        RoleType roleType, string phoneNumber, IndustryType industryType)
        : base(login, password, email, roleType, phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        IndustryType = industryType;
    }
}