using MongoDB.Bson;
using MongoDB.Driver;
using Tenders.Core.Entities;
using Tenders.Core.Enums;
using Tenders.Core.Interfaces;
using Tenders.Core.Projects;

namespace Tenders.Data;

public class MongoDbConnection
{
    public User? User;
    public Project? Project;
    public void AddToDatabase(Customer user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Customer>("Customers");
        collection.InsertOne(user);
    }
    
    public void AddToDatabaseWaterProject(WaterSupplyProject project)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");
        collection.InsertOne(project);
    }
    
    public void AddToDatabaseGasProject(GasFixationProject project)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");
        collection.InsertOne(project);
    }

    public void DeleteFromDatabaseProject(ObjectId id, IndustryType industryType)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        if (industryType == IndustryType.GasFixation)
        {
            var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");
            var deleteFilter = Builders<GasFixationProject>.Filter.Eq("_id", id);
            collection.DeleteOne(deleteFilter);
        }
        else if(industryType == IndustryType.WaterSupply)
        {
            var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");
            var deleteFilter = Builders<WaterSupplyProject>.Filter.Eq("_id", id);
            collection.DeleteOne(deleteFilter);
        }
    }

    public void AddToDatabase(Projector user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Projector>("Projectors");
        collection.InsertOne(user);
    }
    
    public void ReplaceOneParameter<TEntity>(TEntity user, string property, string value) where TEntity : IHaveId?
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<TEntity>(user.GetType().Name + "s");
        var updateDefinition = Builders<TEntity>.Update.Set(property, value);

        collection.UpdateOne(x => x.Id == user.Id, updateDefinition);
    }
    
    public void ReplaceOneParameterInWaterProject(WaterSupplyProject project, string property, double value)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");
        var updateDefinition = Builders<WaterSupplyProject>.Update.Set(property, value);

        collection.UpdateOne(x => x.Id == project.Id, updateDefinition);
    }
    
    public void ReplaceOneParameterInWaterProject(WaterSupplyProject project, string property, bool value)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");
        var updateDefinition = Builders<WaterSupplyProject>.Update.Set(property, value);

        collection.UpdateOne(x => x.Id == project.Id, updateDefinition);
    }
    
    public void ReplaceOneParameterInWaterProject(WaterSupplyProject project, string property, string value)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");
        var updateDefinition = Builders<WaterSupplyProject>.Update.Set(property, value);

        collection.UpdateOne(x => x.Id == project.Id, updateDefinition);
    }
    
    public void ReplaceOneParameterInGasProject(GasFixationProject project, string property, double value)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");
        var updateDefinition = Builders<GasFixationProject>.Update.Set(property, value);

        collection.UpdateOne(x => x.Id == project.Id, updateDefinition);
    }
    
    public void ReplaceOneParameterInGasProject(GasFixationProject project, string property, bool value)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");
        var updateDefinition = Builders<GasFixationProject>.Update.Set(property, value);

        collection.UpdateOne(x => x.Id == project.Id, updateDefinition);
    }

    public void ReplaceDocumentsInWaterProject(WaterSupplyProject project)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");
        var updateDefinition = Builders<WaterSupplyProject>.Update.Set("Documents", project.Documents);

        collection.UpdateOne(x => x.Id == project.Id, updateDefinition);
    }
    
    public void ReplaceDocumentsInGasProject(GasFixationProject project)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");
        var updateDefinition = Builders<GasFixationProject>.Update.Set("Documents", project.Documents);

        collection.UpdateOne(x => x.Id == project.Id, updateDefinition);
    }
    
    public void AddToDatabase(Builder user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Builder>("Builders");
        collection.InsertOne(user);
    }

    // public List<Project> GetProjects()
    // {
    //     return new List<Project>();
    // }

    // public bool FindByLogin(string login)
    // {
    //     return FindByLoginInCustomers(login) is not null ||
    //            FindByLoginInBuilders(login) is not null ||
    //            FindByLoginInProjectors(login) is not null;
    // }
    
    public User? FindByLogin(string login)
    {
        User? user = FindByLoginInCustomers(login);
        if (user is not null)
        {
            return user;
        }
        
        user = FindByLoginInProjectors(login);
        if (user is not null)
        {
            return user;
        }
        
        user = FindByLoginInBuilders(login);
        if (user is not null)
        {
            return user;
        }

        return null;
    }
    
    public Project? FindProject(ObjectId id)
    {
        Project? project = FindWaterProject(id);
        if (project is not null)
        {
            return project;
        }
        
        project = FindGasProject(id);
        if (project is not null)
        {
            return project;
        }
        
        return null;
    }

    public Customer? FindByLoginInCustomers(string login)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Customer?> filter = Builders<Customer>.Filter.Eq("Login", login);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Customer>("Customers");

        return collection.Find(filter).FirstOrDefault();
    }
    
    public Projector? FindByLoginInProjectors(string login)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Projector?> filter = Builders<Projector>.Filter.Eq("Login", login);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Projector>("Projectors");

        return collection.Find(filter).FirstOrDefault();
    }
    
    public List<Projector>? FindProjectors()
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Projector> filter = Builders<Projector>.Filter.Eq("RoleType", RoleType.Projector);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Projector>("Projectors");

        return collection.Find(filter!).ToList();
    }

    public Projector FindProjector(ObjectId id)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Projector> filter = Builders<Projector>.Filter.Eq("_id", id);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Projector>("Projectors");

        return collection.Find(filter!).FirstOrDefault();
    }

    public Builder FindBuilder(ObjectId id)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Builder> filter = Builders<Builder>.Filter.Eq("_id", id);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Builder>("Builders");

        return collection.Find(filter!).FirstOrDefault();
    }
    
    public Customer FindCustomer(ObjectId id)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq("_id", id);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Customer>("Customers");

        return collection.Find(filter!).FirstOrDefault();
    }
    
    public List<Builder>? FindBuilders()
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Builder> filter = Builders<Builder>.Filter.Eq("RoleType", RoleType.Builder);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Builder>("Builders");

        return collection.Find(filter!).ToList();
    }
    
    public Builder? FindByLoginInBuilders(string login)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<Builder?> filter = Builders<Builder>.Filter.Eq("Login", login);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<Builder>("Builders");

        return collection.Find(filter).FirstOrDefault();
    }

    public List<WaterSupplyProject>? FindWaterProjects(ObjectId id)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<WaterSupplyProject> filter = Builders<WaterSupplyProject>.Filter.Eq("OwnerId", id);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");

        return collection.Find(filter).ToList();
    }
    
    public List<GasFixationProject>? FindGasProjects(ObjectId id)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<GasFixationProject> filter = Builders<GasFixationProject>.Filter.Eq("OwnerId", id);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");

        return collection.Find(filter).ToList();
    }
    
    public GasFixationProject FindGasProject(ObjectId id)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<GasFixationProject> filter = Builders<GasFixationProject>.Filter.Eq("_id", id);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");

        return collection.Find(filter).FirstOrDefault();
    }
    
    public WaterSupplyProject FindWaterProject(ObjectId id)
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<WaterSupplyProject> filter = Builders<WaterSupplyProject>.Filter.Eq("_id", id);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");

        return collection.Find(filter).FirstOrDefault();
    }
    
    public List<WaterSupplyProject>? FindAllWaterProjects()
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<WaterSupplyProject> filter = Builders<WaterSupplyProject>.Filter.Eq("IndustryType", IndustryType.WaterSupply);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<WaterSupplyProject>("WaterSupplyProjects");

        return collection.Find(filter).ToList();
    }
    
    public List<GasFixationProject>? FindAllGasProjects()
    {
        var client = new MongoClient("mongodb://localhost");
        FilterDefinition<GasFixationProject> filter = Builders<GasFixationProject>.Filter.Eq("IndustryType", IndustryType.GasFixation);
        var database = client.GetDatabase("Tenders");
        var collection = database.GetCollection<GasFixationProject>("GasFixationProjects");

        return collection.Find(filter).ToList();
    }
}