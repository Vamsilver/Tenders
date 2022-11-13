using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tenders.Core.Enums;
using Tenders.Core.Interfaces;

namespace Tenders.Core.Entities;

public class User : IHaveId
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public RoleType RoleType { get; set; }
    public string PhoneNumber { get; set; }

    public User(string login, string password, string email, RoleType roleType, string phoneNumber)
    {
        Email = email;
        Login = login;
        Password = password;
        RoleType = roleType;
        PhoneNumber = phoneNumber;
    }
}