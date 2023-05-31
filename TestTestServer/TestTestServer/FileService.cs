using Azure.Storage;
using Azure.Storage.Blobs;
using TestTestServer.Models;
using Azure.Storage.Blobs.Models;
namespace TestTestServer;

public class FileService
{
    private readonly string _storeageAccount = "accountfreent106";
   // private readonly string _storeageAccount = "cs11003200186cbc9d7";
    //private readonly string _key = "hRz2S8pfxxCFP6UIuDRDTaCSANebBjKJ77PH5IhJOdvCIyzr4gQUZikxFWo8+mCTo8S/mm8Yb3js+AStHmAGng==";
     private readonly string _key = "wt4w8k0M8e6P6O7ch7MoMDwmj+P+N/JBl+S0eqjjnYBsZwIZBGbi5WYYnWhsvI7BUIRTIj1cpK7R+AStf3jysQ==";

    private readonly BlobContainerClient _filesContainer;


    public FileService()
    {
        string connectiongString = "DefaultEndpointsProtocol=https;AccountName=accountfreent106;AccountKey=hRz2S8pfxxCFP6UIuDRDTaCSANebBjKJ77PH5IhJOdvCIyzr4gQUZikxFWo8+mCTo8S/mm8Yb3js+AStHmAGng==;EndpointSuffix=core.windows.net";
        var credential = new StorageSharedKeyCredential(_storeageAccount, _key);
        var blobUri = $"https://{_storeageAccount}.blob.core.window.net";
       // var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
        var blobServiceClient = new BlobServiceClient(connectiongString);
        _filesContainer = blobServiceClient.GetBlobContainerClient("publicuploads");
    }
    public async Task<BlobRequestDTo> UpLoadAsync(IFormFile blob)
    {
        BlobRequestDTo response = new BlobRequestDTo();
        BlobClient client = _filesContainer.GetBlobClient(blob.FileName);

        await using (Stream? data = blob.OpenReadStream()) 
        {
            await client.UploadAsync(data,new BlobHttpHeaders { ContentType = blob.ContentType });
        }

        response.status = "File Upload SuccessFully";
        response.Error = false;
        response.Blob.uri = client.Uri.ToString()   ;
        response.Blob.name = client.Name;

        return response;
    }
}
