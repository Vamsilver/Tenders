using MongoDB.Bson;
using Tenders.Core.Entities;
using Tenders.Core.Enums;
using Tenders.Core.Interfaces;

namespace Tenders.Core.Projects;

public class Project : IHaveId
{
    public string Name { get; set; }
    public List<Document> Documents { get; set; }

    public DateTime date { get; set; }

    public bool isCompleted { get; set; }

    public IndustryType IndustryType { get; set; }

    public ObjectId OwnerId { get; set; }

    public ObjectId BuilderId { get; set; }
    public ObjectId ProjectorId { get; set; }

    public Project(string name)
    {
        Name = name;
        date = DateTime.Today;
        Documents = new List<Document>();
    }

    public ObjectId Id { get; set; }
}