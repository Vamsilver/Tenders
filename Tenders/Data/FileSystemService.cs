using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Tenders.Data;

public class FileSystemService
{
    public async Task UploadFileToDb(Stream stream, string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var gridFs = new GridFSBucket(database);

        await gridFs.UploadFromStreamAsync(fileName, stream);
    }

    public void DownloadToLocal(string? name)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Tenders");
        var gridFs = new GridFSBucket(database);

        Directory.CreateDirectory("C:\\DocumentsFromTenders\\");
        using FileStream fs = new FileStream($"C:\\DocumentsFromTenders\\{name}", FileMode.OpenOrCreate);
        gridFs.DownloadToStreamByName($"{name}", fs);
    }

    public GridFSFileInfo FindFile(string name)
    {
        var client = new MongoClient("mongodb://localhost");
 
        var db = client.GetDatabase("Tenders"); 
        IGridFSBucket gridFS = new GridFSBucket(db);
        var filter = Builders<GridFSFileInfo>.Filter.Eq(info => info.Filename, name);
        var fileInfos = gridFS.Find(filter);
        var fileInfo = fileInfos.FirstOrDefault();
        return fileInfo;
    }
    
    public async void DeleteFile(string name)
    {
        var client = new MongoClient("mongodb://localhost");
 
        var db = client.GetDatabase("Tenders"); 
        IGridFSBucket gridFS = new GridFSBucket(db);
        var filter = Builders<GridFSFileInfo>.Filter.Eq(info => info.Filename, name);
        var fileInfos = await gridFS.FindAsync(filter);
        var fileInfo = fileInfos.FirstOrDefault();
        if(fileInfo!= null)
            await gridFS.DeleteAsync(fileInfo.Id);
    }
}