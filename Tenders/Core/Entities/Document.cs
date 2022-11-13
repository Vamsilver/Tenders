using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tenders.Core.Enums;
using Tenders.Core.Interfaces;

namespace Tenders.Core.Entities;

public class Document : IHaveId
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsRequired { get; set; }
    public ObjectId? OwnerId { get; set; }
    public string? FileName { get; set; }
    public RoleType OwnerRole { get; set; }

    public Document(string name, RoleType ownerRole, bool isRequired)
    {
        Name = name;
        OwnerRole = ownerRole;
        IsRequired = isRequired;
    }
}
